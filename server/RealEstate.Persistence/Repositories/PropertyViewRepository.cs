using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Persistence.Context;
using System.Linq.Expressions;

namespace RealEstate.Persistence.Repositories
{
    public class PropertyViewRepository : IPropertyViewRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyViewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PropertyView?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.PropertyViews
                .Include(v => v.Property)
                .Include(v => v.User)
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<PropertyView>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.PropertyViews
                .Include(v => v.Property)
                .Include(v => v.User)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<PropertyView>> GetByPropertyIdAsync(int propertyId, CancellationToken cancellationToken = default)
        {
            return await _context.PropertyViews
                .Include(v => v.Property)
                .Include(v => v.User)
                .Where(v => v.PropertyId == propertyId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<PropertyView>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            return await _context.PropertyViews
                .Include(v => v.Property)
                .Include(v => v.User)
                .Where(v => v.UserId == userId)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<PropertyView>> SearchAsync(Expression<Func<PropertyView, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.PropertyViews
                .Include(v => v.Property)
                .Include(v => v.User)
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }

        public async Task<PropertyView> AddAsync(PropertyView propertyView, CancellationToken cancellationToken = default)
        {
            _context.PropertyViews.Add(propertyView);
            await _context.SaveChangesAsync(cancellationToken);
            return propertyView;
        }

        public async Task UpdateAsync(PropertyView propertyView, CancellationToken cancellationToken = default)
        {
            _context.PropertyViews.Update(propertyView);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var propertyView = await _context.PropertyViews.FindAsync(id);
            if (propertyView != null)
            {
                _context.PropertyViews.Remove(propertyView);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.PropertyViews.AnyAsync(v => v.Id == id, cancellationToken);
        }

        public async Task<int> GetCountAsync(Expression<Func<PropertyView, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var query = _context.PropertyViews.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.CountAsync(cancellationToken);
        }

        public async Task<IEnumerable<PropertyView>> GetPagedAsync(int page, int pageSize, Expression<Func<PropertyView, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var query = _context.PropertyViews
                .Include(v => v.Property)
                .Include(v => v.User)
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
