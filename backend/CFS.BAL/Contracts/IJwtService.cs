using CFS.DAL.Models;

namespace CFS.BAL.Contracts;

public interface IJwtService
{
    string GenerateToken(User user);
}