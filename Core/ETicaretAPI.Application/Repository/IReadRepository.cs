using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : EntityBase
    {
        IQueryable<T> GetAll(bool tracing = true);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracing = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracing = true);

        Task<T> GetByIdAsync(String id, bool tracing = true);

    }

}
