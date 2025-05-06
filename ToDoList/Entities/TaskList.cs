namespace ToDoList.Entities;

public class TaskList
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }

    public string OwnerId { get; set; }
    public User Owner { get; set; }

    public ICollection<ToDoItem> Items { get; set; }
}