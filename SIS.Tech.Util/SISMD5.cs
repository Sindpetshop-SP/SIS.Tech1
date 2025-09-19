using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SIS.Tech.Util
{
    public sealed class SISMD5
    {

        private byte[] _encStringBytes;
        private UTF8Encoding Encoder = new UTF8Encoding();

        private MD5CryptoServiceProvider MD5Hasher = new MD5CryptoServiceProvider();
        /// <summary>
        /// Encripta uma string em MD5
        /// </summary>
        /// <param name="encString">String a ser criptografada.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Encrypt(string encString)
        {
            // TODO: Verificar o uso do objeto System.Security.Cryptography.RandomNumberGenerator
            Random ranGen = new Random();
            string ranString = "";
            string md5String = null;
            string ranSaltLoc = null;

            // Gera números randômicos até 4 dígitos.
            while (ranString.Length <= 3)
                ranString = ranString + ranGen.Next(0, 9);

            // Converte a string em uma sequência de bytes.
            _encStringBytes = Encoder.GetBytes(encString + ranString);

            // Gera o array de bytes para MD5
            _encStringBytes = MD5Hasher.ComputeHash(_encStringBytes);

            // Afixando o Salt em um hash MD5
            md5String = BitConverter.ToString(_encStringBytes);
            md5String = md5String.Replace("-", null);

            // Encontra uma localização aleatória na string
            ranSaltLoc = ranGen.Next(4, md5String.Length).ToString();

            // Insere o Salt na mesma
            md5String = md5String.Insert(int.Parse(ranSaltLoc), ranString);

            // Acrescenta 0 para valores inferiores a 10
            if (double.Parse(ranSaltLoc) < 10)
                ranSaltLoc = "0" + ranSaltLoc;

            // Insere a locação do Salt na 3ª posição da string
            md5String = md5String.Insert(3, ranSaltLoc);

            // Retorna o hash em MD5
            return md5String;
        }

        /// <summary>
        /// Verifica e compara uma string com um hash MD5
        /// </summary>
        /// <param name="S">String a ser comparada</param>
        /// <param name="hash">Hash a ser comparado</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool Verify(string S, string hash)
        {
            if (string.IsNullOrEmpty(S) || string.IsNullOrEmpty(hash))
                return false;

            // Procura o endereço do Salt e o remove da string
            var saltAddress = double.Parse(hash.Substring(3, 2));
            hash = hash.Remove(3, 2);

            // Procura o SaltID e o remove da string
            var saltId = hash.Substring(int.Parse(saltAddress.ToString()), 4);
            hash = hash.Remove(int.Parse(saltAddress.ToString()), 4);

            // Converte a string fornecida para uma sequência de bytes
            _encStringBytes = Encoder.GetBytes(S + saltId);

            // Encripta a string fornecida junto do Salt
            _encStringBytes = MD5Hasher.ComputeHash(_encStringBytes);

            // Converte o hash para uma string
            var newHash = BitConverter.ToString(_encStringBytes);
            newHash = newHash.Replace("-", null);

            // Compara o novo hash com o hash fornecido pela função.
            return newHash == hash;
        }
    }
}
