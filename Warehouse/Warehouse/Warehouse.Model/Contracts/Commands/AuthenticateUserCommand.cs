namespace Warehouse.Model.Contracts.Commands
{
    public sealed class AuthenticateUserCommand
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
