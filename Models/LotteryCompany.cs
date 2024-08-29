public class LotteryCompany
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public ICollection<LotteryTicket> LotteryTickets { get; set; }
}
