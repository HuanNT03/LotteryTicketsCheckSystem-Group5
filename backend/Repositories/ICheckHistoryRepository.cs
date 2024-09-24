public interface ICheckHistoryRepository : IRepository<CheckHistory>
{
    Task<IEnumerable<CheckHistory>> GetCheckHistoriesByUserId(int userId);
}
