using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Util
{
    public static class MascaraHelper
    {
        /// <summary>
        ///Formatar de Long para CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static string MascaraCnpj(long cnpj)
        {
            return String.Format(@"{0:00\.000\.000\/0000\-00}", cnpj);
        }

        ///  <summary>
        /// Formatar de Long para CPF
        ///  </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static string MascaraCpf(long cpf)
        {
            return String.Format(@"{0:000\.000\.000-00}", cpf);
        }
    }
}
