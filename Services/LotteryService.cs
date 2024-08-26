using LotteryBackend.Models;
using LotteryBackend.Repositories;

public class LotteryService : ILotteryService
{
    private readonly ILotteryResultRepository _lotteryResultRepository;

    public LotteryService(ILotteryResultRepository lotteryResultRepository)
    {
        _lotteryResultRepository = lotteryResultRepository;
    }

    public async Task<LotteryResult> GetLotteryResultByDateAsync(DateTime date)
    {
        return await _lotteryResultRepository.GetLotteryResultByDateAsync(date);
    }

    public async Task AddLotteryResultAsync(LotteryResult result)
    {
        await _lotteryResultRepository.AddLotteryResultAsync(result);
    }
}