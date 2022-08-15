using Core;


namespace DataAccess
{
    public class DataContext
    {
        public List<Car> Cars { get; set; }
        public List<CarStore> CarStores { get; set; }
        public List<Seller> Sellers { get; set; }
        public List<Admin> Admins { get; set; }
        public List<Owner> Owners { get; set; }
        public DataContext()
        {
            Cars = new List<Car>();
            CarStores = new List<CarStore>();
            Sellers = new List<Seller>();
            Admins = new List<Admin>();
            Owners = new List<Owner>();
        }
    }
}
