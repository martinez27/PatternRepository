using Microsoft.Extensions.Options;
using PatternRepository.Core.Interface.Utils;
using PatternRepository.Core.Options;
using System.Security.Cryptography;
namespace PatternRepository.Core.Utils
{
    public class PasswordService : IPasswordHasher
    {
        private readonly PasswordOptions _options;

        public PasswordService(IOptions<PasswordOptions> options)
        {
            _options = options.Value;
        }

        public bool Check(string hash, string password)
        {
            string[] parts = hash.Split('.', 3);
            if (parts.Length != 3)
            {
                throw new FormatException("Formato Incorrecto");
            }

            int iterations = Convert.ToInt32(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512))
            {
                byte[] keyToCheck = algorithm.GetBytes(_options.KeySize);
                return keyToCheck.SequenceEqual(key);
            }
        }

        public string Hash(string password)
        {
            //Interando

            using (var algorithm = new Rfc2898DeriveBytes(password,_options.SaltSize,_options.Iteration,HashAlgorithmName.SHA512))
            {
                string key = Convert.ToBase64String(algorithm.GetBytes(_options.KeySize));
                string salt = Convert.ToBase64String(algorithm.Salt);

                return $"{_options.Iteration}.{salt}.{key}";
            }
        }
    }
}
