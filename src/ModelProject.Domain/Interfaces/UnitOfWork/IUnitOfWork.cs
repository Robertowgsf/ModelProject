namespace ModelProject.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public void StartTransaction();
        public void Commit();
        public void Rollback();
    }
}
