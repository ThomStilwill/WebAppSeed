using System;

namespace Foundation.Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
