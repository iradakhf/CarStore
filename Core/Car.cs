using Core.Abstracts;

namespace Core
{
    public class Car : IEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string Color { get; set; }
        public CarStore CarStore { get; set; }
        public int Id { get ; set ; }
    }
}