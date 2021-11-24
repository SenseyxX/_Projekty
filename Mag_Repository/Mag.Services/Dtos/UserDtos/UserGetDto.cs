namespace Mag.Dtos
{
        public class UserGetDto: BaseEntity
        {                
                public string Name { get; set; }                
                public string LastName { get; set; }
                public int SquadId { get; set; }                             
                public string Email { get; set; }                
                public string PhoneNumber { get; set; }

        public static explicit operator UserGetDto(User user) => new UserGetDto
        {
            Name = user.Name,
            LastName = user.LastName,
            SquadId = user.SquadId,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
        };
    }
}
