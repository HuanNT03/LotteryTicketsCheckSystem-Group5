public class LotteryService
{
    private readonly ILotteryRepository _lotteryRepository;
    private readonly IRepository<TicketResult> _ticketResultRepository;

    public LotteryService(ILotteryRepository lotteryRepository, IRepository<TicketResult> ticketResultRepository)
    {
        _lotteryRepository = lotteryRepository;
        _ticketResultRepository = ticketResultRepository;
    }

    public async Task UpdateTicketPrize(int ticketId, string prize)
    {
        var ticket = await _lotteryRepository.GetById(ticketId);
        if (ticket != null)
        {
            var ticketResult = ticket.TicketResults?.FirstOrDefault(tr => tr.Prize == prize);
            if (ticketResult == null)
            {
                ticketResult = new TicketResult
                {
                    TicketId = ticketId,
                    Prize = prize,
                    DrawDate = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                if (ticket.TicketResults == null)
                {
                    ticket.TicketResults = new List<TicketResult>();
                }
                ticket.TicketResults.Add(ticketResult);
                await _ticketResultRepository.Add(ticketResult);
            }
            else
            {
                ticketResult.Prize = prize;
                ticketResult.UpdatedAt = DateTime.Now;
                await _ticketResultRepository.Update(ticketResult);
            }
        }
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
