# Building 'eShop' from Zero to Hero: Lesson 1 – Catalog API with Aspire .NET 9

## 1. eShop app architecture overview

![image](https://github.com/user-attachments/assets/d5f84e4e-a7b6-46ed-b2e9-8cfaea8b5f92)

Here’s a high-level overview of the architecture flow from the diagram:

**Client Apps** (Mobile and Web) communicate with dedicated **Backend for Frontend** (BFF) services tailored to each client

**Microservices** handle core functions (Identity, Catalog, Order, Basket, Payment), each with its own database for isolation and scalability

**Event Bus** enables asynchronous communication between services, enhancing modularity and resilience

**Admin Services** manage webhooks and observability, providing robust monitoring and integration with external systems

**OpenAI Integration** offers potential AI-driven capabilities for personalized experiences or customer support

The GitHub repository includes the full codebase, configuration, and deployment details: https://github.com/dotnet/eShop


## 1. Creating a New Aspire .NET 9 Application in Visual Studio 2022

 
## 2. Renaming Project Structure for Clarity and Organization


## 3. Removing the Default Blazor Web App


## 4. Loading Required NuGet Packages for eShop.AppHost


## 5. Customizing Program.cs in eShop.AppHost


## 6. Create the Catalog.API project folders structure


## 7. Adding Catalog Images to the Catalog.API Project

(Folder: Pics)

## 8. Setting Up Initial Database Data for Catalog.API

(Folder: Setup)

## 9. Creating Data Models and Configuring CatalogOptions in Catalog.API

(Folder: Model, File: CatalogOptions.cs)

## 10. Building the CatalogContext for Data Handling in Catalog.API

(Folder: Infrastructure)

## 11. Implementing Core Services in Catalog.API

(Folder: Services)

## 12. Adding API Endpoints to Catalog.API for Catalog Functionality

(Folder: Apis)

## 13. Configuring Middleware for Catalog.API

## 14. Adding Extensions for Enhanced Functionality in Catalog.API

(Folder: Extensions)

## 15. Setting Up appsettings.json with Database Connection Details

## 16. Running the Application to View Initial Results



