namespace ToDoList.Entities
{
    public class ToDoItem
    {
        public string Id { get; set; } 
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public string TaskListId { get; set; }  
        public TaskList TaskList { get; set; }
    }
}