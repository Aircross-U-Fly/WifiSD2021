using SD.Core.Entities;
using SD.Core.Repositories;
using SD.Persistence.Repositories.DBContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SD.Persistence.Repositories.Base
{
    public class BaseRepository : IBaseRepository
    {

        MovieDbContext movieDbContext;

        public BaseRepository()
        {
            this.movieDbContext = new MovieDbContext();
        }

        public BaseRepository(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }


        //CRUD = Create, Read, Update and Delete (Base Functions)
        #region [C]REATE
        public void Add<T>(T entity, bool saveImmediatley)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return;
            }

            this.movieDbContext.Add(entity);
            
            if (saveImmediatley)
            {
                this.movieDbContext.SaveChanges();
            }
        }

        public async Task AddAsync<T>(T entity, bool saveImmediatley, CancellationToken cancellationToken)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return;
            }

            await this.movieDbContext.AddAsync(entity);
            
            if (saveImmediatley)
            {
                this.movieDbContext.SaveChangesAsync();
            }
        }
        #endregion


        #region [R]EAD
        public void Get<T>(T entity, bool saveImmediatley)
            where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task GetAsync<T>(T entity, bool saveImmediatley, CancellationToken cancellationToken)
            where T : class, IEntity
        {
            throw new NotImplementedException();
        }
        #endregion


        #region [U]PDATE
        public void Update<T>(T entity, bool saveImmediatley)
            where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync<T>(T entity, bool saveImmediatley, CancellationToken cancellationToken)
            where T : class, IEntity
        {
            throw new NotImplementedException();
        }
        #endregion


        #region [D]ELETE
        public void Delete<T>(T entity, bool saveImmediatley)
            where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync<T>(T entity, bool saveImmediatley, CancellationToken cancellationToken)
            where T : class, IEntity
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
