

using Core.Abstracts;

namespace Core
{
    public class Owner : Person, IEntity
    {
        public int Id { get ; set; }
        public override string Name { get; set ; }
        public override string Surname { get ; set ; }
        public override byte Age { get ; set; }
        public List<CarStore> CarStores { get; set; }
    }
}
