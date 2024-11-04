using Microsoft.AspNetCore.Builder;
using RangerEventManager.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.BuildServices();

var app = builder.Build();

app.BuilderWebApplication();
