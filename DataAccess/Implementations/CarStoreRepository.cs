

using Core;
using Core.Abstracts;
using DataAccess.Base;

namespace DataAccess.Implementations
{
    public class CarStoreRepository : IRepository<CarStore>

    {
        private int Id { get; set; }
        public CarStore Create(CarStore entity)
        {
            try
            {
                Id++;
                entity.Id = Id;
                DataContext.CarStores.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
            return entity;
        }

        public void Delete(CarStore entity)
        {
            try
            {
                DataContext.CarStores.Remove(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CarStore Get(Predicate<CarStore> filter=null)
        {
            try
            {
                if (filter!=null)
                {
                    return DataContext.CarStores.Find(filter);
                }
                else
                {
                    return DataContext.CarStores[0];
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CarStore> GetAll(Predicate<CarStore> filter=null)
        {
            try
            {
                if (filter!=null)
                {
                    return DataContext.CarStores.FindAll(filter);
                }
                else
                {
                    return DataContext.CarStores;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(CarStore entity)
        {
            try
            {
                var carStore = DataContext.CarStores.Find(cs => cs.Id == entity.Id);
                if (carStore != null)
                {
                
                carStore.Name = entity.Name;
                carStore.PhoneNumber = entity.PhoneNumber;
                carStore.Address = entity.Address;
                    carStore.Owner = entity.Owner;

                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
