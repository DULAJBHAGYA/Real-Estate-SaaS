using RealEstate.Domain.Entities;
using System.Linq.Expressions;

namespace RealEstate.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Appointment>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Appointment>> GetByPropertyIdAsync(int propertyId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Appointment>> GetByAgentIdAsync(string agentId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Appointment>> GetByClientIdAsync(string clientId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Appointment>> SearchAsync(Expression<Func<Appointment, bool>> predicate, CancellationToken cancellationToken = default);
        Task<Appointment> AddAsync(Appointment appointment, CancellationToken cancellationToken = default);
        Task UpdateAsync(Appointment appointment, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(Expression<Func<Appointment, bool>>? predicate = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<Appointment>> GetPagedAsync(int page, int pageSize, Expression<Func<Appointment, bool>>? predicate = null, CancellationToken cancellationToken = default);
    }
}
