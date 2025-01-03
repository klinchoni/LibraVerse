﻿namespace LibraVerse.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using LibraVerse.Data;
    using System.Threading.Tasks;

    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(LibraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllAsReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }
        public async Task RemoveAsync<T>(T entity) where T : class
        {
            DbSet<T>().Remove(entity);
        }
        public async Task RemoveRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            DbSet<T>().RemoveRange(entities);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public void Detach<TEntity>(TEntity entity) where TEntity : class
        {
            var entry = dbContext.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Detached;
            }
        }

    }
}