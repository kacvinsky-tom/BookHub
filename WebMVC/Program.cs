using Azure.Storage.Blobs;
using Core;
using Core.Clients;
using Core.Extensions;
using DataAccessLayer;
using LoggingMiddleware.Extensions;
using Microsoft.EntityFrameworkCore;
using WebMVC;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddPostgreDbContextFactory(builder.Configuration);
//builder.Services.AddSqliteDbContextFactory(builder.Configuration);

var blobServiceClient = new BlobServiceClient(Environment.GetEnvironmentVariable("AZURE_BLOB_STORAGE"));

// Create the container and return a container client object
BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("test22f6ed35-1c6f-400e-9dfd-af230721163b");

builder.Services.AddSingleton(containerClient);
builder.Services.AddScoped<IImageBlobClient, ImageBlobClient>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddMemoryCacheWithConfiguration();
builder.Services.AddRepositories();
builder.Services.AddBLServices();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.ConfigureIdentity();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddAutoMapper(typeof(BookHubProfile), typeof(ServicesBookHubProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseLoggingMiddleware("WebMVC");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<BookHubDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();
