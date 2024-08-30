using Microsoft.EntityFrameworkCore;

public class TicketResultRepository : ITicketResultRepository
{
    private readonly ApplicationDbContext _context;

    public TicketResultRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TicketResult> GetByTicketId(int ticketId)
    {
        return await _context.TicketResults.FirstOrDefaultAsync(tr => tr.TicketId == ticketId);
    }

    public async Task Add(TicketResult ticketResult)
    {
        await _context.TicketResults.AddAsync(ticketResult);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TicketResult ticketResult)
    {
        _context.TicketResults.Update(ticketResult);
        await _context.SaveChangesAsync();
    }
}
