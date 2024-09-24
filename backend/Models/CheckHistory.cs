public class CheckHistory
{
    public int CH_Id { get; set; }
    public int UserId { get; set; }
    public int LotteryTicketId { get; set; }
    public DateTime CheckDate { get; set; }
    public string Result { get; set; }
    public string Comment { get; set; }

    public User User { get; set; }
    public LotteryTicket LotteryTicket { get; set; }
}
