using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Persistence.Context;
using System.Linq.Expressions;

namespace RealEstate.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<ApplicationUser?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ApplicationUser>> SearchAsync(Expression<Func<ApplicationUser, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }

        public async Task<ApplicationUser> AddAsync(ApplicationUser user, CancellationToken cancellationToken = default)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }

        public async Task UpdateAsync(ApplicationUser user, CancellationToken cancellationToken = default)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<bool> ExistsAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.AnyAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<int> GetCountAsync(Expression<Func<ApplicationUser, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Users.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.CountAsync(cancellationToken);
        }

        public async Task<IEnumerable<ApplicationUser>> GetPagedAsync(int page, int pageSize, Expression<Func<ApplicationUser, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Users.AsQueryable();

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
