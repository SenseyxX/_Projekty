using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.User.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class FullUserDto : UserDto
    {
        private FullUserDto(string name, string lastName, string email, string phonenumber, IEnumerable<ItemDto> ownedItems)
            : base(name, lastName, email, phonenumber)
        {
            OwnedItems = ownedItems;
        }


        public IEnumerable<ItemDto> OwnedItems { get; init; }

        public static explicit operator FullUserDto(User user)
        {
            return new FullUserDto(user.Name, user.LastName, user.Email, user.PhoneNumber, user.OwnedItems.Select(item => (ItemDto) item));
        }
    }
}
