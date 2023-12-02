using API.Utilities;

namespace API.Contracts;

public interface IGeneralRepository<TEntity>
{
    TEntity? GetByGuid(Guid guid);
    RepositoryResult<TEntity> TakeById(Guid guid);
    RepositoryResult<string> Update(TEntity entity);
    RepositoryResult<string> Create(TEntity entity);
    RepositoryResult<string> Delete(TEntity entity);
    RepositoryResult<IEnumerable<TEntity>> GetAll();
}
