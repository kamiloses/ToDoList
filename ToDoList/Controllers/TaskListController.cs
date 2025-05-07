namespace ToDoList.Controllers;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Entities;
using ToDoList.Services;


[ApiController]
[Route("api/[controller]")]
public class TaskListController : ControllerBase
{
    private readonly TaskListService _taskListService;

    public TaskListController(TaskListService taskListService)
    {
        _taskListService = taskListService;
    }

    // === SYNC ===

    [HttpGet("all")]
    public ActionResult<IEnumerable<TaskList>> GetAll()
    {
        var result = _taskListService.GetAllTasksList();
        return Ok(result);
    }

    [HttpGet("by-user/{userId}")]
    public ActionResult<IEnumerable<TaskList>> GetByUser(string userId)
    {
        var result = _taskListService.GetAllByUserAsNoTracking(userId);
        return Ok(result);
    }
    
    [HttpPost]
    public ActionResult<TaskList> Create([FromBody] CreateTaskListDto dto)
    {
        var taskList = new TaskList
        {   Id = new Guid().ToString(),
            Title = dto.Title,
            OwnerId = dto.OwnerId
           
        };

        var created = _taskListService.Create(taskList);
        return CreatedAtAction(nameof(GetByUser), new { userId = created.OwnerId }, created);
    }

    [HttpPut]
    public IActionResult Update(TaskList taskList)
    {
        var updated = _taskListService.Update(taskList);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var deleted = _taskListService.DeleteTaskById(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    // === ASYNC ===

    [HttpGet("async/all")]
    public async Task<ActionResult<IEnumerable<TaskList>>> GetAllAsync()
    {
        var result = await _taskListService.GetAllTasksListAsync();
        return Ok(result);
    }

    [HttpGet("async/by-user/{userId}")]
    public async Task<ActionResult<IEnumerable<TaskList>>> GetByUserAsync(string userId)
    {
        var result = await _taskListService.GetAllByUserAsync(userId);
        return Ok(result);
    }

    [HttpPost("async")]
    public async Task<ActionResult<TaskList>> CreateAsync(TaskList taskList)
    {
        var created = await _taskListService.CreateAsync(taskList);
        return CreatedAtAction(nameof(GetByUserAsync), new { userId = created.OwnerId }, created);
    }

    [HttpPut("async")]
    public async Task<IActionResult> UpdateAsync(TaskList taskList)
    {
        var updated = await _taskListService.UpdateAsync(taskList);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("async/{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var deleted = await _taskListService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
