public class LotteryService
{
    private readonly ILotteryRepository _lotteryRepository;

    public LotteryService(ILotteryRepository lotteryRepository)
    {
        _lotteryRepository = lotteryRepository;
    }

    public async Task<LotteryTicket> CreateLotteryTicket(LotteryTicket ticket)
    {
        ticket.CreatedAt = DateTime.UtcNow;
        ticket.UpdatedAt = DateTime.UtcNow;

        await _lotteryRepository.Add(ticket);
        return ticket;
    }

    public async Task<IEnumerable<int>> GetTicketIdsByCompanyAndDate(string companyName, DateTime issueDate)
    {
        return await _lotteryRepository.GetTicketIdsByCompanyAndDate(companyName, issueDate);
    }

    public async Task<IEnumerable<LotteryTicket>> GetAllTickets()
    {
        return await _lotteryRepository.GetAll();
    }

    public async Task<LotteryTicket> GetTicketById(int id)
    {
        return await _lotteryRepository.GetById(id);
    }

    public async Task AddTicket(LotteryTicket ticket)
    {
        await _lotteryRepository.Add(ticket);
    }

    public async Task UpdateTicket(LotteryTicket ticket)
    {
        await _lotteryRepository.Update(ticket);
    }

    public async Task DeleteTicket(int id)
    {
        await _lotteryRepository.Delete(id);
    }
}
