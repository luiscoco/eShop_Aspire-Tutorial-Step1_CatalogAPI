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

![image](https://github.com/user-attachments/assets/209f1b81-3000-45a8-9a92-dcef4b6e32ca)

We also remove the Blazor Web App Service registry in the **Program.cs** (eShop.AppHost project)





## 5. Loading Required NuGet Packages for eShop.AppHost


## 6. Customizing Program.cs in eShop.AppHost


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



