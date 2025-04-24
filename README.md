# Azure API Management GraphQL Resolver Demo

Welcome! This project demonstrates the **synthetic GraphQL features of Azure API Management (APIM)**. You'll learn how to leverage APIM to expose, secure, and manage GraphQL APIs, including how to use synthetic resolvers to connect your GraphQL schema to backend APIs.

## 🚀 Purpose

The goal of this demo is to showcase how Azure API Management can:

- Import and manage GraphQL schemas.
- Create synthetic resolvers that map GraphQL operations to backend APIs.
- Use Azure Functions as a backend for GraphQL resolvers.
- Provide a secure, scalable, and managed GraphQL endpoint.

## 🗂️ Project Structure

- `/src`: Source code for the Azure Function backend.
- `.gitignore`: Files and folders ignored by Git.
- `README.md`: This guide.

## 🛠️ Prerequisites

- An [Azure account](https://portal.azure.com/)
- [Azure Developer CLI (azd)](https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/install-azd)
- Basic knowledge of GraphQL and Azure API Management

## ⚡ Getting Started

### 1. Clone the Repository

```sh
git clone https://github.com/your-org/apim-graphql-demo.git
cd apim-graphql-demo
```

### 2. Deploy to Azure with Azure Developer CLI

This will provision all required Azure resources, including API Management and the Azure Function backend.

```sh
azd up
```

Follow the prompts to log in and select your Azure subscription.

### 3. Import GraphQL Schema in Azure Portal | [Docs](https://learn.microsoft.com/en-us/azure/api-management/graphql-schema-resolve-api)

1. Go to the [Azure Portal](https://portal.azure.com/).
2. Navigate to your deployed API Management instance.
3. In the APIM blade, select **APIs** > **+ Add API** > **GraphQL**.
4. Import the provided GraphQL schema from the `/src/schema` folder.
5. Set up resolvers for your schema fields, pointing them to the Azure Function backend API deployed in the previous step.
  1. Check the apim-graphql-policy-samples.xml file for examples on how to configure a resolver when dealing with a GET all style REST endpoint vs. one using a parameter in the URI path

### 4. Test Your GraphQL API

- Use the built-in **APIM Test Console** or your favorite GraphQL client (like [Insomnia](https://insomnia.rest/) or [Postman](https://www.postman.com/)) to send queries and mutations to your APIM GraphQL endpoint.

## 📚 Learn More

- [Azure API Management GraphQL Documentation](https://learn.microsoft.com/en-us/azure/api-management/graphql-api)
- [Azure Functions Documentation](https://learn.microsoft.com/en-us/azure/azure-functions/)
- [Azure Developer CLI Documentation](https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/)

---

Feel free to explore, experiment, and extend! If you have questions or suggestions, please open an issue or submit a pull request.
