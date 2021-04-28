using System;
using System.Collections.Generic;
using Warehouse.Persistence.Entities.Abstractions;


namespace Warehouse.Persistence.Entities
{
    public sealed class User : Aggregate
    {
        public User(
            Guid id,
            string name,
            string lastName,
            string passwordHash,
            string email,
            string phoneNumber,
            Guid squadId,
            Guid roleId)
            : base(id)
        {
            Name = name;
            LastName = lastName;
            PasswordHash = passwordHash;
            Email = email;
            PhoneNumber = phoneNumber;
            SquadId = squadId;
            RoleId = roleId;
            OwnedItems = new List<Item.Entities.Item>();
            StoredItems = new List<Item.Entities.Item>();
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid SquadId { get; }
        public Guid RoleId { get; }
        public Role.Role Role { get; }
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

        public bool UpdatePasswordHash(string passwordhash)
        {
            if (PasswordHash == passwordhash || string.IsNullOrEmpty(passwordhash))
            {
                return false;
            }

            PasswordHash = passwordhash;
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
        public bool UpdatePhoneNumber(string phonenumber)
        {
            if (PhoneNumber == phonenumber || string.IsNullOrEmpty(phonenumber))
            {
                return false;
            }

            PhoneNumber = phonenumber;
            return true;
        }
    }
}
