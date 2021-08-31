namespace Warehouse.Application.Dtos
{
    public sealed class AuthenticationResultDto
    {
        public bool IsAuthenticated { get; init; }
        public string Jwt { get; init; }
        public UserDto TokenOwner { get; init; }
    }
}
