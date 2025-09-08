using System;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstate.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPropertyRepository Properties { get; }
        IAppointmentRepository Appointments { get; }
        IPropertyViewRepository PropertyViews { get; }
        IUserRepository Users { get; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}
