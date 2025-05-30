param planName string
param appName string
param location string = resourceGroup().location
param storageAccountName string
param deploymentStorageContainerName string
param applicationInsightsName string
param tags object = {}
param functionAppRuntime string = 'dotnet-isolated'
param functionAppRuntimeVersion string = '8.0'
param maximumInstanceCount int = 100
param instanceMemoryMB int = 2048

resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' existing = {
  name: storageAccountName
}

resource appInsights 'Microsoft.Insights/components@2020-02-02' existing = {
  name: applicationInsightsName
}

resource flexFuncPlan 'Microsoft.Web/serverfarms@2024-04-01' = {
  name: planName
  location: location
  tags: tags
  kind: 'functionapp'
  sku: {
    tier: 'FlexConsumption'
    name: 'FC1'
  }
  properties: {
    reserved: true
  }
}

var serviceTags = union(tags, {
  'azd-service-name': 'api'
})

resource flexFuncApp 'Microsoft.Web/sites@2024-04-01' = {
  name: appName
  location: location
  tags: serviceTags
  kind: 'functionapp,linux'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    serverFarmId: flexFuncPlan.id
    siteConfig: {
      appSettings: [
        {
          name: 'AzureWebJobsStorage__accountName'
          value: storage.name
        }
        {
          name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
          value: appInsights.properties.ConnectionString
        }
      ]
    }
    functionAppConfig: {
      deployment: {
        storage: {
          type: 'blobContainer'
          value: '${storage.properties.primaryEndpoints.blob}${deploymentStorageContainerName}'
          authentication: {
            type: 'SystemAssignedIdentity'
          }
        }
      }
      scaleAndConcurrency: {
        maximumInstanceCount: maximumInstanceCount
        instanceMemoryMB: instanceMemoryMB
      }
      runtime: { 
        name: functionAppRuntime
        version: functionAppRuntimeVersion
      }
    }
  }
}

var storageRoleDefinitionID_Contributor = 'ba92f5b4-2d11-453d-a403-e96b0029c9fe' //Storage Blob Data Contributor role
var storageRoleDefinitionId  = 'b7e6dc6d-f1e8-4753-8033-0f276bb0955b' //Storage Blob Data Owner role

module storageRoleAssignment 'br/public:avm/ptn/authorization/resource-role-assignment:0.1.2' = {
  dependsOn: [
    flexFuncApp
  ]
  name: 'storageRoleAssignment'
  params: {
    principalId: flexFuncApp.identity.principalId
    principalType: 'ServicePrincipal'
    resourceId: storage.id
    roleDefinitionId: storageRoleDefinitionId
  }
}

output functionAppHostname string = flexFuncApp.properties.defaultHostName
