using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Persistence.Entities;
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
            string phoneNumber,
            PermissionLevel permissionLevel,
            State state,
            Guid squadId,
            Guid teamId,
            IEnumerable<ItemDto> ownedItems,
            IEnumerable<ItemDto> storedItems)
            :base (id,
                   name,
                   lastName,
                   email,
                   phoneNumber,
                   squadId,
                   teamId)
            {
                PermissionLevel = permissionLevel;
                State = state;
                State = state;
                OwnedItems = ownedItems;
                StoredItems = storedItems;
            }

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
                         user.TeamId,
                         user.OwnedItems.Select(ownedItems => (ItemDto) ownedItems),
                         user.StoredItems.Select(storesItems => (ItemDto) storesItems));
    }
}
