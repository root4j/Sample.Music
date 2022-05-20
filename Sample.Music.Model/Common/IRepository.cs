namespace Sample.Music.Model.Common
{
    public interface IRepository<K, T>
    {
        void Create(T entity);
        void Delete(K id);
        K Id(T entity);
        T? Read(K id);
        List<T> ReadAll();
        IQueryable<T> ReadByPredicate(Func<T, bool> predicate);
        void Update(K id, T entity);
    }
}