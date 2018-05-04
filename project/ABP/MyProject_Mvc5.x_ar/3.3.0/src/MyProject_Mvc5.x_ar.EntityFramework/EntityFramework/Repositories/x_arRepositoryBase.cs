using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace MyProject_Mvc5.x_ar.EntityFramework.Repositories
{
    public abstract class x_arRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<x_arDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected x_arRepositoryBase(IDbContextProvider<x_arDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class x_arRepositoryBase<TEntity> : x_arRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected x_arRepositoryBase(IDbContextProvider<x_arDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
