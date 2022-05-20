using Microsoft.EntityFrameworkCore;
using Sample.Music.Model.Exceptions;

namespace Sample.Music.Model.Common
{
    public abstract class Repository<K, T> : IRepository<K, T> where T : class, Entities.IAudit
    {
        private readonly AppDbContext _Context;

        protected Repository(AppDbContext context)
        {
            _Context = context;
        }

        public void Create(T entity)
        {
            try
            {
                K id = GetId(entity);
                if (id == null)
                {
                    entity.CreateDate = DateTime.Now;
                    entity.ModifyDate = DateTime.Now;
                    _Context.Set<T>().Add(entity);
                    _Context.SaveChanges();
                }
                else
                {
                    T? obj = Read(id);
                    if (obj == null)
                    {
                        entity.CreateDate = DateTime.Now;
                        entity.ModifyDate = DateTime.Now;
                        _Context.Set<T>().Add(entity);
                        _Context.SaveChanges();
                    }
                    else
                    {
                        throw new UniqueKeyDuplicatedException();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(K id)
        {
            try
            {
                T? obj = Read(id);
                if (obj == null)
                {
                    throw new ObjectsAreNotEqualException();
                }
                else
                {
                    _Context.Set<T>().Remove(obj);
                    _Context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected abstract K GetId(T entity);

        protected virtual IQueryable<T> GetQuery()
        {
            return _Context.Set<T>();
        }

        public K Id(T entity)
        {
            return GetId(entity);
        }

        public T? Read(K id)
        {
            try
            {
                var entity = _Context.Set<T>().Find(id);
                if (entity != null)
                {
                    _Context.Entry(entity).State = EntityState.Detached;
                }
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> ReadAll()
        {
            try
            {
                return GetQuery().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<T> ReadByPredicate(Func<T, bool> predicate)
        {
            try
            {
                return GetQuery().Where(predicate).AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(K id, T entity)
        {
            T? obj = Read(id);
            if (obj == null)
            {
                throw new ObjectNotFoundException();
            }
            else
            {
                if (GetId(obj)!.Equals(GetId(entity)))
                {
                    entity.ModifyDate = DateTime.Now;
                    _Context.Set<T>().Update(entity);
                    _Context.SaveChanges();
                }
                else
                {
                    throw new ObjectsAreNotEqualException();
                }
            }
        }
    }
}