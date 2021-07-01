using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item.Entities;
using Warehouse.Persistence.Entities.User;
using Warehouse.Persistence.Entities.User.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class FullUserDto : UserDto
    {
        private FullUserDto(Guid id,
                            string name,
                            string lastName,
                            string email,
                            string phonenumber,
                            PermissionLevel permisionLevel,
                            State state,
                            Guid squadId,
                            IEnumerable<ItemDto> ownedItems,
                            IEnumerable<ItemDto> storedItems)
                            : base(id,name, lastName, email, phonenumber)
            {            
            PermissionLevel = permisionLevel;
            State = state;
            SquadId = squadId;
            State = state;
            OwnedItems = ownedItems;
            StoredItems = storedItems;
            }

            public Guid SquadId { get; }
            public State State { get; private set; }
            public PermissionLevel PermissionLevel { get; }
            public IEnumerable<ItemDto> OwnedItems { get; }   
            public IEnumerable<ItemDto> StoredItems { get; }

            public static explicit operator FullUserDto(User user)
                  => new(user.Id,
                         user.Name,
                         user.LastName,
                         user.Email,
                         user.PhoneNumber,
                         user.PermissionLevel,
                         user.State,
                         user.SquadId,
                         user.OwnedItems.Select(ownedItems => (ItemDto) ownedItems),
                         user.StoredItems.Select(storesItems => (ItemDto) storesItems)); 
    }
}
