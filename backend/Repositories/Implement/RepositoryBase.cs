using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace Repositories.Implement;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly EventRsvpPlatformDbContext _context;
    private readonly DbSet<T> _dbSet;

    public RepositoryBase(EventRsvpPlatformDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool tracking = false)
    {
        IQueryable<T> query = _dbSet;
        if (!tracking) query = query.AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(object id, bool tracking = true)
    {
        var entity = await _dbSet.FindAsync(new object[] { id });

        if (entity != null && !tracking)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        return entity;
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate,
        bool tracking = true,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (!tracking) query = query.AsNoTracking();

        foreach (var include in includes)
            query = query.Include(include);

        return await query.SingleOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool tracking = true,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (!tracking) query = query.AsNoTracking();

        if (predicate != null)
            query = query.Where(predicate);

        foreach (var include in includes)
            query = query.Include(include);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}