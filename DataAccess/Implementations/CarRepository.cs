using Core;
using DataAccess.Base;

namespace DataAccess.Implementations
{
    public class CarRepository : IRepository<Car>

    {
        private static int Id { get; set; }
        public Car Create(Car entity)
        {
            try
            {
                Id++;
                entity.Id = Id;
                DataContext.Cars.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
            return entity;
        }

        public void Delete(Car entity)
        {
            try
            {
                DataContext.Cars.Remove(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Car Get(Predicate<Car> filter=null)
        {
            try
            {
              
                if (filter!=null)
                {
                    return DataContext.Cars.Find(filter);
                }
                else
                {
                    return DataContext.Cars[0];
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Car> GetAll(Predicate<Car> filter=null)
        {
            try
            {
                if (filter!=null)
                {
                return DataContext.Cars.FindAll(filter);
                }
                else
                {
                    return DataContext.Cars;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Car entity)
        {
            try
            {
                var car = DataContext.Cars.Find(c => c.Id == entity.Id);
                if (car != null)
                {
                
                car.Name = entity.Name;
                car.Color = entity.Color;
                car.Price = entity.Price;
                car.Amount = entity.Amount;
                    car.CarStore = entity.CarStore;

                }
                                 
              }
            catch (Exception)
            {

                throw;
            }
        }
    }
}