using LotteryBackend.Models;

public interface ITicketService
{
    Task<Ticket> GetTicketByIdAsync(int ticketId);
    Task AddTicketAsync(Ticket ticket);
    Task UpdateTicketAsync(Ticket ticket);
    Task DeleteTicketAsync(int ticketId);

    Task<IEnumerable<Ticket>> GetAllLotteryTicketsAsync(int pageNumber, int pageSize);
    Task<IEnumerable<Ticket>> GetTicketsByCompanyAndDateRangeAsync(int companyId, DateTime fromDate, DateTime toDate);
    Task UpdateTicketStatusAsync(int ticketId, bool publish);
    Task<int> GetCheckCountByTicketIdAsync(int ticketId);
}