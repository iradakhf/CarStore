

using Core.Abstracts;

namespace Core
{
    public class Seller : Person, IEntity
    {
        public override string Name { get ; set ; }
        public override string Surname { get ; set ; }
        public override byte Age { get; set ; }
        public byte Experience { get; set; }
        public int Id { get; set; }
        public CarStore CarStore { get; set; }
    }
}
