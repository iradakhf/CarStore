using Core.Abstracts;

namespace DataAccess.Base
{
    public interface IRepository <T> where T: IEntity
    {
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public T Get(Predicate<T> filter);
        public T GetAll(Predicate<T> filter);
    }
}
