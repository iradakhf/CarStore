using Core;
using DataAccess.Base;

namespace DataAccess.Implementations
{
    public class CarRepository : IRepository<Car>

    {
        public void Create( Car car)
        {
            try
            {
              
            }
            catch (Exception m)
            {

                Console.WriteLine(m); ;
            }
        }

        public void Delete()
        {
            
        }

        public void Get()
        {
           
        }

        public void GetAll()
        {
          
        }

        public void Update()
        {
           
        }
    }
}