using LotteryBackend.Models;

public class TicketDto
{
    public DateTime LotteryDate { get; set; }
    public IEnumerable<LotteryResult> Results { get; set; }
}