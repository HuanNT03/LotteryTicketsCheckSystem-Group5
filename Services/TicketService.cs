using LotteryBackend.Models;
using LotteryBackend.Repositories;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket> GetTicketByIdAsync(int ticketId)
    {
        return await _ticketRepository.GetTicketByIdAsync(ticketId);
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId)
    {
        return await _ticketRepository.GetTicketsByUserIdAsync(userId);
    }

    public async Task AddTicketAsync(Ticket ticket)
    {
        await _ticketRepository.AddTicketAsync(ticket);
    }

    public async Task UpdateTicketAsync(Ticket ticket)
    {
        await _ticketRepository.UpdateTicketAsync(ticket);
    }

    public async Task DeleteTicketAsync(int ticketId)
    {
        await _ticketRepository.DeleteTicketAsync(ticketId);
    }
}
