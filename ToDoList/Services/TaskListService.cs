using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Entities;

namespace ToDoList.Services;

public class TaskListService {
    
    private readonly ApplicationDbContext _context;
    
    public TaskListService(ApplicationDbContext context)
    {
        _context = context;
    }

    
    public IEnumerable<TaskList> GetAllTasksList()
    {
        return _context.TaskLists.AsNoTracking();
    }
    
    public IEnumerable<TaskList> GetAllByUserAsNoTracking(string userId)
    {
        return _context.TaskLists
            .AsNoTracking()
            .Where(t => t.OwnerId == userId)
            .ToList();
    }

    public TaskList Create(TaskList taskList)
    {
        throw new NotImplementedException();
    }

    public bool Update(TaskList taskList)
    {
        throw new NotImplementedException();
    }

    public bool Delete(string id, string userId)
    {
        throw new NotImplementedException();
    }
    
    // ==========================
    // ASYNC
    // ==========================
    
    
    
    
    
    public IEnumerable<TaskList> GetAllTasksListAsync()
    { }
    

    public Task<IEnumerable<TaskList>> GetAllByUserAsync(string userId)
    {
        throw new NotImplementedException();
    }



    public Task<TaskList> CreateAsync(TaskList taskList)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(TaskList taskList)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id, string userId)
    {
        throw new NotImplementedException();
    }
}


 // AS NO TRACKING TYLKO DO MODYFIKACJI PUT,POST itp , DOMYSLNIE JEST TRACKING
//EF pobiera dane i zapomina o nich.
//Ty możesz je czytać, ale EF nie zauważy, jeśli coś w nich zmienisz.
 //   SaveChanges() nic nie zrobi, bo EF nie ma pojęcia, że coś się zmieniło.

