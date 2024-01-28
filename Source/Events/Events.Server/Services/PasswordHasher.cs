using System.Security.Cryptography;
using System.Text;

namespace Events.Server.Services;
public class PasswordHasher
{
    private readonly string _salt;

    public PasswordHasher()
    {
        _salt = Guid.NewGuid().ToString();
    }

    public string HashPassword(string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password + _salt);

        using (var sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}
