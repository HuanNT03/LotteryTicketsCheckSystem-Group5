using LotteryBackend.Models;
using LotteryBackend.Repositories;

public class HistoryService : IHistoryService
{
    private readonly ICheckHistoryRepository _checkHistoryRepository;

    public HistoryService(ICheckHistoryRepository checkHistoryRepository)
    {
        _checkHistoryRepository = checkHistoryRepository;
    }

    public async Task<IEnumerable<CheckHistory>> GetHistoryByUserIdAsync(int userId)
    {
        return await _checkHistoryRepository.GetHistoryByUserIdAsync(userId);
    }

    public async Task AddHistoryAsync(CheckHistory history)
    {
        await _checkHistoryRepository.AddHistoryAsync(history);
    }
}