
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
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"successfully created with the id: {createdCar.Id}" +
                                        $"name : {createdCar.Name}, price: {createdCar.Price}, amount : {createdCar.Amount}, car store: {createdCar.CarStore}");

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
                    var carStore = _carStoreRepository.Get(cs => cs.Id == Id);
                    if (carStore != null)
                    {

                        var cars = _carRepository.GetAll();
                        if (cars.Count > 0)
                        {
                        Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id");
                            foreach (var car in cars)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {car.Id}, name: {car.Name}," +
                        $" price : {car.Price}, amount: {car.Amount}, color : {car.Color}, carstore : {car.CarStore}");
                            }
                            id = Console.ReadLine();
                            result = int.TryParse(id, out Id);
                            if (result)
                            {
                                var car = _carRepository.Get(c => c.Id == Id);
                                if (car != null)
                                {


                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new name of car");
                                    string name = Console.ReadLine();
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new color of car");
                                    string color = Console.ReadLine();
                                Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the  new price of car ");
                                    string price = Console.ReadLine();
                                    double Price;
                                    result = double.TryParse(price, out Price);
                                    if (result)
                                    {
                                    Amount: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new amount ");
                                        string amount = Console.ReadLine();
                                        int Amount;
                                        result = int.TryParse(amount, out Amount);
                                        if (result)
                                        {
                                        option: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "Please enter 1 to keep the car in the same car store or" +
                                            " 2 if you want to change the carstore ");
                                            string option = Console.ReadLine();
                                            byte op;
                                            result = byte.TryParse(option, out op);
                                            if (result)
                                            {
                                                switch (op)
                                                {
                                                    case 1:

                                                        car.Price = Price;
                                                        car.Amount = Amount;
                                                        car.Name = name;
                                                        car.Color = color;
                                                        car.CarStore = carStore;
                                                        _carRepository.Update(car);
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"successfully update. Name: {car.Name}," +
                                                            $" price : {car.Price}, amount : {car.Amount}, color : {car.Color} , carstore: {car.CarStore}");

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
                                                                        car.Price = Price;
                                                                        car.Amount = Amount;
                                                                        car.Name = name;
                                                                        car.Color = color;
                                                                    car.CarStore = choosenCarStore;
                                                                        _carRepository.Update(car);
                                                                    choosenCarStore.Cars.Add(car);
                                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"successfully updated the id: {car.Id}" +
                                    $"name : {car.Name}, price: {car.Price}, amount : {car.Amount}, car store: {car.CarStore}");
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
