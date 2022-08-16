

using Core;
using Core.Helpers;
using DataAccess.Implementations;

namespace Manage.Controllers
{
    public class SellerController
    {
        public SellerRepository _sellerRepository;
        public CarStoreRepository _carStoreRepository;
        public SellerController()
        {
            _sellerRepository = new SellerRepository();
            _carStoreRepository = new CarStoreRepository();
        }
        #region Create
        public void Create()
        {
            var carStores = _carStoreRepository.GetAll();
            if (carStores.Count > 0)
            {
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id of one car store to create car in");
                foreach (var carstore in carStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {carstore.Id}, name: {carstore.Name}," +
                        $" address : {carstore.Address}, phonenumber: {carstore.PhoneNumber}, owner : {carstore.Owner}");
                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var carStore = _carStoreRepository.Get(c => c.Id == Id);
                    if (carStore != null)
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the name of seller");
                        string name = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the surname of seller");
                        string surname = Console.ReadLine();
                    Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the age of seller ");
                        string age = Console.ReadLine();
                        byte Age;
                        result = byte.TryParse(age, out Age);
                        if (result)
                        {
                        Exp: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the experience of seller ");
                            string exp = Console.ReadLine();
                            byte Exp;
                            result = byte.TryParse(exp, out Exp);
                            if (result && Exp < Age)
                            {

                                Seller seller = new Seller
                                {
                                    Surname = surname,
                                    Age = Age,
                                    Name = name,
                                    Experience = Exp,
                                    CarStore = carStore

                                };
                                var createdSeller = _sellerRepository.Create(seller);

                                if (createdSeller != null)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"successfully created with the id: {createdSeller.Id}" +
                                        $"name : {createdSeller.Name}, surname: {createdSeller.Surname}, experience : {createdSeller.Experience}," +
                                        $" age: {createdSeller.Age}, car store: {seller.CarStore}");
                                    carStore.Sellers.Add(seller);
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "could not create, something is wrong ");
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the experience correctly ");
                                goto Exp;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the age in the correct format ");
                            goto Age;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found with this id ");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "enter id in correct format");
                    goto ID;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found");
            }

        }
        #endregion
        #region Update
        public void Update()
        {
            var carStores = _carStoreRepository.GetAll();
            if (carStores.Count > 0)
            {
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id of one car store ");
                foreach (var carstore in carStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {carstore.Id}, name: {carstore.Name}," +
                        $" address : {carstore.Address}, phonenumber: {carstore.PhoneNumber}, owner : {carstore.Owner}");
                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var carStore = _carStoreRepository.Get(cs => cs.Id == Id);
                    if (carStore != null)
                    {

                        var sellers = _sellerRepository.GetAll();
                        if (sellers.Count > 0)
                        {
                        Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id");
                            foreach (var seller in sellers)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"id: {seller.Id}" +
                                       $"name : {seller.Name}, surname: {seller.Surname}, experience " +
                                       $": {seller.Experience}," +
                                       $" age: {seller.Age}, car store: {seller.CarStore}");

                            }
                            id = Console.ReadLine();
                            result = int.TryParse(id, out Id);
                            if (result)
                            {
                                var seller = _sellerRepository.Get(s => s.Id == Id);
                                if (seller != null)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new name of seller");
                                    string name = Console.ReadLine();
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new surname of seller");
                                    string surname = Console.ReadLine();
                                Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the  new age of seller ");
                                    string age = Console.ReadLine();
                                    byte Age;
                                    result = byte.TryParse(age, out Age);
                                    if (result)
                                    {
                                    exp: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new amount ");
                                        string exp = Console.ReadLine();
                                        byte Exp;
                                        result = byte.TryParse(exp, out Exp);
                                        if (result)
                                        {
                                        option: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "Please enter 1 to keep the seller in the same car store or" +
                                            " 2 if you want to change the carstore ");
                                            string option = Console.ReadLine();
                                            byte op;
                                            result = byte.TryParse(option, out op);
                                            if (result)
                                            {
                                                switch (op)
                                                {
                                                    case 1:

                                                        seller.Surname = surname;
                                                        seller.Name = name;
                                                        seller.Age = Age;
                                                        seller.Experience = Exp;
                                                        seller.CarStore = carStore;
                                                        _sellerRepository.Update(seller);
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"successfully updated. Name: {seller.Name}," +
                                                            $" surname : {seller.Surname}, age : {seller.Age}, experience : {seller.Experience} , carstore: {seller.CarStore}");

                                                        break;
                                                    case 2:
                                                        carStores = _carStoreRepository.GetAll(cs => cs.Id != carStore.Id && cs.Cars.Count > 0);
                                                        if (carStores.Count > 0)
                                                        {

                                                        csId: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id");
                                                            foreach (var carstore in carStores)
                                                            {
                                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {carstore.Id}, name: " +
                                                                    $"{carstore.Name},address : {carstore.Address}, phonenumber: {carstore.PhoneNumber}, owner : {carstore.Owner}");
                                                            }
                                                            id = Console.ReadLine();
                                                            result = int.TryParse(id, out Id);

                                                            if (result)
                                                            {
                                                                var choosenCarStore = _carStoreRepository.Get(cs => cs.Id == Id);
                                                                if (choosenCarStore != null)
                                                                {
                                                                    seller.Surname = surname;
                                                                    seller.Name = name;
                                                                    seller.Age = Age;
                                                                    seller.Experience = Exp;
                                                                    seller.CarStore = choosenCarStore;
                                                                    _sellerRepository.Update(seller);
                                                                    choosenCarStore.Sellers.Add(seller);
                                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"successfully updated. Name: {seller.Name}," +
                                                           $" surname : {seller.Surname}, age : {seller.Age}, experience : {seller.Experience} , carstore: {seller.CarStore}");

                                                                }
                                                                else
                                                                {
                                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found ");

                                                                }
                                                            }
                                                            else
                                                            {
                                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the id in the correct format ");
                                                                goto csId;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found");
                                                        }
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "enter option in correct format");
                                                goto option;
                                            }

                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the experience in the correct format ");
                                            goto exp;
                                        }


                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the age in the correct format ");
                                        goto Age;
                                    }

                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "nothing found with this ");

                                }

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the id in the correct format ");
                                goto Id;
                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no seller found");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found with this id ");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "enter id in correct format");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found");
            }
        }

        #endregion
        #region Delete
        public void Delete()
        {
            var carStores = _carStoreRepository.GetAll();
            if (carStores.Count > 0)
            {
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id of one car store ");
                foreach (var carstore in carStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {carstore.Id}, name: {carstore.Name}," +
                        $" address : {carstore.Address}, phonenumber: {carstore.PhoneNumber}, owner : {carstore.Owner}");
                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var carStore = _carStoreRepository.Get(cs => cs.Id == Id);
                    if (carStore != null)
                    {

                        var sellers = _sellerRepository.GetAll();
                        if (sellers.Count > 0)
                        {
                        Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id");
                            foreach (var seller in sellers)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"id: {seller.Id}" +
                                       $"name : {seller.Name}, surname: {seller.Surname}, experience " +
                                       $": {seller.Experience}," +
                                       $" age: {seller.Age}, car store: {seller.CarStore}");

                            }
                            id = Console.ReadLine();
                            result = int.TryParse(id, out Id);
                            if (result)
                            {
                                var seller = _sellerRepository.Get(s => s.Id == Id);
                                if (seller != null)
                                {
                                    _sellerRepository.Delete(seller);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "seller is successfully removed");
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "nothing found with this ");

                                }

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the id in the correct format ");
                                goto Id;
                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no owner found");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found with this id ");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "enter id in correct format");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found");
            }
        }
        #endregion
        #region GetAllSellersByCarStore
        public void GetAllSellersByCarStore()
        {
            var carStores = _carStoreRepository.GetAll();
            if (carStores.Count > 0)
            {
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id of one car store ");
                foreach (var carstore in carStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {carstore.Id}, name: {carstore.Name}," +
                        $" address : {carstore.Address}, phonenumber: {carstore.PhoneNumber}, owner : {carstore.Owner}");
                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var carStore = _carStoreRepository.Get(cs => cs.Id == Id);
                    if (carStore != null)
                    {

                        var sellers = _sellerRepository.GetAll(s => s.CarStore.Id == carStore.Id);
                        if (sellers.Count > 0)
                        {

                            foreach (var seller in sellers)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"id: {seller.Id}" +
                                       $"name : {seller.Name}, surname: {seller.Surname}, experience " +
                                       $": {seller.Experience}," +
                                       $" age: {seller.Age}, car store: {seller.CarStore}");
                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no seller found");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found with this id ");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "enter id in correct format");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found");
            }
        }
        #endregion
        #region GetAll
        public void GetAll()
        {
            var sellers = _sellerRepository.GetAll();
            if (sellers.Count > 0)
            {

                foreach (var seller in sellers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"id: {seller.Id}" +
                           $"name : {seller.Name}, surname: {seller.Surname}, experience " +
                           $": {seller.Experience}," +
                           $" age: {seller.Age}, car store: {seller.CarStore}");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no seller found");
            }

        }
        #endregion
    }
}
