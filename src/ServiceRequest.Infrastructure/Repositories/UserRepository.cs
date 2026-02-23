using Microsoft.EntityFrameworkCore;
using ServiceRequest.Application.Interfaces;
using ServiceRequest.Domain.Entities;
using ServiceRequest.Infrastructure.Data;

namespace ServiceRequest.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) 
    {
        _context = context;
    }

    // On utilise AsNoTracking() pour les listes car c'est plus performant (lecture seule)
    public async Task<List<User>> GetAllAsync() 
        => await _context.Users.AsNoTracking().ToListAsync(); // Vérifie bien que c'est .Users ici

    public async Task<User?> GetByIdAsync(int id) 
        => await _context.Users.FindAsync(id); // Et .Users ici aussi

    public async Task<User> AddAsync(User user)
    {
        _context.Users.Add(user); // Pas _context.Tickets !
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task DeleteAsync(int id)
    {
        // On cherche l'utilisateur pour vérifier s'il existe avant de supprimer
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}