using LotteryBackend.Models;

namespace LotteryBackend.Services
{
    public interface ITicketService
    {
        Task<Ticket?> GetTicketByIdAsync(int ticketId);
        Task<Ticket> AddTicketAsync(Ticket newTicket);
        Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId);
        Task UpdateTicketAsync(int ticketId, Ticket updatedTicket);
        Task DeleteTicketAsync(int ticketId);
    }
}
