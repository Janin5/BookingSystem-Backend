namespace BookingSystem.InterfacesRepositories
{
    public interface IGenericRepository<TEntity, TId> where TEntity : class
    
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        public void Delete(TEntity entity);

        Task SaveChangesAsync();

        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(TId id);
    }
}
