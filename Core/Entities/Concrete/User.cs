using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public Byte[] PasswordSalt { get; set; }
        public Byte[] PasswordHash { get; set; }
    }
}
