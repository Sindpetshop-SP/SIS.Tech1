using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Util
{
    public sealed class DecryptTransformer
    {
        // Atributos
        private EncryptAlgorithm.EncryptionAlgorithm algorithmID;

        private byte[] initVec;
        // Propriedades
        public byte[] IV
        {
            set { initVec = value; }
        }

        // Métodos
        public DecryptTransformer(EncryptAlgorithm.EncryptionAlgorithm deCryptId)
        {
            algorithmID = deCryptId;
        }

        public ICryptoTransform GetCryptoServiceProvider(byte[] bytesKey)
        {
            switch (algorithmID)
            {
                case EncryptAlgorithm.EncryptionAlgorithm.Des:
                    DES des = new DESCryptoServiceProvider();
                    des.Mode = CipherMode.CBC;
                    des.Key = bytesKey;
                    des.IV = initVec;
                    return des.CreateDecryptor();

                case EncryptAlgorithm.EncryptionAlgorithm.Rc2:
                    RC2 rc = new RC2CryptoServiceProvider();
                    rc.Mode = CipherMode.CBC;
                    return rc.CreateDecryptor(bytesKey, initVec);

                case EncryptAlgorithm.EncryptionAlgorithm.Rijndael:
                    Rijndael rijndael = new RijndaelManaged();
                    rijndael.Mode = CipherMode.CBC;
                    return rijndael.CreateDecryptor(bytesKey, initVec);

                case EncryptAlgorithm.EncryptionAlgorithm.TripleDes:
                    TripleDES edes = new TripleDESCryptoServiceProvider();
                    edes.Mode = CipherMode.CBC;
                    return edes.CreateDecryptor(bytesKey, initVec);
            }
            throw new CryptographicException(("Algorithm ID '" + algorithmID + "' not supported."));
        }

    }
}
