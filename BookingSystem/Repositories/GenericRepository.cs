using BookingSystem.InterfacesRepositories;
using BookingSystem.Database;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories;

public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class
{
    protected readonly AppDbContext _context;
    public GenericRepository(AppDbContext context)
    {
        _context = context;

    }
    public void Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAll()
    {
        var list = await _context.Set<TEntity>().ToListAsync();

        return list;
    }

    public async Task<TEntity?> GetById(TId id)
    {
        return await _context.Set<TEntity>().FindAsync(id);

    }

    public void Delete(TEntity entity)
    {
         _context.Set<TEntity>().Remove(entity);

       
    }
}
