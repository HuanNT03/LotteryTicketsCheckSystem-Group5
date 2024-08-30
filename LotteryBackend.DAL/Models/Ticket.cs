namespace LotteryBackend.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int LotteryCompanyId { get; set; }
        public DateTime LotteryDate { get; set; }
        public TicketStatus Status { get; set; }
        public int CheckCount { get; set; }

        public LotteryCompany LotteryCompany { get; set; }
        public ICollection<LotteryResult> LotteryResults { get; set; }
        public ICollection<CheckHistory> CheckHistories { get; set; }
    }

    public enum TicketStatus
    {
        UNPUBLISH,
        PUBLISH
    }
}
