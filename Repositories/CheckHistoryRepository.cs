using LotteryBackend.Data;
using LotteryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LotteryBackend.Repositories
{
    public class CheckHistoryRepository : ICheckHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CheckHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CheckHistory>> GetHistoryByUserIdAsync(int userId)
        {
            return await _context.CheckHistories
                .Include(ch => ch.Ticket)
                .Where(ch => ch.UserId == userId)
                .ToListAsync();
        }

        public async Task AddHistoryAsync(CheckHistory history)
        {
            await _context.CheckHistories.AddAsync(history);
            await _context.SaveChangesAsync();
        }
    }
}
