using System.Linq.Expressions;

namespace quizapp_backend.Repository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Retrieve all T entities from the database.
        /// </summary>
        /// <returns>ICollection of T objects</returns>
        Task<ICollection<T>> Get();

        /// <summary>
        /// Retrieve a T object from the database based on a provided Id.
        /// </summary>
        /// <param name="id">Int corresponding to a T object database id</param>
        /// <returns>The found T object, or null if no object contained the provided id.</returns>
        Task<T?> Get(int id);

        /// <summary>
        /// Retrieve the first T object that match a provided predicate.
        /// </summary>
        /// <param name="predicate">The predicate function that determines valid T objects</param>
        /// <returns>The first T object that matched the predicate, or null if no T object fit the predicate.</returns>
        Task<T?> Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Insert a provided T object into the database.
        /// </summary>
        /// <param name="entity">The object to insert into the database</param>
        /// <returns>The saved database object</returns>
        Task<T> Create(T entity);

        /// <summary>
        /// Update the values of a provided T object to matched any changed values. Must contain a valid id.
        /// </summary>
        /// <param name="entity">The T object to be updated</param>
        /// <returns>The updated T object</returns>
        Task<T?> Update(T entity);

        /// <summary>
        /// Attempt to delete a object T with a specific id value from the database
        /// </summary>
        /// <param name="id">Interger value of the entities id</param>
        /// <returns>T object that was deleted, null if no object matched the provided id</returns>
        Task<T?> Delete(int id);
    }
}
