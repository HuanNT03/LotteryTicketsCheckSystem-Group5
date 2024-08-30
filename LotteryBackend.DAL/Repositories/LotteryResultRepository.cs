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

    public async Task<LotteryResult> GetResultByTicketIdAndNumberAsync(int ticketId, string number)
    {
        var results = await _context.LotteryResults
            .Where(r => r.TicketId == ticketId)
            .ToListAsync();

        // Comparison logic based on the provided rules
        return results.FirstOrDefault(result => CompareLotteryNumber(result, number));
    }

    public async Task<IEnumerable<LotteryResult>> GetResultsByTicketIdAsync(int ticketId)
    {
        return await _context.LotteryResults
            .Where(r => r.TicketId == ticketId)
            .ToListAsync();
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

    private bool CompareLotteryNumber(LotteryResult result, string inputNumber)
    {
        switch (result.PrizeCategory)
        {
            case "Đặc biệt":
                return inputNumber == result.WinningNumber.ToString(); // Full match for special prize
            case "Giải nhất":
                return inputNumber.EndsWith(result.WinningNumber.ToString().Substring(1)); // Last 5 digits match
            case "Giải nhì":
            case "Giải ba":
                return inputNumber.EndsWith(result.WinningNumber.ToString().Substring(1)); // Last 5 digits match
            case "Giải tư":
            case "Giải năm":
                return inputNumber.EndsWith(result.WinningNumber.ToString().Substring(2)); // Last 4 digits match
            case "Giải sáu":
                return inputNumber.EndsWith(result.WinningNumber.ToString().Substring(3)); // Last 3 digits match
            case "Giải bảy":
                return inputNumber.EndsWith(result.WinningNumber.ToString().Substring(4)); // Last 2 digits match
            case "Giải phụ đặc biệt":
                return inputNumber.EndsWith(result.WinningNumber.ToString().Substring(1)) && result.PrizeCategory == "Đặc biệt";
            case "Giải khuyến khích":
                return inputNumber.EndsWith(result.WinningNumber.ToString().Substring(4)); // Last 2 digits of special prize
            default:
                return false;
        }
    }
}