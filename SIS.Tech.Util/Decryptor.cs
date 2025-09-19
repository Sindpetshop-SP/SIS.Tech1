using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Util
{
    public sealed class Decryptor
    {
        // Atributos
        private byte[] initVec;

        private DecryptTransformer transformer;
        // Propriedades
        public byte[] IV
        {
            set { this.initVec = value; }
        }

        // Métodos
        public Decryptor(EncryptAlgorithm.EncryptionAlgorithm algId)
        {
            this.transformer = new DecryptTransformer(algId);
        }

        public byte[] Decrypt(byte[] bytesData, byte[] bytesKey)
        {
            MemoryStream stream = new MemoryStream();
            this.transformer.IV = this.initVec;
            ICryptoTransform cryptoServiceProvider = this.transformer.GetCryptoServiceProvider(bytesKey);
            CryptoStream stream2 = new CryptoStream(stream, cryptoServiceProvider, CryptoStreamMode.Write);
            try
            {
                stream2.Write(bytesData, 0, bytesData.Length);
            }
            catch (Exception exception)
            {
                throw new Exception("Ocorreu um erro enquanto escrevia o dado criptografado no stream: " + exception.Message);
            }
            stream2.FlushFinalBlock();
            stream2.Close();
            return stream.ToArray();
        }
    }
}
