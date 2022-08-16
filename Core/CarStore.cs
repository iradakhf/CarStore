

using Core.Abstracts;

namespace Core
{
    public class CarStore : IEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Owner Owner { get; set; }
        public List<Car> Cars { get; set; }
        public List<Seller> Sellers { get; set; }
        public int Id { get ; set ; }
        public CarStore()
        {
            Cars = new List<Car>();
            Sellers = new List<Seller>();

        }
    }
}
