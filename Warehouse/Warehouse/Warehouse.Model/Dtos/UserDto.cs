using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class UserDto
    {
        private UserDto(string name, string lastName,string email,string phonenumber)
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
        //public ICollection<Item> OwnedItems { get; set; }
        //public ICollection<Item> StoredItems { get; set; }

                public static explicit operator UserDto(User user)
            => new (user.Name, user.LastName,user.Email,user.PhoneNumber);
    }
}
