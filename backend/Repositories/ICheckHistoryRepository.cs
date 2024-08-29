using LotteryBackend.Models;

namespace LotteryBackend.Repositories
{
    public interface ICheckHistoryRepository
    {
        Task<IEnumerable<CheckHistory>> GetHistoryByUserIdAsync(int userId);
        Task AddHistoryAsync(CheckHistory history);
    }
}
