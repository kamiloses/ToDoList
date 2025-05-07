using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        try
        {
            var added = _context.TaskLists.Add(taskList).Entity;
            _context.SaveChanges();
            return added;
        }
        catch (DbUpdateException ex) {
            throw new InvalidOperationException("An error occurred while saving the task list.", ex); }}

    
    
    public bool Update(TaskList taskList)
    {
        //jeśli chcesz znaleźć obiekt po jego Id, wystarczy, że przekazujesz to Id jako argument w metodzie Find():
        try
        {
            
            var existingTaskList = _context.TaskLists.Find(taskList.Id);
        
            if (existingTaskList == null)
            {
                return false;
            }

            existingTaskList.Title = taskList.Title; 

            _context.SaveChanges();

            return true; 
        }
        catch (DbUpdateException ex)
        {
            throw new InvalidOperationException("An error occurred while updating the task list.", ex);
        }
    }

    public bool DeleteTaskById(string id)
    {
        
        var taskList = _context.TaskLists.Find(id);
        _context.TaskLists.Remove(taskList);
    
        // Zapisz zmiany w bazie danych
        var result = _context.SaveChanges();
    
        // Jeśli zapisano co najmniej jedną zmianę, zwróć true
        return result > 0;
        
    }
    
    // ==========================
    // ASYNC
    // ==========================





    public async Task<IEnumerable<TaskList>> GetAllTasksListAsync()
    {

        return await _context.TaskLists.AsNoTracking().ToListAsync();
    }
    

    public async Task<IEnumerable<TaskList>> GetAllByUserAsync(string userId)
    {
   
        return await _context.TaskLists.AsNoTracking().Where(t => t.OwnerId == userId).ToListAsync();
        
    }



    public async Task<TaskList> CreateAsync(TaskList taskList)
    {
        try
        {
            await _context.TaskLists.AddAsync(taskList);
        
            await _context.SaveChangesAsync();

            return taskList;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while saving the task list.", ex);
        }
    }

    public async Task<bool> UpdateAsync(TaskList taskList)
    {

        try
        {
            TaskList? existingTaskList = await _context.TaskLists.FindAsync(taskList.Id);
        
            if (existingTaskList == null)
            {
                return false; 
            }
        
            existingTaskList.Title = taskList.Title;

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while updating the task list.", ex);
        }
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var existingTaskList = await _context.TaskLists
            .FirstOrDefaultAsync(t => t.Id == id);

        if (existingTaskList == null)
            return false;

        _context.TaskLists.Remove(existingTaskList);
        await _context.SaveChangesAsync();

        return true; 
        
        
        
        throw new NotImplementedException();
    }
}


 // AS NO TRACKING TYLKO DO MODYFIKACJI PUT,POST itp , DOMYSLNIE JEST TRACKING
//EF pobiera dane i zapomina o nich.
//Ty możesz je czytać, ale EF nie zauważy, jeśli coś w nich zmienisz.
 //   SaveChanges() nic nie zrobi, bo EF nie ma pojęcia, że coś się zmieniło.

