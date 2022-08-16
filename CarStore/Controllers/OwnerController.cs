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
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter the age in the correct format ");
                goto Age;
            }

        }
        public void Update()
        {

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
    }
}
