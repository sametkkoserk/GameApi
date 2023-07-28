using Api.Models;

namespace Api.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        GetManyResult<TEntity> AsQueryable();
        Task<GetManyResult<TEntity>> AsQueryableAsync();
    }

}
