using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Entities;

namespace ToDoList.Data;

public class ApplicationDbContext : IdentityDbContext<User>{
    
    //umożliwiając poprawną konfigurację połączenia z bazą danych w aplikacji.
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


//User dbSet jest domyslnie bo po identity dziedziczy
public DbSet<TaskList> TaskLists { get; set; }
public DbSet<ToDoItem> ToDoItems { get; set; }

}

//najpierw podaje default connection i rejestruje w program cs. potem tworze migracje a potem updatuje by sie
//stworzyło. gdy to zrobie to łącze sie jrider z SQL server(nie local) Server=localhost;Database=ToDoList;Trusted_Connection=True;TrustServerCertificate=True