namespace API.Contracts;

public interface IGeneralRepository<TEntity>
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetByGuid(Guid guid);
    bool Create(TEntity entity);
    bool Update(TEntity entity);
    bool Delete(TEntity entity);
}
