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
            return await _context.Tickets
                .Include(t => t.User)
                .Include(t => t.CheckHistories)
                .FirstOrDefaultAsync(t => t.Id == ticketId);
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId)
        {
            return await _context.Tickets
                .Include(t => t.User)
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            var ticket = await GetTicketByIdAsync(ticketId);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }
    }
}
