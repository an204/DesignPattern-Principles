namespace Repository_UnitOfWork.Repo
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public TEntity GetByID(object id);
        public void Insert(TEntity entity);
        public void Delete(object id);
        public void Delete(TEntity entityToDelete);
        public void Update(TEntity entityToUpdate);
    }
}