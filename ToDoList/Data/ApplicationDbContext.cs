using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Entities;

namespace ToDoList.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{

    //umożliwiając poprawną konfigurację połączenia z bazą danych w aplikacji.
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


//User dbSet jest domyslnie bo po identity dziedziczy
    public DbSet<TaskList> TaskLists { get; set; }
    public DbSet<ToDoItem> ToDoItems { get; set; }


//fluent api
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        // TaskList <==> ToDoItem
        modelBuilder.Entity<TaskList>()
            .HasMany(task => task.ToDoItems) //czyli task ma relacje one to many
            .WithOne(todoItem => todoItem.TaskList) //czyli todoItem w relacji z task jest w relacji many to one 
            .HasForeignKey(toDoItem => toDoItem.TaskListId) // Klucz obcy: TaskListId w ToDoItem
            .OnDelete(DeleteBehavior.Cascade);
        // TaskList <==> User 
        modelBuilder.Entity<TaskList>()
            .HasOne(taskList => taskList.Owner)
            .WithMany(user => user.TaskList)
            .HasForeignKey(taskList => taskList.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        //jezeli skonfigurowac taskList<==> toDoItem to nie musze konfigurować juz na odwrót ponownie
        // ToDoItem <==> User juz nie musze 
        base.OnModelCreating(modelBuilder);



    }
}
//najpierw podaje default connection i rejestruje w program cs. potem tworze migracje a potem updatuje by sie
//stworzyło. gdy to zrobie to łącze sie jrider z SQL server(nie local) Server=localhost;Database=ToDoList;Trusted_Connection=True;TrustServerCertificate=True