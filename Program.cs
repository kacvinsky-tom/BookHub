using BookHub.DataAccessLayer;
using BookHub.Services;
using BookHub.Middlewares;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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