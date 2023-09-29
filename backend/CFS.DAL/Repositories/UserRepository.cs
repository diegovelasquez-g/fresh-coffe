using CFS.DAL.Contracts;
using CFS.DAL.Data;
using CFS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CFS.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FreshCoffeeContext _context;

    public UserRepository(FreshCoffeeContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        var recordsAffected = await _context.SaveChangesAsync();
        return recordsAffected > 0;
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        _context.Update(user);
        var recordsAffected = await _context.SaveChangesAsync();
        return recordsAffected > 0;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var usersList = await _context.Users.ToListAsync();
        return usersList;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        return user;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }
}