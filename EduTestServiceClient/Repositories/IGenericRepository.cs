using EduTestServiceClient.DTO;

namespace EduTestServiceClient.Repositories
{
    public interface IGenericRepository<T> where T : new()
    {
        T Get(int id);

        /// <summary>
        /// Returns a list of items
        /// </summary>
        /// <param name="page">Page, 0-indexed. Default 0.</param>
        /// <param name="perPage">Elements per page. Maximum 1000. Default 10.</param>
        /// <returns></returns>
        Items<T> GetList(int page = 0, int perPage = 10);

        int Add(T entity);

        void Update(T entity, int id);

        void Remove(int id);
    }
}