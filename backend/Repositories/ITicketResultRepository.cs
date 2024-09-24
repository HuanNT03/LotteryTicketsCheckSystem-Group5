public interface ITicketResultRepository
{
    Task<TicketResult> GetByTicketId(int ticketId);
    Task Add(TicketResult ticketResult);
    Task Update(TicketResult ticketResult);
}
