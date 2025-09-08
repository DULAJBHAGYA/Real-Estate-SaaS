using RealEstate.Domain.Entities;
using System.Linq.Expressions;

namespace RealEstate.Domain.Interfaces
{
    public interface IPropertyViewRepository
    {
        Task<PropertyView?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<PropertyView>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<PropertyView>> GetByPropertyIdAsync(int propertyId, CancellationToken cancellationToken = default);
        Task<IEnumerable<PropertyView>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<PropertyView>> SearchAsync(Expression<Func<PropertyView, bool>> predicate, CancellationToken cancellationToken = default);
        Task<PropertyView> AddAsync(PropertyView propertyView, CancellationToken cancellationToken = default);
        Task UpdateAsync(PropertyView propertyView, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(Expression<Func<PropertyView, bool>>? predicate = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<PropertyView>> GetPagedAsync(int page, int pageSize, Expression<Func<PropertyView, bool>>? predicate = null, CancellationToken cancellationToken = default);
    }
}
