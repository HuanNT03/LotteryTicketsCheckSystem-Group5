using LotteryBackend.Models;

public interface ITicketService
{
    Task<Ticket> GetTicketByIdAsync(int ticketId);
    Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId);
    Task AddTicketAsync(Ticket ticket);
    Task UpdateTicketAsync(Ticket ticket);
    Task DeleteTicketAsync(int ticketId);
}