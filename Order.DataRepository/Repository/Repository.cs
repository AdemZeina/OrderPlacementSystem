﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Domain;
using Order.Domain.Context;
using Order.Domain.Entities;

namespace Order.Repository.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class,IEntity
    {

        protected OrderDataContext Context { get; }
        protected DbSet<TEntity> Set { get; }

        public Repository(OrderDataContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }

     

        public virtual async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default)
            => await Set.FindAsync(keyValues, cancellationToken);

        public virtual async Task<TEntity> FindAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
            => await FindAsync(new object[] { keyValue }, cancellationToken);

        public virtual async Task<bool> ExistsAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            var item = await FindAsync(keyValues, cancellationToken);
            return item != null;
        }

        public virtual async Task<bool> ExistsAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
            => await ExistsAsync(new object[] { keyValue }, cancellationToken);

        public virtual async Task LoadPropertyAsync(TEntity item, Expression<Func<TEntity, object>> property, CancellationToken cancellationToken = default)
            => await Context.Entry(item).Reference(property).LoadAsync(cancellationToken);

        public virtual void Attach(TEntity item)
            => Set.Attach(item);

        public virtual void Detach(TEntity item)
            => Context.Entry(item).State = EntityState.Detached;

        public virtual void Insert(TEntity item)
        {
            var entity = (IEntity)item;
            entity.CreatedDate = DateTime.UtcNow;
            Context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Update(TEntity item)
            => Context.Entry(item).State = EntityState.Modified;

        public virtual void Delete(TEntity item)
        {
            var entity = (IEntity)item;
            entity.IsDeleted = true;
            entity.DeletedDate=DateTime.UtcNow;
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            var item = await FindAsync(keyValues, cancellationToken);
            if (item == null) return false;
            Context.Entry(item).State = EntityState.Deleted;
            return true;
        }

        public virtual async Task<bool> DeleteAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
            => await DeleteAsync(new object[] { keyValue }, cancellationToken);

        public virtual IQueryable<TEntity> Queryable() => Set;

        public virtual IQueryable<TEntity> QueryableSql(string sql, params object[] parameters)
            => Set.FromSql(sql, parameters);

        //   public virtual IQuery<TEntity> Query() => new Query<TEntity>(this);
    }
}
