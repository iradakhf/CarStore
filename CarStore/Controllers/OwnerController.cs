using Core;
using Core.Helpers;
using DataAccess.Implementations;

namespace Manage.Controllers
{
    public class OwnerController
    {
        public OwnerRepository _ownerRepository;
        public OwnerController()
        {
            _ownerRepository = new OwnerRepository();
        }
       #region Create
        public void Create()
        {
             ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the surname");
            string surname = Console.ReadLine();
            Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please enter the age ");
            string age = Console.ReadLine();
            byte Age;
            bool result = byte.TryParse(age, out Age);
            if (result)
            {
                Owner owner = new Owner
                {
                    Age = Age,
                    Name=name,
                    Surname=surname
                  
                };
                var own = _ownerRepository.Create(owner);
                if (own!=null)
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the age in the correct format ");
                goto Age;
            }

        }
        #endregion
        #region Update
        public void Update()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ID:  ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose the id");
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
        #region Get
        public void Get()
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
