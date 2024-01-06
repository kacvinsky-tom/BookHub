using Core.Extensions;
using DataAccessLayer;
using LoggingMiddleware.Extensions;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddPostgreDbContextFactory(builder.Configuration);
builder.Services.AddSqliteDbContextFactory(builder.Configuration);

builder.Services.AddScoped<UnitOfWork>();

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

app.Run();
