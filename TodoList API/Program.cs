using Microsoft.EntityFrameworkCore;
using TodoList_API.Data;
using TodoList_API.Repositories;
using TodoList_API.Repositories.Interface;
using TodoList_API.Services;
using TodoList_API.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie", o =>
    {
        o.Cookie.Name = "demo";
        o.ExpireTimeSpan = TimeSpan.FromHours(8);
        o.LoginPath = "/account/login";
        o.AccessDeniedPath = "/forbidden";
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "API");
    });
}



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
