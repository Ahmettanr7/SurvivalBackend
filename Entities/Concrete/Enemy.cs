using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Enemy:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Healty { get; set; }
        public int Point { get; set; }
        public int ForcedTax { get; set; }
        public string Message { get; set; }
    }
}
