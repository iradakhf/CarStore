using Core;


namespace DataAccess
{
    public class DataContext
    {
        public static List<Car> Cars { get; set; }
        public static List<CarStore> CarStores { get; set; }
        public static List<Seller> Sellers { get; set; }
        public static List<Admin> Admins { get; set; }
        public static List<Owner> Owners { get; set; }
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
