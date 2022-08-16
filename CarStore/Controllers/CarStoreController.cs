

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
        public void Update()
        {

        }
        public void Delete()
        {

        }
        public void GetCarStoresByOwner()
        {

        }
        public void GetAll()
        {

        }
    }
}
