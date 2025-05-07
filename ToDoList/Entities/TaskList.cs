namespace ToDoList.Entities
{
    public class TaskList
    {
        //TODO EF STORE PROC JESZCZE ZROB ORAZ INCLUDING
        //2 Eager   Lazy i Explicit Loading


      
        public string Id { get; set; }  
        public string Title { get; set; }
        public string OwnerId { get; set; } 
        public User Owner { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
    }
}