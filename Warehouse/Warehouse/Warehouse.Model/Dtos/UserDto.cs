using System;
using Warehouse.Persistence.Entities.User.Entities;

namespace Warehouse.Model.Dtos
{
    public class UserDto
    {
        protected UserDto(Guid id,string name, string lastName,string email,string phoneNumber)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

	   public Guid Id { get; set; }
	   public string Name { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get;}

        public static explicit operator UserDto(User user)
            => new (user.Id,
                    user.Name,
                    user.LastName,
                    user.Email,
                    user.PhoneNumber);
    }
}
