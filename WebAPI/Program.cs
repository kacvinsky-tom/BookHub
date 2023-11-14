using Core.Services;
using DataAccessLayer;
using WebAPI;
using WebAPI.Extensions;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithAuthentication();

builder.Services.AddLogging();

builder.Services.AddAutoMapper(typeof(BookHubProfile));

builder.Services.AddDbContext<BookHubDbContext>();
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddRepositories();

builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<CartService>();
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
