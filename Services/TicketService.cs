using LotteryBackend.Models;
using LotteryBackend.Repositories;

namespace LotteryBackend.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Ticket?> GetTicketByIdAsync(int ticketId)
        {
            return await _ticketRepository.GetTicketByIdAsync(ticketId);
        }

        public async Task<Ticket> AddTicketAsync(Ticket newTicket)
        {
            await _ticketRepository.AddTicketAsync(newTicket);
            return newTicket;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId)
        {
            return await _ticketRepository.GetTicketsByUserIdAsync(userId);
        }

        public async Task UpdateTicketAsync(int ticketId, Ticket updatedTicket)
        {
            await _ticketRepository.UpdateTicketAsync(updatedTicket);
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            await _ticketRepository.DeleteTicketAsync(ticketId);
        }
    }
}
