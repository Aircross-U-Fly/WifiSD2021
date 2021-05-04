using SD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SD.Core.Repositories
{
    public interface IBaseRepository
    {
        #region [C]REATE
        void Add<T>(T entity, bool saveImmediatly = false)
            where T : class, IEntity;

        Task AddAsync<T>(T entity, bool saveImmediatly = false, CancellationToken cancellationToken = default)
            where T : class, IEntity;
        #endregion

        #region [R]EAD
        IQueryable<T> QueryFrom<T>(Expression<Func<T, bool>> wherefilter = null)
            where T : class, IEntity;
        #endregion

        #region [U]PDATE
        T Update<T>(T entity, object key, bool saveImmediatly = false)
            where T : class, IEntity;

        Task<T> UpdateAsync<T>(T entity, object key, bool saveImmediatly = false, CancellationToken cancellationToken = default)
            where T : class, IEntity;
        #endregion

        #region [D]ELETE
        void Remove<T>(T entity, bool saveImmediatly = false)
            where T : class, IEntity;

        Task RemoveAsync<T>(T entity, bool saveImmediatly = false, CancellationToken cancellationToken = default)
            where T : class, IEntity;

        void RemoveByKey<T>(object key, bool saveImmediatly = false)
            where T : class, IEntity;

        Task RemoveByKeyAsync<T>(object key, bool saveImmediatly = false, CancellationToken cancellationToken = default)
            where T : class, IEntity;
        #endregion
    }
}
