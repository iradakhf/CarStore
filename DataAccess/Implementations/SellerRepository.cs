
using Core;
using Core.Abstracts;
using DataAccess.Base;

namespace DataAccess.Implementations
{
    public class SellerRepository : IRepository<Seller>
    {
        private static int Id { get; set; }
        public Seller Create(Seller entity)
        {
            try
            {
            Id++;
            entity.Id = Id;
            DataContext.Sellers.Add(entity);

            }
            catch (Exception)
            {

                throw;
            }
            return entity;
        }

        public void Delete(Seller entity)
        {
            try
            {
                DataContext.Sellers.Remove(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Seller Get(Predicate<Seller> filter=null)
        {
            try
            {
                if (filter != null)
                {
                    return DataContext.Sellers.Find(filter);
                }
                else
                {
                    return DataContext.Sellers[0];
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Seller> GetAll(Predicate<Seller> filter=null)
        {
            try
            {
                if (filter!=null)
                {
                    return DataContext.Sellers.FindAll(filter);
                }
                else
                {
                    return DataContext.Sellers;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Seller entity)
        {
            try
            {
                var seller = DataContext.Sellers.Find(s => s.Id == entity.Id);
                if (seller != null)
                {

                    seller.Name = entity.Name;
                    seller.Age = entity.Age;
                    seller.Surname = entity.Surname;
                    seller.CarStore = entity.CarStore;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
