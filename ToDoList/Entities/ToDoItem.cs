namespace ToDoList.Entities;

public class ToDoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get; set; }
    public string Priority { get; set; }
    public int TaskListId { get; set; }
    public TaskList TaskList { get; set; }
}