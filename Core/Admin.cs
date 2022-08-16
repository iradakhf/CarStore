
using Core.Abstracts;

namespace Core
{
    public class Admin : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
