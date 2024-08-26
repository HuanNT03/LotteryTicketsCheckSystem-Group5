using LotteryBackend.Data;
using LotteryBackend.Models;
using LotteryBackend.Repositories;
using Microsoft.EntityFrameworkCore;

public class CheckHistoryRepository : ICheckHistoryRepository
{
    private readonly ApplicationDbContext _context;

    public CheckHistoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CheckHistory>> GetHistoryByUserIdAsync(int userId)
    {
        return await _context.CheckHistories.Where(ch => ch.UserId == userId).ToListAsync();
    }

    public async Task AddHistoryAsync(CheckHistory history)
    {
        _context.CheckHistories.Add(history);
        await _context.SaveChangesAsync();
    }
}