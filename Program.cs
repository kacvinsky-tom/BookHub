using BookHub.DataAccessLayer;
using BookHub.Services;
using BookHub.Middlewares;
using BookHub.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithAuthentication();

builder.Services.AddLogging();

builder.Services.AddDbContext<BookHubDbContext>();
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddRepositories();

builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<WishListService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PublisherService>();
builder.Services.AddScoped<VoucherService>();

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
