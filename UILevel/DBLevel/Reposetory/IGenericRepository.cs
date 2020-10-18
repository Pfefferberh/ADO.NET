using System.Collections.Generic;

namespace DBLevel.Reposetory
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        IEnumerable<TEntity> Read();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
