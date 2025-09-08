using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Persistence.Context;
using System.Linq.Expressions;

namespace RealEstate.Persistence.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Property?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Properties
                .Include(p => p.Agent)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Property>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Properties
                .Include(p => p.Agent)
                .Include(p => p.Images)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Property>> GetByAgentIdAsync(string agentId, CancellationToken cancellationToken = default)
        {
            return await _context.Properties
                .Include(p => p.Agent)
                .Include(p => p.Images)
                .Where(p => p.AgentId == agentId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Property>> SearchAsync(Expression<Func<Property, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Properties
                .Include(p => p.Agent)
                .Include(p => p.Images)
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }

        public async Task<Property> AddAsync(Property property, CancellationToken cancellationToken = default)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync(cancellationToken);
            return property;
        }

        public async Task UpdateAsync(Property property, CancellationToken cancellationToken = default)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property != null)
            {
                _context.Properties.Remove(property);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Properties.AnyAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<int> GetCountAsync(Expression<Func<Property, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Properties.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.CountAsync(cancellationToken);
        }

        public async Task<IEnumerable<Property>> GetPagedAsync(int page, int pageSize, Expression<Func<Property, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Properties
                .Include(p => p.Agent)
                .Include(p => p.Images)
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
