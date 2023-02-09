using Microsoft.EntityFrameworkCore;
using WebAPICore.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebAPICoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAPICoreDbContext")?? throw new InvalidOperationException("Connection string 'WebAPIEFContext' not found."))
);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DbContext, WebAPICoreDbContext>();
builder.Services.AddScoped<IUserRepository,UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
