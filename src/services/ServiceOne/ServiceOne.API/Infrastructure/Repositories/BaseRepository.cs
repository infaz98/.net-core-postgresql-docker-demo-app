using Microsoft.EntityFrameworkCore;
using ServiceOne.API.Infrastructure.Interfaces;

namespace ServiceOne.API.Infrastructure.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected DbContext _applicationDataContext;

    public BaseRepository(DbContext applicationDbContext)
    {
        _applicationDataContext = applicationDbContext;
    }

    public async Task<T?> GetByIdAsync<TId>(TId id)
    {
        return await _applicationDataContext.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> ListAllAsync()
    {
        return await _applicationDataContext.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        _applicationDataContext.Set<T>().Add(entity);
        await _applicationDataContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(T entity)
    {
        _applicationDataContext.Set<T>().Remove(entity);
        return await _applicationDataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _applicationDataContext.Entry(entity).State = EntityState.Modified;
        await _applicationDataContext.SaveChangesAsync();
    }
}