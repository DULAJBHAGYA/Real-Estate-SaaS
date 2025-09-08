using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Persistence.Context;
using System.Linq.Expressions;

namespace RealEstate.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Appointments
                .Include(a => a.Property)
                .Include(a => a.Client)
                .Include(a => a.Agent)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Appointments
                .Include(a => a.Property)
                .Include(a => a.Client)
                .Include(a => a.Agent)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Appointment>> GetByPropertyIdAsync(int propertyId, CancellationToken cancellationToken = default)
        {
            return await _context.Appointments
                .Include(a => a.Property)
                .Include(a => a.Client)
                .Include(a => a.Agent)
                .Where(a => a.PropertyId == propertyId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Appointment>> GetByAgentIdAsync(string agentId, CancellationToken cancellationToken = default)
        {
            return await _context.Appointments
                .Include(a => a.Property)
                .Include(a => a.Client)
                .Include(a => a.Agent)
                .Where(a => a.AgentId == agentId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Appointment>> GetByClientIdAsync(string clientId, CancellationToken cancellationToken = default)
        {
            return await _context.Appointments
                .Include(a => a.Property)
                .Include(a => a.Client)
                .Include(a => a.Agent)
                .Where(a => a.ClientId == clientId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Appointment>> SearchAsync(Expression<Func<Appointment, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Appointments
                .Include(a => a.Property)
                .Include(a => a.Client)
                .Include(a => a.Agent)
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }

        public async Task<Appointment> AddAsync(Appointment appointment, CancellationToken cancellationToken = default)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync(cancellationToken);
            return appointment;
        }

        public async Task UpdateAsync(Appointment appointment, CancellationToken cancellationToken = default)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Appointments.AnyAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<int> GetCountAsync(Expression<Func<Appointment, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Appointments.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.CountAsync(cancellationToken);
        }

        public async Task<IEnumerable<Appointment>> GetPagedAsync(int page, int pageSize, Expression<Func<Appointment, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Appointments
                .Include(a => a.Property)
                .Include(a => a.Client)
                .Include(a => a.Agent)
                .AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
