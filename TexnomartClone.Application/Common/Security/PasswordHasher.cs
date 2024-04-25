using System.Security.Cryptography;
using System.Text;

namespace TexnomartClone.Application.Common.Security;

public static class PasswordHasher
{
    public static string GetHash(this string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);

            byte[] hash = sha256.ComputeHash(bytes);

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                stringBuilder.Append(hash[i].ToString("x2"));
            }


            return stringBuilder.ToString();
        }
    }
}
