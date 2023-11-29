namespace API.Contracts;

public interface IGeneralRepository<TEntity>
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetByGuid(Guid guid);
    TEntity? Create(Guid guid);
    bool Update(TEntity entity);
    bool Delete(TEntity entity);
}
