using LotteryBackend.Models;
using LotteryBackend.Repositories;

public class LotteryService : ILotteryService //Result
{
    private readonly ILotteryResultRepository _lotteryResultRepository;
    private readonly IHistoryService _checkHistoryService;

    public LotteryService(ILotteryResultRepository lotteryResultRepository, IHistoryService checkHistoryService)
    {
        _lotteryResultRepository = lotteryResultRepository;
        _checkHistoryService = checkHistoryService;
    }

    public async Task<LotteryResult> GetLotteryResultByDateAsync(DateTime date)
    {
        return await _lotteryResultRepository.GetLotteryResultByDateAsync(date);
    }

    public async Task AddLotteryResultAsync(LotteryResult result)
    {
        await _lotteryResultRepository.AddLotteryResultAsync(result);
    }

    public async Task<LotteryResult> CheckLotteryNumberAsync(int ticketId, string number)
    {
        var result = await _lotteryResultRepository.GetResultByTicketIdAndNumberAsync(ticketId, number);

        return result;
    }

    public async Task<IEnumerable<LotteryResult>> GetResultsByTicketIdAsync(int ticketId)
    {
        return await _lotteryResultRepository.GetResultsByTicketIdAsync(ticketId);
    }
}