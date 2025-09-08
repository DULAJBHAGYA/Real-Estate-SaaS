using RealEstate.Domain.Entities;
using System.Linq.Expressions;

namespace RealEstate.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<ApplicationUser?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<IEnumerable<ApplicationUser>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ApplicationUser>> SearchAsync(Expression<Func<ApplicationUser, bool>> predicate, CancellationToken cancellationToken = default);
        Task<ApplicationUser> AddAsync(ApplicationUser user, CancellationToken cancellationToken = default);
        Task UpdateAsync(ApplicationUser user, CancellationToken cancellationToken = default);
        Task DeleteAsync(string id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(string id, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(Expression<Func<ApplicationUser, bool>>? predicate = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<ApplicationUser>> GetPagedAsync(int page, int pageSize, Expression<Func<ApplicationUser, bool>>? predicate = null, CancellationToken cancellationToken = default);
    }
}
