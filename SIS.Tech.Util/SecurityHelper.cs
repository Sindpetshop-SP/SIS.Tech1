using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Util
{
    public sealed class SecurityHelper
    {
        // Atributos
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("P$YT R52@D/#X41@3S8! 82 2@$T6QS!$96");
        private static readonly byte[] Key3Desrijn = Encoding.UTF8.GetBytes("P@W)D3#Q05LK&W!0");
        private static readonly byte[] Keydes = Encoding.UTF8.GetBytes("P@W)D3#Q");
        private static readonly byte[] Vetordes = Encoding.UTF8.GetBytes("D3$D@YC0");
        private static readonly byte[] Vetorinic = Encoding.UTF8.GetBytes("D@AYC0V@L1N1TV3T0R");
        private static readonly byte[] Vetorrinj = Encoding.UTF8.GetBytes("R1JND@3LD@YC0V@L");

        #region Métodos

        public static string Criptografar(string strDados, EncryptAlgorithm.EncryptionAlgorithm objAlgoritmo)
        {
            var result = string.Empty;

            switch (objAlgoritmo)
            {
                case EncryptAlgorithm.EncryptionAlgorithm.Des:
                    result = Criptografar(strDados, objAlgoritmo, Vetordes, Keydes);
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.Rc2:
                    result = Criptografar(strDados, objAlgoritmo, Vetorinic, Key);
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.Rijndael:
                    result = Criptografar(strDados, objAlgoritmo, Vetorrinj, Key3Desrijn);
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.TripleDes:
                    result = Criptografar(strDados, objAlgoritmo, Vetorinic, Key3Desrijn);
                    break;
            }

            return result;
        }

        public static string Criptografar(string strDados, EncryptAlgorithm.EncryptionAlgorithm objAlgoritmo, string vetorCripto, string keyCripto)
        {
            var bVetorCripto = Encoding.UTF8.GetBytes(vetorCripto.Substring(0, 16));
            var bKeyCripto = Encoding.UTF8.GetBytes(keyCripto.Substring(0, 16));

            return Criptografar(strDados, objAlgoritmo, bVetorCripto, bKeyCripto);
        }

        public static string Criptografar(string strDados, EncryptAlgorithm.EncryptionAlgorithm objAlgoritmo, byte[] vetorCripto, byte[] keyCripto)
        {
            return Convert.ToBase64String(CriptografarByte(Encoding.UTF8.GetBytes(strDados), objAlgoritmo, vetorCripto, keyCripto));
        }

        public static byte[] CriptografarByte(byte[] bytesDados, EncryptAlgorithm.EncryptionAlgorithm objAlgoritmo, byte[] vetorCripto, byte[] keyCripto)
        {
            byte[] bytesKey = null;
            var encryptor = new Encryptor(objAlgoritmo);

            switch (objAlgoritmo)
            {
                case EncryptAlgorithm.EncryptionAlgorithm.Des:
                    bytesKey = keyCripto;
                    encryptor.Iv = vetorCripto;
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.Rc2:
                    bytesKey = keyCripto;
                    encryptor.Iv = vetorCripto;
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.Rijndael:
                    bytesKey = keyCripto;
                    encryptor.Iv = vetorCripto;
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.TripleDes:
                    bytesKey = keyCripto;
                    encryptor.Iv = vetorCripto;
                    break;
            }

            return encryptor.Encrypt(bytesDados, bytesKey);
        }

        public static string Descriptografar(string strDados, EncryptAlgorithm.EncryptionAlgorithm objAlgoritmo)
        {
            var result = string.Empty;

            switch (objAlgoritmo)
            {
                case EncryptAlgorithm.EncryptionAlgorithm.Des:
                    result = Descriptografar(strDados, objAlgoritmo, Vetordes, Keydes);
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.Rc2:
                    result = Descriptografar(strDados, objAlgoritmo, Vetorinic, Key);
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.Rijndael:
                    result = Descriptografar(strDados, objAlgoritmo, Vetorrinj, Key3Desrijn);
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.TripleDes:
                    result = Descriptografar(strDados, objAlgoritmo, Vetorinic, Key3Desrijn);
                    break;
            }

            return result;
        }

        public static string Descriptografar(string strDados, EncryptAlgorithm.EncryptionAlgorithm objAlgoritmo, string vetorCripto, string keyCripto)
        {
            var bVetorCripto = Encoding.UTF8.GetBytes(vetorCripto.Substring(0, 16));
            var bKeyCripto = Encoding.UTF8.GetBytes(keyCripto.Substring(0, 16));

            return Descriptografar(strDados, objAlgoritmo, bVetorCripto, bKeyCripto);
        }

        public static string Descriptografar(string strDados, EncryptAlgorithm.EncryptionAlgorithm objAlgoritmo, byte[] vetorCripto, byte[] keyCripto)
        {
            return Encoding.UTF8.GetString(DescriptografarByte(Convert.FromBase64String(strDados), objAlgoritmo, vetorCripto, keyCripto));
        }

        public static byte[] DescriptografarByte(byte[] bytesDados, EncryptAlgorithm.EncryptionAlgorithm objAlgoritmo, byte[] vetorCripto, byte[] keyCripto)
        {
            byte[] bytesKey = null;

            var decryptor = new Decryptor(objAlgoritmo);

            switch (objAlgoritmo)
            {
                case EncryptAlgorithm.EncryptionAlgorithm.Des:
                    bytesKey = keyCripto;
                    decryptor.IV = vetorCripto;
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.Rc2:
                    bytesKey = keyCripto;
                    decryptor.IV = vetorCripto;
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.Rijndael:
                    bytesKey = keyCripto;
                    decryptor.IV = vetorCripto;
                    break;
                case EncryptAlgorithm.EncryptionAlgorithm.TripleDes:
                    bytesKey = keyCripto;
                    decryptor.IV = vetorCripto;
                    break;
            }

            return decryptor.Decrypt(bytesDados, bytesKey);
        }

        public static string CriptografarMd5(string sHash)
        {
            return new SISMD5().Encrypt(sHash);
        }

        public static bool CompararHashMd5(string sString, string sHash)
        {
            return new SISMD5().Verify(sString, sHash);
        }

        #endregion
    }
}
