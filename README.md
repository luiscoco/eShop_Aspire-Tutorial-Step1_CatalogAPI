# Building 'eShop' from Zero to Hero: Lesson 1 – Catalog API with Aspire .NET 9

## 1. eShop app architecture overview

The GitHub repository includes the full codebase, configuration, and deployment details: https://github.com/dotnet/eShop

![image](https://github.com/user-attachments/assets/d5f84e4e-a7b6-46ed-b2e9-8cfaea8b5f92)

Here’s a high-level overview of the architecture flow from the diagram:

**Client Apps** (Mobile and Web) communicate with dedicated **Backend for Frontend** (BFF) services tailored to each client

**Microservices** handle core functions (Identity, Catalog, Order, Basket, Payment), each with its own database for isolation and scalability

**Event Bus** enables asynchronous communication between services, enhancing modularity and resilience

**Admin Services** manage webhooks and observability, providing robust monitoring and integration with external systems

**OpenAI Integration** offers potential AI-driven capabilities for personalized experiences or customer support

## 2. Creating a New Aspire .NET 9 Application in Visual Studio 2022

We run Visual Studio 2022 Community Edition and we Create a New Project

![image](https://github.com/user-attachments/assets/63f66e16-bf8d-4f1e-88ab-c782638e2942)

We search for the **aspire** project templates and we select **.NET Aspire 9 Starter App**, and we click on the Next button

![image](https://github.com/user-attachments/assets/e3b0374c-1f3c-4388-ad0f-aa2fe2a0801d)

We input the project name and location

![image](https://github.com/user-attachments/assets/f3d11775-18c7-4c10-a758-19e6d8729eb3)

We select the **.NET 9** Framework and we leave in the other options the default values, and we click on the Create button

![image](https://github.com/user-attachments/assets/6546023a-d73b-42f9-88c5-e4ffa70956df)

We review the project folders and files structure

![image](https://github.com/user-attachments/assets/b6c0dc12-75a8-4286-bad2-3c25871d01ef)

## 3. Renaming Project Structure for Clarity and Organization

We right click on the API project name and we set the new name **Catalog.API**

![image](https://github.com/user-attachments/assets/e7a64bc6-9647-4c4c-9d18-75924747c9c2)

![image](https://github.com/user-attachments/assets/c11693d5-fe73-41ac-8110-f96b73adc8cd)

We also have to close Visual Studio and rename the project folder name

![image](https://github.com/user-attachments/assets/dc06711d-1d9d-46cc-b116-a97637b73ee3)

![image](https://github.com/user-attachments/assets/4132d1d6-2304-4aa8-afd8-6b7b1a367093)

![image](https://github.com/user-attachments/assets/a1196dfc-4d16-4716-9d66-b6da061cc32a)

We confirm the project name was also changed

![image](https://github.com/user-attachments/assets/419b00a3-d033-4708-a540-27e9a3a64b32)

Now we have to change the reference to the project in the Solution file

We edit **eShop.sln** file

![image](https://github.com/user-attachments/assets/b98af45a-b418-496b-bb9e-8cb8dcbd277f)

![image](https://github.com/user-attachments/assets/a48e07e4-881e-496c-92e2-a442400dd4b1)

We introduce the new API project name **Catalog.API**, and we save the file

![image](https://github.com/user-attachments/assets/fd80a70e-2811-4d2d-a23a-919bcd5c3577)

We double click on the Solutoin file and we open it with Visual Studio 2022

![image](https://github.com/user-attachments/assets/5b9e7310-91e4-4268-81e8-cbd64e654ab5)

We have also to change the project reference in the eShop.AppHost project

![image](https://github.com/user-attachments/assets/b38bb46d-775e-447e-80f3-080a3c9d26a4)

We verify the new reference 

![image](https://github.com/user-attachments/assets/efd41854-df73-4136-bc4d-251dbecba642)

## 4. Removing the Default Blazor Web App

We **remove** the **Blazor Web App** project from the eShop Solution

![image](https://github.com/user-attachments/assets/95ed1f41-ebe4-41d1-aafb-5319db952308)

This is the Solution new structure

![image](https://github.com/user-attachments/assets/4e09bef5-b646-4ac0-ad94-be178df3c577)

We double click on the **eShop.AppHost** project and we confirm there is no reference to the **Blazor Web App**

![image](https://github.com/user-attachments/assets/9a99ec0d-c0ea-447d-bf79-25e8a54d52d5)

We also have to edit and modify the **Program.cs** file, in the **eShop.AppHost** project

We have to remove the Blazor Web App project service registry, and also we have to rename the project name for the API

This is my actual **Program.cs** file, in the **eShop.AppHost** project

![image](https://github.com/user-attachments/assets/9d5b67d2-effc-4510-a568-7f3eeb5d5285)

This is the modified/updated content

![image](https://github.com/user-attachments/assets/e9a8eabf-fdbe-45b0-bc7d-b7f3464e1254)

We Clean and Build the application and we confirm there is no error

![image](https://github.com/user-attachments/assets/fabeb6d7-3c20-4683-a299-98bc6f00a072)

We also Run the Application to confirm it properly work

![image](https://github.com/user-attachments/assets/01a0bf55-1701-41c6-865f-bdf9929fcf0c)

![image](https://github.com/user-attachments/assets/629543c8-6957-4f5b-b764-a311af71b430)

## 5. Loading Required NuGet Packages for eShop.AppHost

We right click on the **eShop.AppHost** project and select the menu option **Manage NuGet Packages**

![image](https://github.com/user-attachments/assets/b0c427b2-14c9-43a1-823e-324ac3ae5a62)

We load the **Aspire.Hosting.PostgreSQL** library

![image](https://github.com/user-attachments/assets/4cf60735-cd8a-4a1a-9f43-d1abed573eb4)

![image](https://github.com/user-attachments/assets/6bc525ab-93a5-4ea0-a85b-e2edfa0413a7)

## 6. Customizing Program.cs in eShop.AppHost

With this code we are setting up a **PostgreSQL database** container with a custom image and linking it to a project in a development or testing environment

**Initialize PostgreSQL Container**: we initializes a new PostgreSQL container named "postgres" using the builder object, which manage containerized services for the application

```csharp
var postgres = builder.AddPostgres("postgres")
```

We specify **Docker Image and Version**: specifies the Docker image to use for the PostgreSQL container. In this case, it uses the **ankane/pgvector** image, which is tailored for vector data (useful for machine learning and other complex data queries). We sets the version of the Docker image to the latest available tag

```csharp
.WithImage("ankane/pgvector")
.WithImageTag("latest")
```

**Set Container Lifetime**: we configure the PostgreSQL container to have a persistent lifetime, meaning it will not be recreated each time the application runs

```csharp
.WithLifetime(ContainerLifetime.Persistent);
```

**Add Database to the PostgreSQL Container**: creates a new database within the PostgreSQL container named catalogdb for the application to use

```csharp
var catalogDb = postgres.AddDatabase("catalogdb");
```

**Add Project and Reference the Database**: sets up a project for the Catalog API, presumably an API service in the application. Links the catalogdb database to the catalog-api project, so the API can access and use the PostgreSQL database.

```csharp
var catalogApi = builder.AddProject<Projects.Catalog_API>("catalog-api")
    .WithReference(catalogDb);
```
 
Overall, this code configures a PostgreSQL container with a custom image (pgvector), adds a database (catalogdb), and links it to the catalog-api service for seamless integration and usage

We review the Program.cs (eShop.AppHost project) code:

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithImage("ankane/pgvector")
    .WithImageTag("latest")
    .WithLifetime(ContainerLifetime.Persistent);

var catalogDb = postgres.AddDatabase("catalogdb");

var catalogApi = builder.AddProject<Projects.Catalog_API>("catalog-api")
    .WithReference(catalogDb);

builder.Build().Run();
```

## 7. Create the Catalog.API project folders structure


## 8. Adding Catalog Images to the Catalog.API Project

(Folder: Pics)

## 9. Setting Up Initial Database Data for Catalog.API

(Folder: Setup)

## 10. Creating Data Models and Configuring CatalogOptions in Catalog.API

(Folder: Model, File: CatalogOptions.cs)

## 11. Building the CatalogContext for Data Handling in Catalog.API

(Folder: Infrastructure)

## 12. Implementing Core Services in Catalog.API

(Folder: Services)

## 13. Adding API Endpoints to Catalog.API for Catalog Functionality

(Folder: Apis)

## 14. Configuring Middleware for Catalog.API

## 15. Adding Extensions for Enhanced Functionality in Catalog.API

(Folder: Extensions)

## 16. Setting Up appsettings.json with Database Connection Details

## 17. Running the Application to View Initial Results



