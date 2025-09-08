using RealEstate.Domain.Entities;
using System.Linq.Expressions;

namespace RealEstate.Domain.Interfaces
{
    public interface IPropertyRepository
    {
        Task<Property?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Property>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Property>> GetByAgentIdAsync(string agentId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Property>> SearchAsync(Expression<Func<Property, bool>> predicate, CancellationToken cancellationToken = default);
        Task<Property> AddAsync(Property property, CancellationToken cancellationToken = default);
        Task UpdateAsync(Property property, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(Expression<Func<Property, bool>>? predicate = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<Property>> GetPagedAsync(int page, int pageSize, Expression<Func<Property, bool>>? predicate = null, CancellationToken cancellationToken = default);
    }
}
