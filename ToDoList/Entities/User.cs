using Microsoft.AspNetCore.Identity;

namespace ToDoList.Entities;

public class User : IdentityUser<int>
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public ICollection<TaskList> TaskList { get; set; } //IColection to interfejs a list to implementja
}
