using SD.Core.Entities;
using SD.Core.Repositories;
using SD.Persistence.Repositories.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SD.Persistence.Repositories.Base
{
    public abstract class BaseRepository : IBaseRepository
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
        public void Add<T>(T entity, bool saveImmediatly)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return;
            }

            this.movieDbContext.Add<T>(entity);
            
            if (saveImmediatly)
            {
                this.movieDbContext.SaveChanges();
            }
        }

        public async Task AddAsync<T>(T entity, bool saveImmediatly, CancellationToken cancellationToken)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return;
            }

            await this.movieDbContext.AddAsync(entity);
            
            if (saveImmediatly)
            {
                this.movieDbContext.SaveChangesAsync(cancellationToken);
            }
        }
        #endregion


        #region [R]EAD
        public IQueryable<T> QueryFrom<T>(Expression<Func<T, bool>> wherefilter = null)
            where T : class, IEntity
        {
            var query = this.movieDbContext.Set<T>();

            if (wherefilter != null)
            {
                return query.Where(wherefilter);
            }

            return query;
        }
        #endregion


        #region [U]PDATE
        public T Update<T>(T entity, object key, bool saveImmediatly = false)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return null;
            }

            var toUpdate = this.movieDbContext.Set<T>().Find(key);

            if (toUpdate != null)
            {
                this.movieDbContext.Entry(toUpdate).CurrentValues.SetValues(entity);
                if (saveImmediatly)
                {
                    this.movieDbContext.SaveChanges();
                }
            }

            return toUpdate;
        }

        public async Task<T> UpdateAsync<T>(T entity, object key, bool saveImmediatly = false, CancellationToken cancellationToken = default)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return null;
            }

            var toUpdate = await this.movieDbContext.Set<T>().FindAsync(key);

            if (toUpdate != null)
            {
                this.movieDbContext.Entry(toUpdate).CurrentValues.SetValues(entity);

                if (saveImmediatly)
                {
                    await this.movieDbContext.SaveChangesAsync(cancellationToken);
                }
            }

            return toUpdate;

        }
        #endregion


        #region [D]ELETE
        public void Remove<T>(T entity, bool saveImmediatly)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return;
            }

            this.movieDbContext.Remove<T>(entity);

            if (saveImmediatly)
            {
                this.movieDbContext.SaveChanges();
            }

        }

        public async Task RemoveAsync<T>(T entity, bool saveImmediatly, CancellationToken cancellationToken)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return;
            }

            this.movieDbContext.Remove<T>(entity);

            if (saveImmediatly)
            {
                await this.movieDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public void RemoveByKey<T>(object key, bool saveImmediatly)
            where T : class, IEntity
        {
            if (key == null)
            {
                return;
            }

            var toRemove = this.movieDbContext.Set<T>().Find(key);

            if (toRemove != null)
            {
                this.movieDbContext.Remove<T>(toRemove);
            }

            if (saveImmediatly)
            {
                this.movieDbContext.SaveChanges();
            }
        }

        public async Task RemoveByKeyAsync<T>(object key, bool saveImmediatly, CancellationToken cancellationToken)
            where T : class, IEntity
        {
            if (key == null)
            {
                return;
            }

            var toRemove = await this.movieDbContext.Set<T>().FindAsync(key, cancellationToken);

            if (toRemove != null)
            {
                this.movieDbContext.Remove<T>(toRemove);
            }

            if (saveImmediatly)
            {
                await this.movieDbContext.SaveChangesAsync(cancellationToken);
            }
        }
        #endregion


    }
}
