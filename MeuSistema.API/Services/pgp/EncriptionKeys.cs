using MySystem.Domain.Entitys;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Text;

namespace MySystem.API.Services.pgp
{
    public class EncriptionKeys
    {
        private readonly string _identity;
        private readonly string _password;
        private readonly DateTime _dateTime;
        private readonly string _pathKeyAcess = Path.Combine(@"D:\Projetos\MySystem\MeuSistema.API\Resources", "KeyAcess");


        public PgpPublicKey PublicKey { get; private set; }

        public PgpPrivateKey PrivateKey { get; private set; }

        public PgpSecretKey SecretKey { get; private set; }

        public EncriptionKeys(User user)
        {
            _identity = user.Email;
            _password = user.Password;
            _dateTime = user.Date;

            LoadKey();
            SaveKey(user.Id);
        }

        private void LoadKey()
        {
            SecretKey = GetSecretKey();
            PrivateKey = GetPrivateKey();
            PublicKey = GetPgpPublicKey();
        }

        private void SaveKey(int userId)
        {

        }

        private PgpSecretKey GetSecretKey()
        {
            return GeneratePgpKeys(GenerateRsaKeys(GenerateSeed()));
        }

        private PgpPrivateKey GetPrivateKey()
        {
            return SecretKey.ExtractPrivateKey(_password.ToCharArray());
        }

        private PgpPublicKey GetPgpPublicKey()
        {
            return SecretKey.PublicKey;
        }

        #region keys string

        private string GetSecretKey(PgpSecretKey secretKey)
        {
            var secretMemStream = new MemoryStream();
            var secretArmoredStream = new ArmoredOutputStream(secretMemStream);
            secretKey.Encode(secretArmoredStream);
            secretArmoredStream.Close();
            var ascPgpSecretKey = Encoding.ASCII.GetString(secretMemStream.ToArray());
            return ascPgpSecretKey;
        }

        private string GetPublicKey(PgpSecretKey secretKey)
        {
            var pubMemStream = new MemoryStream();
            var pubArmoredStream = new ArmoredOutputStream(pubMemStream);
            secretKey.PublicKey.Encode(pubArmoredStream);
            pubArmoredStream.Close();
            var ascPgpPublicKey = Encoding.ASCII.GetString(pubMemStream.ToArray());
            return ascPgpPublicKey;
        }

        #endregion


        private byte[] GenerateSeed()
        {
            //Hash the passphrasse 50,000 times
            var passPhraseBytes = new byte[_password.Length * sizeof(char)];
            Buffer.BlockCopy(_password.ToCharArray(), 0, passPhraseBytes, 0, passPhraseBytes.Length);
            var digester = new Sha256Digest();
            var seed = new byte[digester.GetDigestSize()];
            digester.BlockUpdate(seed, 0, seed.Length);
            digester.DoFinal(seed, 0);
            for (var i = 0; i < 49999; i++)
            {
                digester = new Sha256Digest();
                digester.BlockUpdate(seed, 0, seed.Length);
                digester.DoFinal(seed, 0);
            }
            return seed;
        }

        private AsymmetricCipherKeyPair GenerateRsaKeys(byte[] seed)
        {
            SecureRandom sr = new SecureRandom();
            sr.SetSeed(seed);

            var kpg = new RsaKeyPairGenerator();
            kpg.Init(new RsaKeyGenerationParameters(BigInteger.ValueOf(0x13), sr, 4096, 8)); ;
            AsymmetricCipherKeyPair keys = kpg.GenerateKeyPair();
            return keys;
        }

        private PgpSecretKey GeneratePgpKeys(AsymmetricCipherKeyPair keys)
        {
            var secretKey = new PgpSecretKey(
                PgpSignature.DefaultCertification,
                new PgpKeyPair(PublicKeyAlgorithmTag.RsaGeneral, keys.Public, keys.Private, _dateTime),
                _identity,
                SymmetricKeyAlgorithmTag.Cast5,
                HashAlgorithmTag.Sha256,
                _password.ToCharArray(),
                true,
                null,
                null,
                new SecureRandom());

            return secretKey;
        }
    }
}
