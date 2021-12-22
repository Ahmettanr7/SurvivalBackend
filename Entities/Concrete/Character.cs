using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Character:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public int Healty { get; set; }
    }
}
