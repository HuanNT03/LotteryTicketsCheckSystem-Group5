using Microsoft.EntityFrameworkCore;

public class LotteryRepository : ILotteryRepository
{
    private readonly ApplicationDbContext _context;

    public LotteryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<int>> GetTicketIdsByCompanyAndDate(string companyName, DateTime issueDate)
    {
        return await _context.LotteryTickets
            .Where(t => t.LotteryCompany.CompanyName == companyName && t.IssueDate == issueDate)
            .Select(t => t.TicketId)
            .ToListAsync();
    }

    // Các phương thức khác của IRepository<T>
    public async Task<IEnumerable<LotteryTicket>> GetAll()
    {
        return await _context.LotteryTickets
            .Include(t => t.LotteryCompany)
            .Include(t => t.TicketResults)
            .ToListAsync();
    }

    public async Task<LotteryTicket> GetById(int id)
    {
        return await _context.LotteryTickets
            .Include(t => t.LotteryCompany)
            .Include(t => t.TicketResults)
            .FirstOrDefaultAsync(t => t.TicketId == id);
    }

    public async Task Add(LotteryTicket entity)
    {
        await _context.LotteryTickets.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(LotteryTicket entity)
    {
        _context.LotteryTickets.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var ticket = await _context.LotteryTickets.FindAsync(id);
        if (ticket != null)
        {
            _context.LotteryTickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
