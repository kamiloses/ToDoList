namespace ToDoList.Entities
{
    public class TaskList
    {
        public string Id { get; set; }  
        public string Title { get; set; }
        public string OwnerId { get; set; } 
        public User Owner { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
    }
}