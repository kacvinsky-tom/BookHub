using BookHub.DataAccessLayer;
using BookHub.Services;
using BookHub.Middlewares;
using BookHub;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithAuthentication();

builder.Services.AddLogging();

builder.Services.AddDbContext<BookHubDbContext>();
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddRepositories();

builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<WishListService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseLoggingMiddleware();

app.UseHttpsRedirection();

app.UseTokenAuthenticationMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
