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


//fluent api to na dole , alternatywą są Atrybuty (np. [Key], [Required], [MaxLength]
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

        
        // SEEDOWANIE (Na początku migracji , aktualizacji pojawią sie dane)
        // modelBuilder.Entity<User>().HasData(
        //     new User { Id = "f8a460a3-97f8-41d6-a7d1-bfa3d9e3d94a", UserName = "admin", FirstName = "John", LastName = "Doe", Email = "admin@example.com" },
        //     new User { Id = "1d69b95e-d6ec-4b98-a574-02a59d2d1b2f", UserName = "jane_doe", FirstName = "Jane", LastName = "Doe", Email = "jane@example.com" }
        // );


    }
}
//najpierw podaje default connection i rejestruje w program cs. potem tworze migracje a potem updatuje by sie
//stworzyło. gdy to zrobie to łącze sie jrider z SQL server(nie local) Server=localhost;Database=ToDoList;Trusted_Connection=True;TrustServerCertificate=True