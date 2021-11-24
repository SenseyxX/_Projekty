namespace Mag.Dtos.UserDtos
{
        public class UserAddDto
        {     
                
                public string Name { get; set; }                
                public string LastName { get; set; }
              
                public int SquadId { get; set; }
              
                public string PasswordHash { get; set; }
                public string ConfirmPassword { get; set; }

                public string Email { get; set; }
              
                public string PhoneNumber { get; set; }
        }
}
