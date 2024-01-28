using System.Security.Cryptography;
using System.Text;

namespace Events.Server.Services
{
    public static class PasswordHash
    {

        public static string GeneratePasswordHash(string password, string salt)
        {
            var combined = $"{password}{salt}";
            using (var sha3 = SHA3_384.Create())
            {
                var hash = sha3.ComputeHash(Encoding.UTF8.GetBytes(combined));
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }


    }
}
