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

    public async Task<Ticket> GetLotteryTicketByIdAsync(int id)
    {
        return await _ticketRepository.GetTicketByIdAsync(id);
    }

    public async Task<IEnumerable<Ticket>> GetAllLotteryTicketsAsync(int pageNumber, int pageSize)
    {
        return await _ticketRepository.GetAllLotteryTicketsByPageAsync(pageNumber, pageSize);
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByCompanyAndDateRangeAsync(int companyId, DateTime fromDate, DateTime toDate)
    {
        return await _ticketRepository.GetTicketsByCompanyAndDateRangeAsync(companyId, fromDate, toDate);
    }

    public async Task AddLotteryTicketAsync(Ticket ticket)
    {
        await _ticketRepository.AddTicketAsync(ticket);
    }

    public async Task UpdateTicketStatusAsync(int ticketId, bool publish)
    {
        var ticket = await _ticketRepository.GetTicketByIdAsync(ticketId);
        if (ticket != null)
        {
            ticket.Status = TicketStatus.PUBLISH;
            await _ticketRepository.UpdateTicketAsync(ticket);
        }
    }

    public async Task<int> GetCheckCountByTicketIdAsync(int ticketId)
    {
        return await _ticketRepository.GetCheckCountByTicketIdAsync(ticketId);
    }

}
