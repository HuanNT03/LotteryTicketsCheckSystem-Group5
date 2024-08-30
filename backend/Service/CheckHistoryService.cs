public class CheckHistoryService
{
    private readonly ICheckHistoryRepository _checkHistoryRepository;

    public CheckHistoryService(ICheckHistoryRepository checkHistoryRepository)
    {
        _checkHistoryRepository = checkHistoryRepository;
    }

    public async Task<IEnumerable<CheckHistory>> GetCheckHistoriesByUserId(int userId)
    {
        return await _checkHistoryRepository.GetCheckHistoriesByUserId(userId);
    }

    public async Task<IEnumerable<CheckHistory>> GetAllCheckHistories()
    {
        return await _checkHistoryRepository.GetAll();
    }

    public async Task<CheckHistory> GetCheckHistoryById(int id)
    {
        return await _checkHistoryRepository.GetById(id);
    }

    public async Task AddCheckHistory(CheckHistory checkHistory)
    {
        await _checkHistoryRepository.Add(checkHistory);
    }

    public async Task UpdateCheckHistory(CheckHistory checkHistory)
    {
        await _checkHistoryRepository.Update(checkHistory);
    }

    public async Task DeleteCheckHistory(int id)
    {
        await _checkHistoryRepository.Delete(id);
    }
}
