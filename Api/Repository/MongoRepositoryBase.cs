using Api.Models;
using Api.Repository.Abstract;

namespace Api.Repository
{
    public class MongoRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        public GetManyResult<TEntity> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<GetManyResult<TEntity>> AsQueryableAsync()
        {
            throw new NotImplementedException();
        }
    }
}
