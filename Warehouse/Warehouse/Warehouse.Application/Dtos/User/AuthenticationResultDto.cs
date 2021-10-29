namespace Warehouse.Application.Dtos.User
{
    public sealed class AuthenticationResultDto
    {
        public bool IsAuthenticated { get; init; }
        public string Jwt { get; init; }
        public UserDto TokenOwner { get; init; }
    }
}
