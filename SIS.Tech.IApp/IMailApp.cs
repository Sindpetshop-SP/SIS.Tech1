using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{
    public interface IMailApp
    {
        public void receiveMail();

        public void sendMail(string mailFrom, string mailTo, string subject, string tipo, string codForamtado, string nomeUsuario, string senhaCryptoNew, string nomeLogin);

    }
}
