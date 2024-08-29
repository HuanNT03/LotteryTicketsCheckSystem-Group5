using LotteryBackend.Data;
using LotteryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LotteryBackend.Repositories
{
    public class LotteryResultRepository : ILotteryResultRepository
    {
        private readonly ApplicationDbContext _context;

        public LotteryResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LotteryResult> GetResultByDateAsync(DateTime date)
        {
            return await _context.LotteryResults.FirstOrDefaultAsync(lr => lr.LotteryDate == date);
        }

        public async Task AddResultAsync(LotteryResult result)
        {
            await _context.LotteryResults.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LotteryResult>> GetAllResultsAsync()
        {
            return await _context.LotteryResults.ToListAsync();
        }

        public async Task UpdateResultAsync(LotteryResult result)
        {
            _context.LotteryResults.Update(result);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteResultAsync(int resultId)
        {
            var result = await _context.LotteryResults.FindAsync(resultId);
            if (result != null)
            {
                _context.LotteryResults.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
