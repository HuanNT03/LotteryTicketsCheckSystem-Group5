public interface ILotteryRepository : IRepository<LotteryTicket>
{
    Task<IEnumerable<int>> GetTicketIdsByCompanyAndDate(string companyName, DateTime issueDate);
}
