using Microsoft.AspNetCore.Identity;
using ToDoList.Entities;

namespace ToDoList.Services;

public class UserService
{
    
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> CreateUserAsync(User user, string password)
    {
        return await _userManager.CreateAsync(user, password); }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }
    
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await Task.FromResult(_userManager.Users.ToList());
    }
    
}