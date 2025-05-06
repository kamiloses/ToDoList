
using Microsoft.AspNetCore.Identity;

namespace ToDoList.Entities;

public class User : IdentityUser //domyslnie id to string IdentityUser<int> wtedy byłobyint
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public ICollection<TaskList> TaskList { get; set; } = new List<TaskList>(); //IColection to interfejs a list to implementja
}
