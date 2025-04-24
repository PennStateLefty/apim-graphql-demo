echo "Loading azd .env file from current environment"

# Use the `get-values` azd command to retrieve environment variables from the `.env` file
while IFS='=' read -r key value; do
    value=$(echo "$value" | sed 's/^"//' | sed 's/"$//')
    export "$key=$value"
done <<EOF
$(azd env get-values) 
EOF

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_ROOT="$SCRIPT_DIR/.."

echo "Creating the GraphQL API"
az apim api import \
    --resource-group "$AZURE_RESOURCE_GROUP" \
    --service-name "$AZURE_APIM_NAME" \
    --api-id "mock-graphql-api" \
    --path "graphql" \
    --specification-format GraphQL \
    --specification-path "$PROJECT_ROOT/mock-workday-schema.graphql" \
    --display-name "Mock Workday GraphQL API"