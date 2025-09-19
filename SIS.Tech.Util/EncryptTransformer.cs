using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Util
{
    public sealed class EncryptTransformer
    {
        // Atributos
        private EncryptAlgorithm.EncryptionAlgorithm algorithmID;
        //private byte[] initVec;
        //private byte[] encKey;

        // Propriedades
        public byte[] IV { get; set; }
        //{
        //    get { return initVec; }
        //    set { initVec = value; }
        //}

        public byte[] Key { get; set; }
        //{
        //    get { return encKey; }
        //}


        public EncryptTransformer(EncryptAlgorithm.EncryptionAlgorithm algId)
        {
            algorithmID = algId;
        }

        // Métodos
        public ICryptoTransform GetCryptoServiceProvider(byte[] bytesKey)
        {
            // Escolhe o provedor
            switch (algorithmID)
            {
                case EncryptAlgorithm.EncryptionAlgorithm.Des:
                    DES des = new DESCryptoServiceProvider();
                    des.Mode = CipherMode.CBC;
                    // Verifica se a chave foi fornecida.
                    if (bytesKey == null)
                    {
                        this.Key = des.Key;
                    }
                    else
                    {
                        des.Key = bytesKey;
                        this.Key = des.Key;
                    }
                    // Verifica se o client foi fornecido em um vetor inicializado.
                    if (this.IV == null)
                    {
                        // Faz a criação do algoritimo 
                        this.IV = des.IV;
                    }
                    else
                    {
                        // Ou lhe repassa o algoritimo
                        des.IV = this.IV;
                    }
                    return des.CreateEncryptor();
                case EncryptAlgorithm.EncryptionAlgorithm.TripleDes:
                    TripleDES des3 = new TripleDESCryptoServiceProvider();
                    des3.Mode = CipherMode.CBC;

                    // Verifica se a chave foi fornecida.
                    if (bytesKey == null)
                    {
                        this.Key = des3.Key;
                    }
                    else
                    {
                        des3.Key = bytesKey;
                        this.Key = des3.Key;
                    }
                    // Verifica se o client foi fornecido um IV 
                    if (this.IV == null)
                    {
                        // Faz a criação do algoritimo 
                        this.IV = des3.IV;
                    }
                    else
                    {
                        // Ou lhe repassa o algoritimo
                        des3.IV = this.IV;
                    }
                    return des3.CreateEncryptor();

                case EncryptAlgorithm.EncryptionAlgorithm.Rc2:
                    RC2 rc2 = new RC2CryptoServiceProvider();
                    rc2.Mode = CipherMode.CBC;

                    // Verifica se a chave foi fornecida 
                    if (bytesKey == null)
                    {
                        this.Key = rc2.Key;
                    }
                    else
                    {
                        rc2.Key = bytesKey;
                        this.Key = rc2.Key;
                    }
                    // Verifica se o client foi fornecido um IV 
                    if (this.IV == null)
                    {
                        // Faz a criação do algoritimo 
                        this.IV = rc2.IV;
                    }
                    else
                    {
                        // Ou lhe repassa o algoritimo 
                        rc2.IV = this.IV;
                    }
                    return rc2.CreateEncryptor();
                case EncryptAlgorithm.EncryptionAlgorithm.Rijndael:
                    Rijndael rijndael = new RijndaelManaged();
                    rijndael.Mode = CipherMode.CBC;

                    // Verifica se a chave foi fornecida 
                    if (bytesKey == null)
                    {
                        this.Key = rijndael.Key;
                    }
                    else
                    {
                        rijndael.Key = bytesKey;
                        this.Key = rijndael.Key;
                    }
                    // Verifica se o client foi fornecido um IV 
                    if (this.IV == null)
                    {
                        // Faz a criação do algoritimo 
                        this.IV = rijndael.IV;
                    }
                    else
                    {
                        // Ou lhe repassa o algoritimo 
                        rijndael.IV = this.IV;
                    }
                    return rijndael.CreateEncryptor();

                default:
                    throw new CryptographicException(string.Format("Algorítimo ID {0} não é suportado.", algorithmID.ToString()));
            }
        }

    }
}
