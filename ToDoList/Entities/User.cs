
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Entities;

public class User : IdentityUser //domyslnie id to string IdentityUser<int> wtedy byłobyint
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<TaskList> TaskList { get; set; } = new List<TaskList>(); //IColection to interfejs a list to implementja
    

}

