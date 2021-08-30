using System;
using Warehouse.Domain.User.Entities;

namespace Warehouse.Application.Dtos
{
    public class UserDto
    {
        protected UserDto(
            Guid id,
            string name,
            string lastName,
            string email,
            string phoneNumber,
            Guid squadId,
            Guid teamId)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            SquadId = squadId;
            TeamId = teamId;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get;}
        public Guid SquadId { get; }
        public Guid TeamId { get; }

        public static explicit operator UserDto(User user)
            => new (
                user.Id,
                user.Name,
                user.LastName,
                user.Email,
                user.PhoneNumber,
                user.SquadId,
                user.TeamId);
	 }
}
