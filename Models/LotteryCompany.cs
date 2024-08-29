public class LotteryCompany
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<LotteryTicket> LotteryTickets { get; set; }
}
