using System.ComponentModel.DataAnnotations;

public class CreateLotteryTicketDto
{
    [Required]
    public string TicketNumber { get; set; }

    [Required]
    public DateTime IssueDate { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public string Status { get; set; }
}
