public class TicketResult
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public string Prize { get; set; }
    public DateTime DrawDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public LotteryTicket LotteryTicket { get; set; }
}
