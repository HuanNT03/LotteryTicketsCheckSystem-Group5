using LotteryBackend.Models;

namespace LotteryBackend.Repositories
{
    public interface ITicketRepository
    {
        Task<Ticket> GetTicketByIdAsync(int ticketId);

        Task<IEnumerable<Ticket>> GetAllLotteryTicketsByPageAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Ticket>> GetTicketsByCompanyAndDateRangeAsync(int companyId, DateTime fromDate, DateTime toDate);
        Task AddTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(Ticket ticket);
        Task DeleteTicketAsync(int ticketId);
        Task<int> GetCheckCountByTicketIdAsync(int ticketId);
    }
}
