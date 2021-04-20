using System;
using System.Collections.Generic;


namespace Warehouse.Persistence.Entities
{
    public sealed class User : Entity
    {
        public User(Guid id, string name, string lastname, string passwordhash, string email, string phonenumber)
            : base(id)
        {
            Name = name;
            LastName = lastname;
            PasswordHash = passwordhash;
            Email = email;
            PhoneNumber = phonenumber;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid SquadId { get; }
        public Guid RoleId { get; }
        public Role.Role Role { get; } // error przy braku :	'Role' is a namespace but is used like a type Warehouse.Persistence C:\Users\Oskar\source\_Projekty\Warehouse\Warehouse\Warehouse.Persistence\Entities\User.cs	16	Active
        public ICollection<Item> OwnedItems { get; }
        public ICollection<Item> StoredItems { get; }

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
