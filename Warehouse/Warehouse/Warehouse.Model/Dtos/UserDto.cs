using System.Collections.Generic;
using System.Linq;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.User.Entities;

namespace Warehouse.Model.Dtos
{
    public class UserDto
    {
        protected UserDto(string name, string lastName,string email,string phonenumber)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phonenumber;
        }

        public string Name { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get;}

        //public Guid SquadId { get; set; }
        //public Guid RoleId { get; set; }
        //public Role.Role Role { get; set; }
        //public ICollection<Item> StoredItems { get; set; }

        public static explicit operator UserDto(User user)
            => new (user.Name, user.LastName,user.Email,user.PhoneNumber);
    }
}
