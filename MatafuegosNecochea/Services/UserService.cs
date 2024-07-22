using Microsoft.IdentityModel.Tokens;

namespace MatafuegosNecochea.Services
{   
    public class UserService
    {
        static void Authorization(string username, string password)
        {
            JsonContent.Create(new { username, password });
        }
    }
}
