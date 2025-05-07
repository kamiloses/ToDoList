using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Entities;
using ToDoList.Middlewarers;
using ToDoList.Services;




var builder = WebApplication.CreateBuilder(args);


//musze skonfigurować identity 
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<TaskListService>();
builder.Services.AddScoped<UserService>();

//1) rejestruje baze danych
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();
app.MapControllers();
app.UseMiddleware<CustomMiddleware>();
app.Run();