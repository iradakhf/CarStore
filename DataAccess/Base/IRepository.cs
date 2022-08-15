using Core.Abstracts;

namespace DataAccess.Base
{
    public interface IRepository <T> where T: IEntity
    {
        public void Create(T entity);
        public void Update();
        public void Delete();
        public void Get();
        public void GetAll();
    }
}
