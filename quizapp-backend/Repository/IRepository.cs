namespace quizapp_backend.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<ICollection<T>> Get();
        Task<T?> Get(int id);
        Task<T> Create(T entity);
        Task<T?> Update(T entity);
        Task<T?> Delete(int id);
    }
}
