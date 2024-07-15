using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories;

public class EfRepository<T>
    : IRepository<T>
    where T: BaseEntity
{
    private readonly DataContext _dataContext;
    public EfRepository( DataContext dataContext)
    {
        _dataContext = dataContext;
    }
        
    public async  Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dataContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dataContext.Set<T>().FindAsync(id); 
    }

    public async Task<T> AddAsync(T entity)
    {
        entity.Id = Guid.NewGuid();
        var entry = await _dataContext.Set<T>().AddAsync(entity);
        await _dataContext.SaveChangesAsync();
        return entry.Entity; 
    }

    public async Task UpdateAsync(T entity)
    {
         _dataContext.Update(entity);
         await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dataContext.Set<T>().Remove(entity);
        await _dataContext.SaveChangesAsync();
    }
}