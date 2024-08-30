using LotteryBackend.Data;
using LotteryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LotteryBackend.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            return await _context.Tickets.Include(t => t.LotteryResults).FirstOrDefaultAsync(t => t.Id == ticketId);
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Ticket>> GetAllLotteryTicketsByPageAsync(int pageNumber, int pageSize)
        {
            return await _context.Tickets
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByCompanyAndDateRangeAsync(int companyId, DateTime fromDate, DateTime toDate)
        {
            return await _context.Tickets
            .Where(t => t.LotteryCompanyId == companyId && t.LotteryDate >= fromDate && t.LotteryDate <= toDate)
            .ToListAsync();
        }

        public async Task<int> GetCheckCountByTicketIdAsync(int ticketId)
        {
            return await _context.CheckHistories.CountAsync(c => c.TicketId == ticketId);
        }
    }
}
