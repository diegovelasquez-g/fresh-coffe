namespace CFS.BAL.Contracts;

public interface IPasswordHasherService
{
    string Hash(string password);
    bool Verify(string passwordHash, string inputPassword);
}