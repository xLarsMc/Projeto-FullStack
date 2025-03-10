using System.Security.Cryptography;
using System.Text;

namespace Solution.Application.Services.Criptografia
{
    public class PasswordEncrypter
    {
        public string Encrypt(string password)
        {
            var chaveAdicional = "ABC";

            var newPassword = $"{password}{chaveAdicional}";

            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = SHA512.HashData(bytes);
            return BytesToString(hashBytes);
        }

        private static string BytesToString(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach(byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }

            return sb.ToString();
        }
    }
}
