using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace SIS.Tech.Util
{
    public static class SyslogHelper
    {
        public static string NameEventLog = "AFS.EventLog";

        /// <summary>
        /// Log geral do Sistema
        /// </summary>
        /// <param name="tipoLog"></param>
        /// <param name="aplicativo"></param>
        /// <param name="fonte"></param>
        /// <param name="mensagem"></param>
        /// <param name="usuario"></param>
        public static void LogSistema(EventLogEntryType tipoLog, string aplicativo, string mensagem, string usuario)
        {
            var nome = Dns.GetHostName();
            var ipRetorno = Dns.GetHostAddresses(nome);
            string ip = ipRetorno[0].ToString();

            EventLog.WriteEntry(NameEventLog, mensagem, EventLogEntryType.Error);
        }

        //public static void GravarLogException(Types.Aplicativo aplicativo, string fonte, Exception ex)
        //{
        //    try
        //    {
        //        var modelLog = new LogModel
        //        {
        //            Usuario = SyslogUtil.RetornaUsuarioRodandoAplicacao(),
        //            Computador = SyslogUtil.LocalHostName(),
        //            TipoDescricaoLog = Types.TipoDescricaoLog.Xml,
        //            Aplicativo = aplicativo,
        //            TipoLog = Types.TipoLog.Erro,
        //            Fonte = fonte,
        //            Descricao = ex.Message
        //        };

        //        //TODO: Criar um método para mostrar as mensagens internas da exception.

        //        var idLog = Log.GravaLog(modelLog);

        //        if (string.IsNullOrEmpty(idLog))
        //        {
        //            //TODO Criar uma rotina para gravar um Log em outro lugar caso o Syslog apresente problemas.
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        //TODO Criar uma rotina para gravar um Log em outro lugar caso o Syslog apresente problemas.
        //    }
        //}

        //public static void GravarLog(Types.Aplicativo aplicativo, Types.TipoLog tipoLog, string fonte, string descricao = "")
        //{
        //    try
        //    {
        //        var modelLog = new LogModel
        //        {
        //            Usuario = SyslogUtil.RetornaUsuarioRodandoAplicacao(),
        //            Computador = SyslogUtil.LocalHostName(),
        //            TipoDescricaoLog = Types.TipoDescricaoLog.Xml,
        //            Aplicativo = aplicativo,
        //            TipoLog = tipoLog,
        //            Fonte = fonte,
        //            Descricao = descricao
        //        };

        //        var idLog = Log.GravaLog(modelLog);

        //        if (string.IsNullOrEmpty(idLog))
        //        {
        //            //TODO Criar uma rotina para gravar um Log em outro lugar caso o Syslog apresente problemas.
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        //TODO: Criar uma rotina para gravar um Log em outro lugar caso o Syslog apresente problemas.
        //    }
        //}

        //public static void GravarLog(Types.TipoLog tipo, string mensagem, string sistemaFonte)
        //{
        //    if (string.IsNullOrWhiteSpace(mensagem))
        //        return;

        //    try
        //    {
        //        Log.GravaLog(string.Empty, Dns.GetHostAddresses(Dns.GetHostName())[0].ToString(),
        //            Types.Aplicativo.PortalDaycovalSoa, tipo, Types.TipoDescricaoLog.Texto,
        //            sistemaFonte, "WS", string.Empty, mensagem);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (!EventLog.SourceExists(NameEventLog))
        //            EventLog.CreateEventSource(NameEventLog, "Log");

        //        EventLog.WriteEntry(NameEventLog, mensagem, EventLogEntryType.Error);
        //        EventLog.WriteEntry(NameEventLog, ex.ToString(), EventLogEntryType.Error);
        //    }
        //}
    }
}

