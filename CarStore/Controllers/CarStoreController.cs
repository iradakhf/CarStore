

using Core;
using Core.Helpers;
using DataAccess.Implementations;

namespace Manage.Controllers
{
    public class CarStoreController
    {
        public CarStoreRepository _carStoreRepository;
        public OwnerRepository _ownerRepository;
        public CarStoreController()
        {
            _carStoreRepository = new CarStoreRepository();
            _ownerRepository = new OwnerRepository();
        }
        #region Create
        public void Create()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id of one owner to create car store");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {owner.Id}, name: {owner.Name}, surname : {owner.Surname}" +
                        $" age : {owner.Age}");
                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == Id);
                    if (owner != null)
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the name of car store");
                        string name = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the address of car store");
                        string address = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the phone number of car store ");
                        string phoneNumber = Console.ReadLine();

                        CarStore carStore = new CarStore
                        {
                            Address = address,
                            Name = name,
                            PhoneNumber = phoneNumber,
                            Owner = owner

                        };
                        var createdCarStore = _carStoreRepository.Create(carStore);
                        if (createdCarStore != null)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"successfully created with the id: {createdCarStore.Id}" +
                                $"name : {createdCarStore.Name}, address: {createdCarStore.Address}, phone number : {createdCarStore.PhoneNumber}, owner: {createdCarStore.Owner}");
                            owner.CarStores.Add(carStore);
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "could not create, something is wrong ");
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no owner found with this id ");

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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no owner found");
            }

        }
        #endregion
        #region Update
        public void Update()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id of one owner ");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {owner.Id}, name: {owner.Name}, " +
                        $"surname : {owner.Surname}" +
                        $" age : {owner.Age}");
                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == Id);
                    if (owner != null)
                    {

                        var carStores = _carStoreRepository.GetAll();
                        if (carStores.Count > 0)
                        {
                        Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id");
                            foreach (var carStore in carStores)
                            {

                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $" id: {carStore.Id}" +
                                    $"name : {carStore.Name}, address: {carStore.Address}, phone number : {carStore.PhoneNumber}, " +
                                    $"owner: {carStore.Owner}");
                            }
                            id = Console.ReadLine();
                            result = int.TryParse(id, out Id);
                            if (result)
                            {
                                var carStore = _carStoreRepository.Get(cs => cs.Id == Id);
                                if (carStore != null)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new name of car store");
                                    string name = Console.ReadLine();
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the new address of car store");
                                    string address = Console.ReadLine();
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the  new phone number of car store ");
                                    string phoneNumber = Console.ReadLine();

                                option: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "Please enter 1 to keep the car store in the same owner store or" +
                                        " 2 if you want to change the owner ");
                                    string option = Console.ReadLine();
                                    byte op;
                                    result = byte.TryParse(option, out op);
                                    if (result)
                                    {
                                        switch (op)
                                        {
                                            case 1:
                                                carStore.Name = name;
                                                carStore.Address = address;
                                                carStore.PhoneNumber = phoneNumber;
                                                carStore.Owner = owner;
                                                _carStoreRepository.Update(carStore);
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"successfully updated with the id: {carStore.Id}" +
                            $"name : {carStore.Name}, address: {carStore.Address}, phone number : {carStore.PhoneNumber}, " +
                            $"owner: {carStore.Owner}");
                                                break;
                                            case 2:
                                                owners = _ownerRepository.GetAll(o => o.Id != owner.Id && owner.CarStores.Count > 0);
                                                if (owners.Count > 0)
                                                {

                                                oId: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id");
                                                    foreach (var own in owners)
                                                    {
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {owner.Id}, name: {owner.Name}, " +
                                                         $"surname : {owner.Surname}" +
                                                         $" age : {owner.Age}");
                                                    }
                                                    id = Console.ReadLine();
                                                    result = int.TryParse(id, out Id);

                                                    if (result)
                                                    {
                                                        var choosenOwner = _ownerRepository.Get(o => o.Id == Id);
                                                        if (choosenOwner != null)
                                                        {
                                                            carStore.Name = name;
                                                            carStore.Address = address;
                                                            carStore.PhoneNumber = phoneNumber;
                                                            carStore.Owner = choosenOwner;
                                                            _carStoreRepository.Update(carStore);
                                                            choosenOwner.CarStores.Add(carStore);
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"successfully updated the id: {carStore.Id}" +
                            $"name : {carStore.Name}, address: {carStore.Address}, phone number : {carStore.PhoneNumber}, car store owner: {carStore.Owner}");
                                                        }
                                                        else
                                                        {
                                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found ");

                                                        }
                                                    }
                                                    else
                                                    {
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the id in the correct format ");
                                                        goto oId;
                                                    }
                                                }
                                                else
                                                {
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no owner found");
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
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store owner found with this id ");

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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store owner found");
            }
        }

        #endregion
        public void Delete()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id of one owner ");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {owner.Id}, name: {owner.Name}, " +
                        $"surname : {owner.Surname}" +
                        $" age : {owner.Age}");
                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == Id);
                    if (owner != null)
                    {

                        var carStores = _carStoreRepository.GetAll();
                        if (carStores.Count > 0)
                        {
                        Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id");
                            foreach (var carStore in carStores)
                            {

                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $" id: {carStore.Id}" +
                                    $"name : {carStore.Name}, address: {carStore.Address}, phone number : {carStore.PhoneNumber}, " +
                                    $"owner: {carStore.Owner}");
                            }
                            id = Console.ReadLine();
                            result = int.TryParse(id, out Id);
                            if (result)
                            {
                                var carStore = _carStoreRepository.Get(cs => cs.Id == Id);
                                if (carStore != null)
                                {
                                    _carStoreRepository.Delete(carStore);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "successfully deleted");

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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store owner found with this id ");

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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store owner found");
            }
        }
        public void GetCarStoresByOwner()
        {

            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id of one owner ");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, $"id : {owner.Id}, name: {owner.Name}, " +
                        $"surname : {owner.Surname}" +
                        $" age : {owner.Age}");
                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == Id);
                    if (owner != null)
                    {

                        var carStores = _carStoreRepository.GetAll(cs => cs.Owner.Id == owner.Id);
                        if (carStores.Count > 0)
                        {
                            foreach (var carStore in carStores)
                            {

                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $" id: {carStore.Id}" +
                                    $"name : {carStore.Name}, address: {carStore.Address}, phone number : {carStore.PhoneNumber}, " +
                                    $"owner: {carStore.Owner}");
                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found");
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
        public void GetAll()
        {


            var carStores = _carStoreRepository.GetAll();
            if (carStores.Count > 0)
            {
                foreach (var carStore in carStores)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $" id: {carStore.Id}" +
                        $"name : {carStore.Name}, address: {carStore.Address}, phone number : {carStore.PhoneNumber}, " +
                        $"owner: {carStore.Owner}");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no car store found");
            }
        }

    }
}
