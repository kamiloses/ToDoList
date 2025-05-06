using Microsoft.EntityFrameworkCore;
using ToDoList.Data;

var builder = WebApplication.CreateBuilder(args);

//1) rejestruje baze danych
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


app.Run();