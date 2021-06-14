using System;
using System.Collections.Generic;
using Warehouse.Persistence.Entities.Abstractions;

namespace Warehouse.Persistence.Entities.User.Entities
{
    public sealed class User : Aggregate
    {
        public User(Guid id,
            string name,
            string lastName,
            byte[] passwordHash,
            string email,
            string phoneNumber,
            PermissionLevel permissionLevel,
            State state,
            Guid squadId)
            : base(id)
        {
            Name = name;
            LastName = lastName;
            PasswordHash = passwordHash;
            Email = email;
            PhoneNumber = phoneNumber;
            PermissionLevel = permissionLevel;
            State = state;
            SquadId = squadId;
            OwnedItems = new List<Item.Entities.Item>();
            StoredItems = new List<Item.Entities.Item>();
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid SquadId { get; }
        public State State { get; private set; }
        public PermissionLevel PermissionLevel { get; }
        public ICollection<Item.Entities.Item> OwnedItems { get; }
        public ICollection<Item.Entities.Item> StoredItems { get; }

        public bool UpdateName(string name)
        {
            if (Name == name || string.IsNullOrEmpty(name))
            {
                return false;
            }

            Name = name;
            return true;
        }

        public bool UpdateLastName(string lastname)
        {
            if (LastName == lastname || string.IsNullOrEmpty(lastname))
            {
                return false;
            }

            LastName = lastname;
            return true;
        }

        public bool UpdatePasswordHash(byte[] passwordHash)
        {
            if (PasswordHash == passwordHash || passwordHash.Length <= 0)
            {
                return false;
            }

            PasswordHash = passwordHash;
            return true;
        }

        public bool UpdateEmail(string email)
        {
            if (Email == email || string.IsNullOrEmpty(email))
            {
                return false;
            }

            Email = email;
            return true;
        }

        public bool UpdatePhoneNumber(string phoneNumber)
        {
            if (PhoneNumber == phoneNumber || string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            PhoneNumber = phoneNumber;
            return true;
        }

        public bool Activate()
        {
            if (State == State.Active)
            {
                return false;
            }

            State = State.Active;
            return true;
        }

        public bool Delete()
        {
            if (State == State.Deleted)
            {
                return false;
            }

            State = State.Deleted;
            return true;
        }
    }
}
