using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts
{
    public abstract class Person
    {
        public abstract string Name { get; set; }
        public abstract string Surname { get; set; }
        public abstract byte Age { get; set; }
    }
}
