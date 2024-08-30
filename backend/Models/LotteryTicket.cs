public class LotteryTicket
{
    public int TicketId { get; set; }
    public string TicketNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public int CompanyId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public LotteryCompany LotteryCompany { get; set; }
    public ICollection<TicketResult> TicketResults { get; set; }
    public ICollection<CheckHistory> CheckHistories { get; set; }
}
