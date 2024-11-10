var builder = DistributedApplication.CreateBuilder(args);

var catalogdbusername = builder.AddParameter("postgres-username");
var catalogdbpassword = builder.AddParameter("postgres-password");

var postgres = builder.AddPostgres("postgres", catalogdbusername, catalogdbpassword, port: 5432)
    .WithImage("ankane/pgvector")
    .WithImageTag("latest")
    .WithLifetime(ContainerLifetime.Persistent);

var catalogDb = postgres.AddDatabase("catalogdb");

var catalogApi = builder.AddProject<Projects.Catalog_API>("catalog-api")
    .WithReference(catalogDb);

builder.Build().Run();
