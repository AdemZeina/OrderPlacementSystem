using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Repository.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default);
    }
}
