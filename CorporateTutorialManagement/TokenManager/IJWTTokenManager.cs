using CorporateTutorialManagement.Models;

namespace CorporateTutorialManagement.TokenManager
{
    public interface IJWTTokenManager
    {
        Tokens Authenticate(String Username);
        
    }
}
