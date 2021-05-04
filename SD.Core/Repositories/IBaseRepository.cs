using SD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SD.Core.Repositories
{
    public interface IBaseRepository
    {
        #region [C]REATE
        void Add<T>(T entity, bool saveImmediatley = false)
            where T : class, IEntity;

        Task AddAsync<T>(T entity, bool saveImmediatley = false, CancellationToken cancellationToken = default)
            where T : class, IEntity;
        #endregion

        #region [R]EAD
        void Get<T>(T entity, bool saveImmediatley = false)
            where T : class, IEntity;

        Task GetAsync<T>(T entity, bool saveImmediatley = false, CancellationToken cancellationToken = default)
            where T : class, IEntity;
        #endregion

        #region [U]PDATE
        void Update<T>(T entity, bool saveImmediatley = false)
            where T : class, IEntity;

        Task UpdateAsync<T>(T entity, bool saveImmediatley = false, CancellationToken cancellationToken = default)
            where T : class, IEntity;
        #endregion

        #region [D]ELETE
        void Delete<T>(T entity, bool saveImmediatley = false)
            where T : class, IEntity;

        Task DeleteAsync<T>(T entity, bool saveImmediatley = false, CancellationToken cancellationToken = default)
            where T : class, IEntity;
        #endregion
    }
}
