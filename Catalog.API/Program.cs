var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.AddApplicationServices();

// Add services to the container.
builder.Services.AddProblemDetails();

//var withApiVersioning = builder.Services.AddApiVersioning();

//builder.AddDefaultOpenApi(withApiVersioning);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

//app.NewVersionedApi("Catalog")
//   .MapCatalogApiV1();

app.MapCatalogApiV1();

//app.UseDefaultOpenApi();

app.Run();