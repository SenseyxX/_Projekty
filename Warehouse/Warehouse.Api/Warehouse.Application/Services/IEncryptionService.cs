namespace Warehouse.Application.Services
{
    public interface IEncryptionService
    {
        bool VerifyPassword(byte[] passwordHash, string password);
        byte[] EncodePassword(string password);
    }
}
