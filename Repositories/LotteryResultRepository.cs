using LotteryBackend.Data;
using LotteryBackend.Models;
using LotteryBackend.Repositories;
using Microsoft.EntityFrameworkCore;

public class LotteryResultRepository : ILotteryResultRepository
{
    private readonly ApplicationDbContext _context;

    public LotteryResultRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LotteryResult> GetLotteryResultByDateAsync(DateTime date)
    {
        return await _context.LotteryResults.FirstOrDefaultAsync(lr => lr.LotteryDate == date);
    }

    public async Task AddLotteryResultAsync(LotteryResult result)
    {
        _context.LotteryResults.Add(result);
        await _context.SaveChangesAsync();
    }
}