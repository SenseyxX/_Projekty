using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class UserDto
    {
        private UserDto(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public string Name { get; }
        public string LastName { get; }

        public static explicit operator UserDto(User user)
            => new (user.Name, user.LastName);
    }
}
