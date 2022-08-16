
using Core;
using Core.Helpers;
using DataAccess.Implementations;

namespace Manage.Controllers
{
    public class CarController
    {
        public CarRepository _carRepository;
        public CarStoreRepository _carStoreRepository;
        public CarController()
        {
            _carRepository = new CarRepository();
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

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the name of car");
                        string name = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the color of car");
                        string color = Console.ReadLine();
                    Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the price of car ");
                        string price = Console.ReadLine();
                        double Price;
                        result = double.TryParse(price, out Price);
                        if (result)
                        {
                        Amount: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the amount ");
                            string amount = Console.ReadLine();
                            int Amount;
                            result = int.TryParse(amount, out Amount);
                            if (result)
                            {
                                Car car = new Car
                                {
                                    Price = Price,
                                    Amount = Amount,
                                    Name = name,
                                    Color = color

                                };
                                var createdCar = _carRepository.Create(car);
                                if (createdCar != null)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "successfully created ");

                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "could not create, something is wrong ");
                                }

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the amount in the correct format ");
                                goto Amount;
                            }


                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the price in the correct format ");
                            goto Price;
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
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {owner.Id}, name: {owner.Name}," +
                        $" surname : {owner.Surname}, age: {owner.Age}");
                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == Id);
                    if (owner != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new name");
                        string name = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new surname");
                        string surname = Console.ReadLine();
                    Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new age ");
                        string age = Console.ReadLine();
                        byte Age;
                        result = byte.TryParse(age, out Age);
                        if (result)
                        {

                            owner.Age = Age;
                            owner.Name = name;
                            owner.Surname = surname;
                            _ownerRepository.Update(owner);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"updated successfully with the id: {owner.Id}" +
                                $", name {owner.Name}, surname : {owner.Surname}, age: {owner.Age} ");

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
                    goto ID;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no owner found");
            }
        }
        #endregion
        #region Delete
        public void Delete()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {owner.Id}, name: {owner.Name}," +
                        $" surname : {owner.Surname}, age: {owner.Age}");
                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == Id);
                    if (owner != null)
                    {
                        _ownerRepository.Delete(owner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"id : {owner.Id}, name : {owner.Name}, surname:" +
                            $"{owner.Surname}, age: {owner.Age} removed successfully ");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "nothing found with this ");

                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the id in the correct format ");
                    goto ID;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no owner found");
            }
        }
        #endregion
        public void GetCarByCarStore()
        {

        }
        #region GetAll
        public void GetAll()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                foreach (var owner in owners)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"id : {owner.Id}, name : {owner.Name}, surname:" +
                        $"{owner.Surname}, age: {owner.Age} removed successfully ");

                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no owner found");
            }
        }
        #endregion
    }
}
