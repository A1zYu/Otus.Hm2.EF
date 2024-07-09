using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories;

public class EfRepository<T>
    : IRepository<T>
    where T: BaseEntity
{

    public EfRepository(IEnumerable<T> data)
    {
    }
        
    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException(); 
    }

    public Task<T> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException(); 
    }
}