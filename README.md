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

![image](https://github.com/user-attachments/assets/ed86891c-a04e-4868-8c78-e54cd24e0a4a)

## 7. Add the Catalog.API project Nuget packages

![image](https://github.com/user-attachments/assets/fc3d9db2-73f8-4134-8afa-169e8754890b)

**IMPORTANT NOTE**: It is advisable to first install these two packages:

Aspire.Npgsql.EntityFrameworkCore.PostgreSQL

Npgsql.EntityFrameworkCore.PostgreSQL

### 7.1. Asp.Versioning.Http

This library is typically part of ASP.NET Core's API versioning tools. It helps developers **version their HTTP APIs**, allowing clients to interact with different versions of an API endpoint, useful for maintaining backward compatibility while evolving the API

### 7.2. Aspire.Azure.AI.OpenAI

Likely part of the Aspire framework, this package is designed to interact with **Azure's AI services**, particularly those that provide **OpenAI's language models**. It enables integration with OpenAI models deployed on Azure for tasks like natural language processing, code generation, and content creation

### 7.3. Aspire.Npgsql.EntityFrameworkCore.PostgreSQL

This package would provide support for using **Npgsql (a PostgreSQL data provider for .NET)** in the Aspire framework, specifically in Entity Framework Core. It allows developers to work with PostgreSQL databases in .NET applications using **ORM features provided by Entity Framework Core**

### 7.4. Microsoft.EntityFrameworkCore.Tools

A set of command-line tools for Entity Framework Core, this package assists developers in **managing database migrations**, updating schemas, and generating code models for their databases. It simplifies database management and schema evolution for .NET Core applications

### 7.5. Microsoft.Extensions.AI

Part of the Microsoft.Extensions namespace, this package likely provides common extensions for working with **AI services**, focusing on ease of integration and dependency injection for AI-related services in .NET applications

### 7.6. Microsoft.Extensions.AI.Ollama

This library allows **integration with Ollama**, a platform providing access to various machine learning models. It includes configuration and dependency injection utilities, streamlining the use of Ollama's models within .NET applications

### 7.7. Microsoft.Extensions.AI.OpenAI

A library to integrate OpenAI models directly into .NET applications. It provides configuration and extension methods to connect with **OpenAI's API**, making it easier to use models like GPT and DALL-E for natural language processing and other AI-driven features

### 7.8. Npgsql.EntityFrameworkCore.PostgreSQL

An Entity Framework Core provider for **PostgreSQL**, allowing .NET applications to interact with PostgreSQL databases via Npgsql. It supports **LINQ, migrations, and various Entity Framework Core features**, tailored for PostgreSQL

### 7.9. Pgvector

Pgvector is an extension for PostgreSQL that adds support for vector data types. It's especially useful for applications in machine learning and AI, where you may need to **store embeddings** or feature **vectors** for similarity searches and recommendations

### 7.10. Pgvector.EntityFrameworkCore

This package adds Entity Framework Core support for Pgvector, enabling .NET applications to work with **vector data in PostgreSQL databases** seamlessly. It allows developers to perform vector operations in code and store embeddings or feature vectors directly

These libraries collectively support various functions, from AI integration to database management, enabling developers to build robust, AI-driven, and database-backed applications in .NET.

## 8. Create the Catalog.API project folders structure

We create these folder inside the Catalog.API project: Apis, Extensions, Infrastructure, Model, Pics, Services and Setup

![image](https://github.com/user-attachments/assets/a65a12a7-3398-4e1d-97ff-14505ff58fd2)

## 9. Adding Catalog Images to the Catalog.API Project

(Folder: Pics)

Inside the **Pics** folder we include the Catalog **WebP** images (101 files)

The **WebP** image file format is a modern image format developed by Google to optimize web images by providing high-quality visuals with smaller file sizes compared to traditional formats like JPEG and PNG

**WebP** achieves this by using both lossless and lossy compression, making it highly versatile for various web use cases where load time and bandwidth are important considerations

![image](https://github.com/user-attachments/assets/274f8225-636b-47c9-aa3d-75e1203c3dc1)

## 10. Setting Up Initial Database Data for Catalog.API

(Folder: Setup)

Inside the **Setup** folder we include the **catalog.json** file for Catalog database initialization

![image](https://github.com/user-attachments/assets/4e34f0b9-6e1a-4131-9991-96fd065ca854)

If we double click on the **catalog.json** file we can review the content

![image](https://github.com/user-attachments/assets/4f41bf69-bc17-4d63-9ec4-ece1600a3524)

## 11. Creating Data Models and Configuring CatalogOptions in Catalog.API

(Folder: Model, File: CatalogOptions.cs)

We define the API data models in the following files:

![image](https://github.com/user-attachments/assets/1e7c248e-4667-4f68-82d1-f4f527dc3db4)

We review in detail the code:

**CatalogBrand.cs**

```csharp
using System.ComponentModel.DataAnnotations;

namespace eShop.Catalog.API.Model;

public class CatalogBrand
{
    public int Id { get; set; }

    [Required]
    public string Brand { get; set; }
}
```

**CatalogItem.cs**

```csharp
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Pgvector;

namespace eShop.Catalog.API.Model;

public class CatalogItem
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string PictureFileName { get; set; }

    public int CatalogTypeId { get; set; }

    public CatalogType CatalogType { get; set; }

    public int CatalogBrandId { get; set; }

    public CatalogBrand CatalogBrand { get; set; }

    // Quantity in stock
    public int AvailableStock { get; set; }

    // Available stock at which we should reorder
    public int RestockThreshold { get; set; }


    // Maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses)
    public int MaxStockThreshold { get; set; }

    /// <summary>Optional embedding for the catalog item's description.</summary>
    [JsonIgnore]
    public Vector Embedding { get; set; }

    /// <summary>
    /// True if item is on reorder
    /// </summary>
    public bool OnReorder { get; set; }

    public CatalogItem() { }

    /// <summary>
    /// Decrements the quantity of a particular item in inventory and ensures the restockThreshold hasn't
    /// been breached. If so, a RestockRequest is generated in CheckThreshold. 
    /// 
    /// If there is sufficient stock of an item, then the integer returned at the end of this call should be the same as quantityDesired. 
    /// In the event that there is not sufficient stock available, the method will remove whatever stock is available and return that quantity to the client.
    /// In this case, it is the responsibility of the client to determine if the amount that is returned is the same as quantityDesired.
    /// It is invalid to pass in a negative number. 
    /// </summary>
    /// <param name="quantityDesired"></param>
    /// <returns>int: Returns the number actually removed from stock. </returns>
    /// 
    public int RemoveStock(int quantityDesired)
    {
        if (AvailableStock == 0)
        {
            throw new CatalogDomainException($"Empty stock, product item {Name} is sold out");
        }

        if (quantityDesired <= 0)
        {
            throw new CatalogDomainException($"Item units desired should be greater than zero");
        }

        int removed = Math.Min(quantityDesired, this.AvailableStock);

        this.AvailableStock -= removed;

        return removed;
    }

    /// <summary>
    /// Increments the quantity of a particular item in inventory.
    /// <param name="quantity"></param>
    /// <returns>int: Returns the quantity that has been added to stock</returns>
    /// </summary>
    public int AddStock(int quantity)
    {
        int original = this.AvailableStock;

        // The quantity that the client is trying to add to stock is greater than what can be physically accommodated in the Warehouse
        if ((this.AvailableStock + quantity) > this.MaxStockThreshold)
        {
            // For now, this method only adds new units up maximum stock threshold. In an expanded version of this application, we
            //could include tracking for the remaining units and store information about overstock elsewhere. 
            this.AvailableStock += (this.MaxStockThreshold - this.AvailableStock);
        }
        else
        {
            this.AvailableStock += quantity;
        }

        this.OnReorder = false;

        return this.AvailableStock - original;
    }
}
```

**CatalogServices**

```csharp
using eShop.Catalog.API.Services;

public class CatalogServices(
    CatalogContext context,
    ICatalogAI catalogAI,
    IOptions<CatalogOptions> options,
    ILogger<CatalogServices> logger,
    ICatalogIntegrationEventService eventService)
{
    public CatalogContext Context { get; } = context;
    public ICatalogAI CatalogAI { get; } = catalogAI;
    public IOptions<CatalogOptions> Options { get; } = options;
    public ILogger<CatalogServices> Logger { get; } = logger;
    //public ICatalogIntegrationEventService EventService { get; } = eventService;
};
```

**IMPORTANT NOTE**: pay attention we comment these lines not in the scope of this examples, because ther are related to Events.

```csharp
ICatalogIntegrationEventService eventService
```

```csharp
//public ICatalogIntegrationEventService EventService { get; } = eventService;
```

**CatalogType.cs**

```csharp
using System.ComponentModel.DataAnnotations;

namespace eShop.Catalog.API.Model;

public class CatalogType
{
    public int Id { get; set; }

    [Required]
    public string Type { get; set; }
}
```

**PaginatedItems.cs**

```csharp
using System.Text.Json.Serialization;

namespace eShop.Catalog.API.Model;

public class PaginatedItems<TEntity>(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data) where TEntity : class
{
    public int PageIndex { get; } = pageIndex;

    public int PageSize { get; } = pageSize;

    public long Count { get; } = count;

    public IEnumerable<TEntity> Data { get;} = data;
}
```

**PaginationRequest.cs**

```csharp
namespace eShop.Catalog.API.Model;

public record PaginationRequest(int PageSize = 10, int PageIndex = 0);
```

## 12. Building the CatalogContext for Data Handling in Catalog.API

(Folder: Infrastructure)

We first have to create two folders inside the database Infrastructure folder

![image](https://github.com/user-attachments/assets/66e8317b-2514-4470-947a-c925655ed4b3)

### 12.1. Define the DbContext file

![image](https://github.com/user-attachments/assets/a10bc277-627f-4b9d-941b-aacc766e4533)

The **CatalogContext** class is inherited from the DbContext, and defines a **database context** for an **Entity Framework Core (EF Core)** application

We declare **three tables** in the database: 

**CatalogItems**: Represents a table for CatalogItem entities in the database

**CatalogBrands**: Represents a table for CatalogBrand entities

**CatalogTypes**: Represents a table for CatalogType entities. These DbSet properties allow querying and saving instances of these entity types

**builder.HasPostgresExtension("vector")**: Indicates that the database uses a PostgreSQL extension for **handling vector data**

**builder.ApplyConfiguration(...)**: This applies configurations for each Entity Framwork Entity Type, which would define specific **settings for those tables** (like column names, constraints, etc.).

**CatalogContext.cs**

```csharp
using eShop.Catalog.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options, IConfiguration configuration) : base(options)
        {
        }

        public required DbSet<CatalogItem> CatalogItems { get; set; }
        public required DbSet<CatalogBrand> CatalogBrands { get; set; }
        public required DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("vector");
            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());

            // Add the outbox table to this context
            //builder.UseIntegrationEventLogs();
        }
    }
}
```

### 12.2. Mapping "CatalogBrand" EntityFramwork Entity to the "CatalogBrand" Database Table

The CatalogBrandEntityTypeConfiguration class, which configures the **mapping of the CatalogBrand entity** to the **database table CatalogBrand** in Entity Framework Core

![image](https://github.com/user-attachments/assets/4ae228d9-21dc-4f9e-b92e-550b1fadade7)

**CatalogBrandEntityTypeConfiguration.cs**

```csharp
using eShop.Catalog.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Catalog.API.Infrastructure.EntityConfigurations;

class CatalogBrandEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogBrand>
{
    public void Configure(EntityTypeBuilder<CatalogBrand> builder)
    {
        builder.ToTable("CatalogBrand");

        builder.Property(cb => cb.Brand)
            .HasMaxLength(100);
    }
}
```

### 12.3. Mapping "Item" EntityFramwork Entity to the "Item" Database Table

The CatalogItemEntityTypeConfiguration class, which configures the **mapping of the Item entity** to the **database table Item** in Entity Framework Core

![image](https://github.com/user-attachments/assets/175af625-1430-43ca-ad50-a9a2daa1ac2b)

**CatalogItemEntityTypeConfiguration.cs**

```csharp
using eShop.Catalog.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Catalog.API.Infrastructure.EntityConfigurations;

class CatalogItemEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        builder.ToTable("Catalog");

        builder.Property(ci => ci.Name)
            .HasMaxLength(50);

        builder.Property(ci => ci.Embedding)
            .HasColumnType("vector(384)");

        builder.HasOne(ci => ci.CatalogBrand)
            .WithMany();

        builder.HasOne(ci => ci.CatalogType)
            .WithMany();

        builder.HasIndex(ci => ci.Name);
    }
}
```

### 12.4. Mapping "Type" EntityFramwork Entity to the "Type" Database Table

The CatalogTypeEntityTypeConfiguration class, which configures the **mapping of the Type entity** to the **database table Type** in Entity Framework Core

![image](https://github.com/user-attachments/assets/ae66f477-7518-4819-9835-5c25eb2a7a72)

**CatalogTypeEntityTypeConfiguration.cs**

```csharp
using eShop.Catalog.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Catalog.API.Infrastructure.EntityConfigurations;

class CatalogTypeEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogType>
{
    public void Configure(EntityTypeBuilder<CatalogType> builder)
    {
        builder.ToTable("CatalogType");

        builder.Property(cb => cb.Type)
            .HasMaxLength(100);
    }
}
```

## 12.5. Define the Exceptions

![image](https://github.com/user-attachments/assets/e2fe74ba-b6d4-4397-9f4d-bb4efd51bfd4)

```csharp
namespace eShop.Catalog.API.Infrastructure.Exceptions;

/// <summary>
/// Exception type for app exceptions
/// </summary>
public class CatalogDomainException : Exception
{
    public CatalogDomainException()
    { }

    public CatalogDomainException(string message)
        : base(message)
    { }

    public CatalogDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
```

### 12.6. Define the class to seed initial data into the Catalog database

This C# code is a CatalogContextSeed class, part of the eShop.Catalog.API project, designed to **seed initial data into a catalog database**

This code **initializes a product catalog** by:

- Loading data from a JSON file

- Inserting unique brands, types, and items into the database

- Optionally generating AI embeddings for catalog items if AI support is enabled. The seeding process is logged, helping track how many brands, types, and items were added

![image](https://github.com/user-attachments/assets/33214cfc-733e-45f0-94ee-f79051e53a94)

```csharp
using System.Text.Json;
using eShop.Catalog.API.Services;
using Pgvector;

namespace eShop.Catalog.API.Infrastructure;

public partial class CatalogContextSeed(
    IWebHostEnvironment env,
    IOptions<CatalogOptions> settings,
    ICatalogAI catalogAI,
    ILogger<CatalogContextSeed> logger) : IDbSeeder<CatalogContext>
{
    public async Task SeedAsync(CatalogContext context)
    {
        var useCustomizationData = settings.Value.UseCustomizationData;
        var contentRootPath = env.ContentRootPath;
        var picturePath = env.WebRootPath;

        // Workaround from https://github.com/npgsql/efcore.pg/issues/292#issuecomment-388608426
        context.Database.OpenConnection();
        ((NpgsqlConnection)context.Database.GetDbConnection()).ReloadTypes();

        if (!context.CatalogItems.Any())
        {
            var sourcePath = Path.Combine(contentRootPath, "Setup", "catalog.json");
            var sourceJson = File.ReadAllText(sourcePath);
            var sourceItems = JsonSerializer.Deserialize<CatalogSourceEntry[]>(sourceJson);

            context.CatalogBrands.RemoveRange(context.CatalogBrands);
            await context.CatalogBrands.AddRangeAsync(sourceItems.Select(x => x.Brand).Distinct()
                .Select(brandName => new CatalogBrand { Brand = brandName }));
            logger.LogInformation("Seeded catalog with {NumBrands} brands", context.CatalogBrands.Count());

            context.CatalogTypes.RemoveRange(context.CatalogTypes);
            await context.CatalogTypes.AddRangeAsync(sourceItems.Select(x => x.Type).Distinct()
                .Select(typeName => new CatalogType { Type = typeName }));
            logger.LogInformation("Seeded catalog with {NumTypes} types", context.CatalogTypes.Count());

            await context.SaveChangesAsync();

            var brandIdsByName = await context.CatalogBrands.ToDictionaryAsync(x => x.Brand, x => x.Id);
            var typeIdsByName = await context.CatalogTypes.ToDictionaryAsync(x => x.Type, x => x.Id);

            var catalogItems = sourceItems.Select(source => new CatalogItem
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                CatalogBrandId = brandIdsByName[source.Brand],
                CatalogTypeId = typeIdsByName[source.Type],
                AvailableStock = 100,
                MaxStockThreshold = 200,
                RestockThreshold = 10,
                PictureFileName = $"{source.Id}.webp",
            }).ToArray();

            if (catalogAI.IsEnabled)
            {
                logger.LogInformation("Generating {NumItems} embeddings", catalogItems.Length);
                IReadOnlyList<Vector> embeddings = await catalogAI.GetEmbeddingsAsync(catalogItems);
                for (int i = 0; i < catalogItems.Length; i++)
                {
                    catalogItems[i].Embedding = embeddings[i];
                }
            }

            await context.CatalogItems.AddRangeAsync(catalogItems);
            logger.LogInformation("Seeded catalog with {NumItems} items", context.CatalogItems.Count());
            await context.SaveChangesAsync();
        }
    }

    private class CatalogSourceEntry
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
```

## 13. Implementing Core Services in Catalog.API

(Folder: Services)

These code include these main functionalities:

- Gets whether the AI system is enabled

- Gets an embedding vector for the specified text

- Gets an embedding vector for the specified catalog item

- Gets embedding vectors for the specified catalog items

![image](https://github.com/user-attachments/assets/010a6202-9f87-4343-ac8a-a0ff9eb2fb1e)

**ICatalogAI.cs**

```csharp
using Pgvector;

namespace eShop.Catalog.API.Services;

public interface ICatalogAI
{
    /// <summary>Gets whether the AI system is enabled.</summary>
    bool IsEnabled { get; }

    /// <summary>Gets an embedding vector for the specified text.</summary>
    ValueTask<Vector> GetEmbeddingAsync(string text);
    
    /// <summary>Gets an embedding vector for the specified catalog item.</summary>
    ValueTask<Vector> GetEmbeddingAsync(CatalogItem item);

    /// <summary>Gets embedding vectors for the specified catalog items.</summary>
    ValueTask<IReadOnlyList<Vector>> GetEmbeddingsAsync(IEnumerable<CatalogItem> item);
}
```

**CatalogAI.cs**

```csharp
using System.Diagnostics;
using Microsoft.Extensions.AI;
using Pgvector;

namespace eShop.Catalog.API.Services;

public sealed class CatalogAI : ICatalogAI
{
    private const int EmbeddingDimensions = 384;
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embeddingGenerator;

    /// <summary>The web host environment.</summary>
    private readonly IWebHostEnvironment _environment;
    /// <summary>Logger for use in AI operations.</summary>
    private readonly ILogger _logger;

    public CatalogAI(IWebHostEnvironment environment, ILogger<CatalogAI> logger, IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator = null)
    {
        _embeddingGenerator = embeddingGenerator;
        _environment = environment;
        _logger = logger;
    }

    /// <inheritdoc/>
    public bool IsEnabled => _embeddingGenerator is not null;

    /// <inheritdoc/>
    public ValueTask<Vector> GetEmbeddingAsync(CatalogItem item) =>
        IsEnabled ?
            GetEmbeddingAsync(CatalogItemToString(item)) :
            ValueTask.FromResult<Vector>(null);

    /// <inheritdoc/>
    public async ValueTask<IReadOnlyList<Vector>> GetEmbeddingsAsync(IEnumerable<CatalogItem> items)
    {
        if (IsEnabled)
        {
            long timestamp = Stopwatch.GetTimestamp();

            GeneratedEmbeddings<Embedding<float>> embeddings = await _embeddingGenerator.GenerateAsync(items.Select(CatalogItemToString));
            var results = embeddings.Select(m => new Vector(m.Vector[0..EmbeddingDimensions])).ToList();

            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace("Generated {EmbeddingsCount} embeddings in {ElapsedMilliseconds}s", results.Count, Stopwatch.GetElapsedTime(timestamp).TotalSeconds);
            }

            return results;
        }

        return null;
    }

    /// <inheritdoc/>
    public async ValueTask<Vector> GetEmbeddingAsync(string text)
    {
        if (IsEnabled)
        {
            long timestamp = Stopwatch.GetTimestamp();

            //var embedding = (await _embeddingGenerator.GenerateAsync(text))[0].Vector;
            var embedding = (await _embeddingGenerator.GenerateAsync(new[] { text }))[0].Vector;
            embedding = embedding[0..EmbeddingDimensions];

            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace("Generated embedding in {ElapsedMilliseconds}s: '{Text}'", Stopwatch.GetElapsedTime(timestamp).TotalSeconds, text);
            }

            return new Vector(embedding);
        }

        return null;
    }

    private static string CatalogItemToString(CatalogItem item) => $"{item.Name} {item.Description}";
}
```

**IMPORTANT NOTE**: We fixed and error in the **CatalogAI.cs** file

In this line we get an error **"Argument 1: cannot convert from 'string' to 'System.Collections.Generic.IEnumerable<string>'"**

```csharp
var embedding = (await _embeddingGenerator.GenerateAsync(text))[0].Vector;
```

We replace that line with this new code:

```csharp
var embedding = (await _embeddingGenerator.GenerateAsync(new[] { text }))[0].Vector;
```

## 14. Adding API Endpoints to Catalog.API for Catalog Functionality

(Folder: Apis)

This code defines a static CatalogApi class within an ASP.NET Core application for an e-commerce catalog service

The class contains **RESTful API endpoint** mappings and methods that handle requests to retrieve, update, create, and delete catalog items (**CRUD operations**)

**Namespace and Libraries**:

**Microsoft.AspNetCore.Http.HttpResults and Pgvector.EntityFrameworkCore**: These libraries support HTTP responses and PostgreSQL vector operations (e.g., for AI-powered similarity searching)

**namespace eShop.Catalog.API**: Encapsulates the API within the eShop catalog context

**MapCatalogApiV1 Method**: This method registers all API routes for version 1.0 under the base path "api/catalog"

**Routes are grouped by function**:

**Retrieving Items**: Standard item retrieval (GetAllItems, GetItemsByIds, GetItemById, etc.), semantic relevance search using AI embeddings, and retrieval by type and brand

**Modifying Items**: Endpoints for updating (UpdateItem), creating (CreateItem), and deleting items (DeleteItemById)

**Query Methods**:

**GetAllItems**: Returns a paginated list of catalog items

**GetItemsByIds, GetItemById, GetItemsByName**: Fetch items by specific criteria such as ID, name, or list of IDs

**AI-Powered Search**: GetItemsBySemanticRelevance uses an AI embedding service to find items with semantic relevance to a search term

**GetItemPictureById**: Returns the picture file for a specific catalog item

**Modification Methods**:

**Updating an Item**: UpdateItem updates an item in the catalog and may trigger an integration event if the price changes

**Creating an Item**: CreateItem adds a new catalog item and stores an AI-generated embedding for future semantic searches

**Deleting an Item**: DeleteItemById deletes an item by its ID

**Helper Methods**:

**GetImageMimeTypeFromImageFileExtension**: Returns MIME type for an image file based on its extension

**GetFullPath**: Constructs the full file path for an image based on the app's root directory

**Special Features**

**AI Integration**: AI embeddings are used for semantic searches, which help find items relevant to a given text description by comparing vectors

**Pagination Support**: Several endpoints support paginated results using a PaginationRequest parameter, allowing for efficient browsing of large catalogs

**Event-Driven Architecture**: For price changes in UpdateItem, an integration event (ProductPriceChangedIntegrationEvent) is generated and published, supporting reactive integration with other services

This setup enables a rich catalog API with a mix of traditional **CRUD** operations and **AI-enhanced search**, making it well-suited for modern e-commerce applications

![image](https://github.com/user-attachments/assets/26d63124-5ac2-4866-a978-7d36c9e21c1b)

**CatalogApi.cs**

```csharp
using Microsoft.AspNetCore.Http.HttpResults;
using Pgvector.EntityFrameworkCore;

namespace eShop.Catalog.API;

public static class CatalogApi
{
    public static IEndpointRouteBuilder MapCatalogApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/catalog").HasApiVersion(1.0);

        // Routes for querying catalog items.
        api.MapGet("/items", GetAllItems);
        api.MapGet("/items/by", GetItemsByIds);
        api.MapGet("/items/{id:int}", GetItemById);
        api.MapGet("/items/by/{name:minlength(1)}", GetItemsByName);
        api.MapGet("/items/{catalogItemId:int}/pic", GetItemPictureById);

        // Routes for resolving catalog items using AI.
        api.MapGet("/items/withsemanticrelevance/{text:minlength(1)}", GetItemsBySemanticRelevance);

        // Routes for resolving catalog items by type and brand.
        api.MapGet("/items/type/{typeId}/brand/{brandId?}", GetItemsByBrandAndTypeId);
        api.MapGet("/items/type/all/brand/{brandId:int?}", GetItemsByBrandId);
        api.MapGet("/catalogtypes", async (CatalogContext context) => await context.CatalogTypes.OrderBy(x => x.Type).ToListAsync());
        api.MapGet("/catalogbrands", async (CatalogContext context) => await context.CatalogBrands.OrderBy(x => x.Brand).ToListAsync());

        // Routes for modifying catalog items.
        api.MapPut("/items", UpdateItem);
        api.MapPost("/items", CreateItem);
        api.MapDelete("/items/{id:int}", DeleteItemById);

        return app;
    }

    public static async Task<Results<Ok<PaginatedItems<CatalogItem>>, BadRequest<string>>> GetAllItems(
        [AsParameters] PaginationRequest paginationRequest,
        [AsParameters] CatalogServices services)
    {
        var pageSize = paginationRequest.PageSize;
        var pageIndex = paginationRequest.PageIndex;

        var totalItems = await services.Context.CatalogItems
            .LongCountAsync();

        var itemsOnPage = await services.Context.CatalogItems
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return TypedResults.Ok(new PaginatedItems<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage));
    }

    public static async Task<Ok<List<CatalogItem>>> GetItemsByIds(
        [AsParameters] CatalogServices services,
        int[] ids)
    {
        var items = await services.Context.CatalogItems.Where(item => ids.Contains(item.Id)).ToListAsync();
        return TypedResults.Ok(items);
    }

    public static async Task<Results<Ok<CatalogItem>, NotFound, BadRequest<string>>> GetItemById(
        [AsParameters] CatalogServices services,
        int id)
    {
        if (id <= 0)
        {
            return TypedResults.BadRequest("Id is not valid.");
        }

        var item = await services.Context.CatalogItems.Include(ci => ci.CatalogBrand).SingleOrDefaultAsync(ci => ci.Id == id);

        if (item == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(item);
    }

    public static async Task<Ok<PaginatedItems<CatalogItem>>> GetItemsByName(
        [AsParameters] PaginationRequest paginationRequest,
        [AsParameters] CatalogServices services,
        string name)
    {
        var pageSize = paginationRequest.PageSize;
        var pageIndex = paginationRequest.PageIndex;

        var totalItems = await services.Context.CatalogItems
            .Where(c => c.Name.StartsWith(name))
            .LongCountAsync();

        var itemsOnPage = await services.Context.CatalogItems
            .Where(c => c.Name.StartsWith(name))
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return TypedResults.Ok(new PaginatedItems<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage));
    }

    public static async Task<Results<NotFound, PhysicalFileHttpResult>> GetItemPictureById(CatalogContext context, IWebHostEnvironment environment, int catalogItemId)
    {
        var item = await context.CatalogItems.FindAsync(catalogItemId);

        if (item is null)
        {
            return TypedResults.NotFound();
        }

        var path = GetFullPath(environment.ContentRootPath, item.PictureFileName);

        string imageFileExtension = Path.GetExtension(item.PictureFileName);
        string mimetype = GetImageMimeTypeFromImageFileExtension(imageFileExtension);
        DateTime lastModified = File.GetLastWriteTimeUtc(path);

        return TypedResults.PhysicalFile(path, mimetype, lastModified: lastModified);
    }

    public static async Task<Results<BadRequest<string>, RedirectToRouteHttpResult, Ok<PaginatedItems<CatalogItem>>>> GetItemsBySemanticRelevance(
        [AsParameters] PaginationRequest paginationRequest,
        [AsParameters] CatalogServices services,
        string text)
    {
        var pageSize = paginationRequest.PageSize;
        var pageIndex = paginationRequest.PageIndex;

        if (!services.CatalogAI.IsEnabled)
        {
            return await GetItemsByName(paginationRequest, services, text);
        }

        // Create an embedding for the input search
        var vector = await services.CatalogAI.GetEmbeddingAsync(text);

        // Get the total number of items
        var totalItems = await services.Context.CatalogItems
            .LongCountAsync();

        // Get the next page of items, ordered by most similar (smallest distance) to the input search
        List<CatalogItem> itemsOnPage;
        if (services.Logger.IsEnabled(LogLevel.Debug))
        {
            var itemsWithDistance = await services.Context.CatalogItems
                .Select(c => new { Item = c, Distance = c.Embedding.CosineDistance(vector) })
                .OrderBy(c => c.Distance)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            services.Logger.LogDebug("Results from {text}: {results}", text, string.Join(", ", itemsWithDistance.Select(i => $"{i.Item.Name} => {i.Distance}")));

            itemsOnPage = itemsWithDistance.Select(i => i.Item).ToList();
        }
        else
        {
            itemsOnPage = await services.Context.CatalogItems
                .OrderBy(c => c.Embedding.CosineDistance(vector))
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
        }

        return TypedResults.Ok(new PaginatedItems<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage));
    }

    public static async Task<Ok<PaginatedItems<CatalogItem>>> GetItemsByBrandAndTypeId(
        [AsParameters] PaginationRequest paginationRequest,
        [AsParameters] CatalogServices services,
        int typeId,
        int? brandId)
    {
        var pageSize = paginationRequest.PageSize;
        var pageIndex = paginationRequest.PageIndex;

        var root = (IQueryable<CatalogItem>)services.Context.CatalogItems;
        root = root.Where(c => c.CatalogTypeId == typeId);
        if (brandId is not null)
        {
            root = root.Where(c => c.CatalogBrandId == brandId);
        }

        var totalItems = await root
            .LongCountAsync();

        var itemsOnPage = await root
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return TypedResults.Ok(new PaginatedItems<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage));
    }

    public static async Task<Ok<PaginatedItems<CatalogItem>>> GetItemsByBrandId(
        [AsParameters] PaginationRequest paginationRequest,
        [AsParameters] CatalogServices services,
        int? brandId)
    {
        var pageSize = paginationRequest.PageSize;
        var pageIndex = paginationRequest.PageIndex;

        var root = (IQueryable<CatalogItem>)services.Context.CatalogItems;

        if (brandId is not null)
        {
            root = root.Where(ci => ci.CatalogBrandId == brandId);
        }

        var totalItems = await root
            .LongCountAsync();

        var itemsOnPage = await root
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return TypedResults.Ok(new PaginatedItems<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage));
    }

    public static async Task<Results<Created, NotFound<string>>> UpdateItem(
        [AsParameters] CatalogServices services,
        CatalogItem productToUpdate)
    {
        var catalogItem = await services.Context.CatalogItems.SingleOrDefaultAsync(i => i.Id == productToUpdate.Id);

        if (catalogItem == null)
        {
            return TypedResults.NotFound($"Item with id {productToUpdate.Id} not found.");
        }

        // Update current product
        var catalogEntry = services.Context.Entry(catalogItem);
        catalogEntry.CurrentValues.SetValues(productToUpdate);

        catalogItem.Embedding = await services.CatalogAI.GetEmbeddingAsync(catalogItem);

        var priceEntry = catalogEntry.Property(i => i.Price);

        if (priceEntry.IsModified) // Save product's data and publish integration event through the Event Bus if price has changed
        {
            //Create Integration Event to be published through the Event Bus
            var priceChangedEvent = new ProductPriceChangedIntegrationEvent(catalogItem.Id, productToUpdate.Price, priceEntry.OriginalValue);

            // Achieving atomicity between original Catalog database operation and the IntegrationEventLog thanks to a local transaction
            await services.EventService.SaveEventAndCatalogContextChangesAsync(priceChangedEvent);

            // Publish through the Event Bus and mark the saved event as published
            await services.EventService.PublishThroughEventBusAsync(priceChangedEvent);
        }
        else // Just save the updated product because the Product's Price hasn't changed.
        {
            await services.Context.SaveChangesAsync();
        }
        return TypedResults.Created($"/api/catalog/items/{productToUpdate.Id}");
    }

    public static async Task<Created> CreateItem(
        [AsParameters] CatalogServices services,
        CatalogItem product)
    {
        var item = new CatalogItem
        {
            Id = product.Id,
            CatalogBrandId = product.CatalogBrandId,
            CatalogTypeId = product.CatalogTypeId,
            Description = product.Description,
            Name = product.Name,
            PictureFileName = product.PictureFileName,
            Price = product.Price,
            AvailableStock = product.AvailableStock,
            RestockThreshold = product.RestockThreshold,
            MaxStockThreshold = product.MaxStockThreshold
        };
        item.Embedding = await services.CatalogAI.GetEmbeddingAsync(item);

        services.Context.CatalogItems.Add(item);
        await services.Context.SaveChangesAsync();

        return TypedResults.Created($"/api/catalog/items/{item.Id}");
    }

    public static async Task<Results<NoContent, NotFound>> DeleteItemById(
        [AsParameters] CatalogServices services,
        int id)
    {
        var item = services.Context.CatalogItems.SingleOrDefault(x => x.Id == id);

        if (item is null)
        {
            return TypedResults.NotFound();
        }

        services.Context.CatalogItems.Remove(item);
        await services.Context.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    private static string GetImageMimeTypeFromImageFileExtension(string extension) => extension switch
    {
        ".png" => "image/png",
        ".gif" => "image/gif",
        ".jpg" or ".jpeg" => "image/jpeg",
        ".bmp" => "image/bmp",
        ".tiff" => "image/tiff",
        ".wmf" => "image/wmf",
        ".jp2" => "image/jp2",
        ".svg" => "image/svg+xml",
        ".webp" => "image/webp",
        _ => "application/octet-stream",
    };

    public static string GetFullPath(string contentRootPath, string pictureFileName) =>
        Path.Combine(contentRootPath, "Pics", pictureFileName);
}
```

## 15. Configuring Middleware (Program.cs) for Catalog.API

This code sets up an ASP.NET Core application, configuring services and middleware needed for handling requests

It includes structured error handling, optional API versioning, and OpenAPI documentation (although currently commented out)

The code is organized to keep service configuration flexible and allows for modular API versioning and OpenAPI support if needed in the future

**Code explanation**:

This line initializes the application’s builder object with configuration and dependency injection services. It sets up the necessary infrastructure for building the web app

```csharp
var builder = WebApplication.CreateBuilder(args);
```

Presumably, this method configures some default services for the application. The actual implementation of AddServiceDefaults() is not shown, but it likely registers commonly used services and default configurations that the application needs

```csharp
builder.AddServiceDefaults();
```

This method likely registers specific application services required for the functionality of the app. Like the previous method, it abstracts the details of service setup.

```csharp
builder.AddApplicationServices();
```

This line adds support for returning standardized error details in HTTP responses, following the Problem Details standard. This is useful for consistent error handling and returning structured error information to clients

```csharp
builder.Services.AddProblemDetails();
```

This builds the app with all the configured services and middleware, making it ready for handling requests

```csharp
var app = builder.Build();
```

Adds middleware to handle exceptions globally, likely showing a user-friendly error page or structured error response if an unhandled exception occurs

```csharp
app.UseExceptionHandler();
```

This maps default endpoints for the app. The specifics of MapDefaultEndpoints() are not shown, but this typically would map endpoints/routes based on controller or minimal API configurations

```csharp
app.MapDefaultEndpoints();
```

Maps an endpoint for CatalogApiV1. This makes the V1 version of the Catalog API accessible. The method MapCatalogApiV1() likely defines routes specifically for version 1 of the Catalog API

```csharp
app.MapCatalogApiV1();
```

This starts the web application and listens for incoming requests

```csharp
app.Run();
```

We review the whole code:

**Program.cs**

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddApplicationServices();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

app.MapDefaultEndpoints();

app.MapCatalogApiV1();

app.Run();
```

## 16. Adding Extensions for Enhanced Functionality in Catalog.API

### 16.1. Adding Extensions.cs file 

(Folder: Extensions)

This C# code is a configuration class designed to extend an application’s builder with various services for a catalog API in an e-commerce setting

Overall, this extension class configures database, options, AI services, and scoped services, preparing the catalog API application with development-friendly setups and AI integration while leaving production-critical configurations for further review.

**Database Setup**:

**builder.AddNpgsqlDbContext<CatalogContext>("catalogdb", ...)**: Adds a PostgreSQL database context (CatalogContext) using Npgsql. The UseVector() method is added to configure vector support, potentially for handling AI or ML data types within the database

**builder.Services.AddMigration<CatalogContext, CatalogContextSeed>()**: This part adds a service to handle migrations for the CatalogContext, enabling easy database updates during development

**Options and Configuration**:

**builder.Services.AddOptions<CatalogOptions>().BindConfiguration(nameof(CatalogOptions))**: Binds options for the catalog configuration, making them accessible throughout the application

**AI and Embedding Generator Configuration**:

This section checks if either an Ollama endpoint or an OpenAI connection string is configured in the app’s settings

**Ollama Integration**: If Ollama:Endpoint is provided, it sets up an embedding generator using OllamaEmbeddingGenerator with logging and telemetry

**OpenAI Integration**: If an OpenAI connection string is available, the application configures an OpenAIClient and sets it up to generate embeddings, allowing AI-powered operations (like search or recommendation) using embeddings

**Scoped Service Registration**:

**builder.Services.AddScoped<ICatalogAI, CatalogAI>()**: Registers ICatalogAI as a scoped service, ensuring instances of CatalogAI are created per HTTP request or job, depending on how it's used

We review the **Extensions.cs** code:

![image](https://github.com/user-attachments/assets/3329c8aa-5224-469f-b5bc-af8161f631b9)

```csharp
using eShop.Catalog.API.Services;
using Microsoft.Extensions.AI;
using OpenAI;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<CatalogContext>("catalogdb", configureDbContextOptions: dbContextOptionsBuilder =>
        {
            dbContextOptionsBuilder.UseNpgsql(builder =>
            {
                builder.UseVector();
            });
        });

        // REVIEW: This is done for development ease but shouldn't be here in production
        builder.Services.AddMigration<CatalogContext, CatalogContextSeed>();

        builder.Services.AddOptions<CatalogOptions>().BindConfiguration(nameof(CatalogOptions));

        if (builder.Configuration["AI:Ollama:Endpoint"] is string ollamaEndpoint && !string.IsNullOrWhiteSpace(ollamaEndpoint))
        {
            builder.Services.AddEmbeddingGenerator<string, Embedding<float>>(b => b
                .UseOpenTelemetry()
                .UseLogging()
                .Use(new OllamaEmbeddingGenerator(
                    new Uri(ollamaEndpoint),
                    builder.Configuration["AI:Ollama:EmbeddingModel"])));
        }
        else if (!string.IsNullOrWhiteSpace(builder.Configuration.GetConnectionString("openai")))
        {
            builder.AddOpenAIClientFromConfiguration("openai");
            builder.Services.AddEmbeddingGenerator<string, Embedding<float>>(b => b
                .UseOpenTelemetry()
                .UseLogging()
                .Use(b.Services.GetRequiredService<OpenAIClient>().AsEmbeddingGenerator(builder.Configuration["AI:OpenAI:EmbeddingModel"]!)));
        }

        builder.Services.AddScoped<ICatalogAI, CatalogAI>();
    }
}
```

### 16.2. Adding ActivityExtensions.cs file

(Folder: Extensions)

This code is an extension method for the Activity class that helps record exception information for telemetry purposes

It’s designed to support OpenTelemetry, which is a standard for observability, including tracing and metrics in distributed systems

This code is useful for enhancing observability by logging detailed exception information within trace data, making it easier to analyze and debug issues in distributed systems

We review the **ActivityExtensions.cs** code:

![image](https://github.com/user-attachments/assets/b088810d-22c0-490a-af02-379543e860eb)

```csharp
using System.Diagnostics;

internal static class ActivityExtensions
{
    // See https://opentelemetry.io/docs/specs/otel/trace/semantic_conventions/exceptions/
    public static void SetExceptionTags(this Activity activity, Exception ex)
    {
        if (activity is null)
        {
            return;
        }

        activity.AddTag("exception.message", ex.Message);
        activity.AddTag("exception.stacktrace", ex.ToString());
        activity.AddTag("exception.type", ex.GetType().FullName);
        activity.SetStatus(ActivityStatusCode.Error);
    }
}
```

### 16.3. Adding MigrateDbContextExtensions.cs file

(Folder: Extensions)

This code defines a set of **extension methods** and a **hosted service** to support **automatic database migrations** for a .NET Core application using Entity Framework Core

This code provides an efficient way to **handle database migrations** and **seeding at application startup**, with features for tracing, error handling, and extensibility through dependency injection

![image](https://github.com/user-attachments/assets/2c130e95-3a76-4746-904d-e2e6e1766a0a)

```csharp
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Microsoft.AspNetCore.Hosting;

internal static class MigrateDbContextExtensions
{
    private static readonly string ActivitySourceName = "DbMigrations";
    private static readonly ActivitySource ActivitySource = new(ActivitySourceName);

    public static IServiceCollection AddMigration<TContext>(this IServiceCollection services)
        where TContext : DbContext
        => services.AddMigration<TContext>((_, _) => Task.CompletedTask);

    public static IServiceCollection AddMigration<TContext>(this IServiceCollection services, Func<TContext, IServiceProvider, Task> seeder)
        where TContext : DbContext
    {
        // Enable migration tracing
        services.AddOpenTelemetry().WithTracing(tracing => tracing.AddSource(ActivitySourceName));

        return services.AddHostedService(sp => new MigrationHostedService<TContext>(sp, seeder));
    }

    public static IServiceCollection AddMigration<TContext, TDbSeeder>(this IServiceCollection services)
        where TContext : DbContext
        where TDbSeeder : class, IDbSeeder<TContext>
    {
        services.AddScoped<IDbSeeder<TContext>, TDbSeeder>();
        return services.AddMigration<TContext>((context, sp) => sp.GetRequiredService<IDbSeeder<TContext>>().SeedAsync(context));
    }

    private static async Task MigrateDbContextAsync<TContext>(this IServiceProvider services, Func<TContext, IServiceProvider, Task> seeder) where TContext : DbContext
    {
        using var scope = services.CreateScope();
        var scopeServices = scope.ServiceProvider;
        var logger = scopeServices.GetRequiredService<ILogger<TContext>>();
        var context = scopeServices.GetService<TContext>();

        using var activity = ActivitySource.StartActivity($"Migration operation {typeof(TContext).Name}");

        try
        {
            logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

            var strategy = context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(() => InvokeSeeder(seeder, context, scopeServices));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);

            activity.SetExceptionTags(ex);

            throw;
        }
    }

    private static async Task InvokeSeeder<TContext>(Func<TContext, IServiceProvider, Task> seeder, TContext context, IServiceProvider services)
        where TContext : DbContext
    {
        using var activity = ActivitySource.StartActivity($"Migrating {typeof(TContext).Name}");

        try
        {
            await context.Database.MigrateAsync();
            await seeder(context, services);
        }
        catch (Exception ex)
        {
            activity.SetExceptionTags(ex);

            throw;
        }
    }

    private class MigrationHostedService<TContext>(IServiceProvider serviceProvider, Func<TContext, IServiceProvider, Task> seeder)
        : BackgroundService where TContext : DbContext
    {
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return serviceProvider.MigrateDbContextAsync(seeder);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
public interface IDbSeeder<in TContext> where TContext : DbContext
{
    Task SeedAsync(TContext context);
}
```

## 17. Adding CatalogOptions file

**CatalogOptions.cs**

```csharp
namespace eShop.Catalog.API;

public class CatalogOptions
{
    public string PicBaseUrl { get; set; }
    public bool UseCustomizationData { get; set; }
}
```

## 18. Setting Up appsettings.json with Database Connection Details

We have to add the database connection string in the **appsettings.json** file

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "CatalogDB": "Host=localhost;Database=CatalogDB;Username=postgres;Password=yourWeak(!)Password"
  }
}
```

## 19. Create the Database and Tables

(Folder: Migrations)

**IMPORTANT NOTE**: for this sample before creating the Migrations we have to introduce a modification in the **CatalogItem.cs** file

We have to define the **Embedding** variable as **Nullable**, including a question mark **?** symbol

![image](https://github.com/user-attachments/assets/2606723f-1c17-4b61-bbb0-6914e28e2182)

We right click on the **Catalog.API** project and select the menu option **Set as StartUp Project**

![image](https://github.com/user-attachments/assets/9bf912f8-6cf5-4969-8e47-791c47c674a3)

![image](https://github.com/user-attachments/assets/7e81b4e2-1077-4f36-9f5d-012e3ee9651f)

We open the **Package Manager Console**

![image](https://github.com/user-attachments/assets/6c43872f-4cfb-4d02-ac8e-232abda4d212)

We select the Catalog.API project

![image](https://github.com/user-attachments/assets/c4b5ba3c-e2b7-41fb-ac56-937e0bf5e98d)

We Add a Migration for creating the Database and Tables. We run this command:

```
Add-Migration DatabaseInitialization
```

![image](https://github.com/user-attachments/assets/de0a7427-acf0-4d66-b5d2-ff1c98deb3ff)

We verify a new folder **Migrations** we created

![image](https://github.com/user-attachments/assets/78335eb5-5058-45d2-8a0c-5e1a9161a1f2)

We review the Migrations automatically generated code

```csharp

```


```csharp

```

## 20. Running the Application to View Initial Results

First of all, we have to **Run Docker Desktop**

Then 

