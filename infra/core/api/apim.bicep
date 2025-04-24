@description('The SKU of the API Management instance')
@allowed([
  'Developer'
  'BasicV2'
  'StandardV2'
  'Premium'
])
param sku string = 'Developer'

param apimInstanceName string = 'apimg-graphql-demo'

@description('The location of the API Management instance')
param location string

param tags object

resource apim 'Microsoft.ApiManagement/service@2021-08-01' = {
  name: apimInstanceName
  location: location
  tags: tags
  sku: {
    name: sku
    capacity: 1
  }
  properties: {
    publisherEmail: 'admin@example.com'
    publisherName: 'Contoso'
  }
}

output id string = apim.id
output name string = apim.name
