using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Util
{
    public sealed class Encryptor : IDisposable
    {
        // Atributos
        private byte[] _encKey;
        private byte[] _initVec;

        private readonly EncryptTransformer _transformer;
        // Propriedades
        public byte[] Iv
        {
            get { return _initVec; }
            set { _initVec = value; }
        }

        public byte[] Key
        {
            get { return _encKey; }
        }

        // Métodos
        public Encryptor(EncryptAlgorithm.EncryptionAlgorithm algId)
        {
            _transformer = new EncryptTransformer(algId);
        }

        public byte[] Encrypt(byte[] bytesData, byte[] bytesKey)
        {
            var stream = new MemoryStream();
            _transformer.IV = _initVec;
            var cryptoServiceProvider = _transformer.GetCryptoServiceProvider(bytesKey);
            var cryptoStream = new CryptoStream(stream, cryptoServiceProvider, CryptoStreamMode.Write);

            try
            {
                cryptoStream.Write(bytesData, 0, bytesData.Length);
            }
            catch (Exception exception)
            {
                throw new Exception("Ocorreu um erro enquanto escrevia o dado criptografado no stream: " + exception.Message);
            }

            _encKey = _transformer.Key;
            _initVec = _transformer.IV;
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            return stream.ToArray();
        }

        public void Dispose()
        {
            _encKey = null;
            _initVec = null;
        }
    }
}
