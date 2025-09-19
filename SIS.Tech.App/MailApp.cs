using SIS.Tech.IApp;
using SIS.Tech.IDomain;
using SIS.Tech.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.App
{
    public class MailApp : IMailApp
    {
        private readonly IMailService _mailService;

        public MailApp(IMailService mailService)
        {
            _mailService = mailService;
        }

        public void receiveMail()
        {
            _mailService.receiveMail();
        }

        public void sendMail(string mailFrom, string mailTo, string subject, string tipo, string codForamtado, string nomeUsuario, string senhaCryptoNew, string nomeLogin)
        {
            _mailService.sendMail(mailFrom, mailTo, subject, tipo, codForamtado, nomeUsuario, senhaCryptoNew, nomeLogin);
        }
    }
}
