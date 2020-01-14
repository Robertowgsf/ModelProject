using Microsoft.EntityFrameworkCore.Storage;
using ModelProject.Domain.Interfaces.UnitOfWork;

namespace ModelProject.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction transaction;
        public TweetContext Context { get; }

        public UnitOfWork(TweetContext context)
        {
            Context = context;
        }

        public void StartTransaction()
        {
            transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }
        
        public void Rollback()
        {
            transaction.Rollback();
        }
    }
}
