using Microsoft.EntityFrameworkCore;

public class CheckHistoryRepository : ICheckHistoryRepository
{
    private readonly ApplicationDbContext _context;

    public CheckHistoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CheckHistory>> GetCheckHistoriesByUserId(int userId)
    {
        return await _context.CheckHistories
            .Where(ch => ch.UserId == userId)
            .Include(ch => ch.LotteryTicket) // Load thêm thông tin vé số nếu cần
            .ToListAsync();
    }

    //IRepository<CheckHistory>
    public async Task<IEnumerable<CheckHistory>> GetAll()
    {
        return await _context.CheckHistories.ToListAsync();
    }

    public async Task<CheckHistory> GetById(int id)
    {
        return await _context.CheckHistories.FindAsync(id);
    }

    public async Task Add(CheckHistory entity)
    {
        await _context.CheckHistories.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(CheckHistory entity)
    {
        _context.CheckHistories.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var checkHistory = await _context.CheckHistories.FindAsync(id);
        if (checkHistory != null)
        {
            _context.CheckHistories.Remove(checkHistory);
            await _context.SaveChangesAsync();
        }
    }
}
