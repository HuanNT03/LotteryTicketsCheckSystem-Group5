using Microsoft.EntityFrameworkCore;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly ApplicationDbContext _context;

    public UserRoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task DeleteCompositeKey(int userId, int roleId)
    {
        var userRole = await _context.UserRoles
            .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

        if (userRole != null)
        {
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<UserRole>> GetAll()
    {
        return await _context.UserRoles.ToListAsync();
    }

    public async Task<UserRole> GetById(int id)
    {
        return await _context.UserRoles.FindAsync(id);
    }

    public async Task Add(UserRole entity)
    {
        await _context.UserRoles.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(UserRole entity)
    {
        _context.UserRoles.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var userRole = await _context.UserRoles.FindAsync(id);
        if (userRole != null)
        {
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
        }
    }
}
