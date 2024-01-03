using Core.Extensions;
using DataAccessLayer;
using LoggingMiddleware.Extensions;
using WebAPI;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithAuthentication();

builder.Services.AddLogging();

builder.Services.AddAutoMapper(typeof(BookHubProfile));
builder.Services.AddMemoryCacheWithConfiguration();
builder.Services.AddDbContextFactoryWithConfiguration(builder.Configuration);
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddRepositories();
builder.Services.AddBLServices();
builder.Services.ConfigureIdentity();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseLoggingMiddleware("WebAPI");

app.UseHttpsRedirection();

app.UseTokenAuthenticationMiddleware();

app.UseXmlResponseMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
