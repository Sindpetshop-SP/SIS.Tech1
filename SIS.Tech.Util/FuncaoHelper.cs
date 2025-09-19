using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIS.Tech.Util
{
    public static class FuncaoHelper
    {

        public static string LimparCnpjcpf(string cnpjCpf)
        {
            if (!String.IsNullOrEmpty(cnpjCpf))
                return cnpjCpf.Trim().Replace(".", "").Replace("/", "").Replace("-", "");
            return null;
        }

        /// <summary>
        /// Remove caracteres não numéricos
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveNaoNumericos(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }


        /// <summary>
        /// Verifica CNPJ
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static Boolean ValidarCpf(String cpf)
        {
            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");


            if (cpf.Length != 11)
                return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString(CultureInfo.InvariantCulture)) * multiplicador1[i];

            int resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString(CultureInfo.InvariantCulture);
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString(CultureInfo.InvariantCulture)) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString(CultureInfo.InvariantCulture);
            return cpf.EndsWith(digito);

        }



        /// <summary>
        /// Verifica CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static Boolean VerificarCnpj(String cnpj)
        {
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                return ValidarCnpj(cnpj);
            }
            return false;
        }

        /// <summary>
        ///  Validar CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>

        private static Boolean ValidarCnpj(String cnpj)
        {



            cnpj = cnpj.Replace("/", "");
            cnpj = cnpj.Replace(".", "");
            cnpj = cnpj.Replace("-", "");

            if (cnpj == "00000000000000")
            {
                return false;
            }

            const string ftmt = "6543298765432";
            var digitos = new Int32[14];
            var soma = new Int32[2];
            soma[0] = 0;
            soma[1] = 0;
            var resultado = new Int32[2];
            resultado[0] = 0;
            resultado[1] = 0;
            var cnpjOk = new Boolean[2];
            cnpjOk[0] =
            false;

            cnpjOk[1] = false;

            try
            {
                Int32 nrDig;
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(cnpj.Substring(nrDig, 1));

                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        cnpjOk[nrDig] = (digitos[12 + nrDig] == 0);

                    else
                        cnpjOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                }

                return (cnpjOk[0] && cnpjOk[1]);
            }

            catch
            {
                return false;
            }
        }

    }
}
