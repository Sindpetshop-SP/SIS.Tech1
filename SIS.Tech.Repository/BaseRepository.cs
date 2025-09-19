using SIS.Tech.Domain.Model;
using SIS.Tech.Repository.Command;
using SISFramework.Parameter.DerivedParameter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Repository
{
    public class BaseRepository
    {
        private readonly string AmbienteServer = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "AmbienteServer").Valor;

        #region SISTEMA PRINCIPAL

        private readonly string DatabaseTech = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "DatabaseTech").Valor;
        private readonly string UserIdTech = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "UserIdTech").Valor;
        private readonly string PasswordBDTech = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "PasswordBDTech").Valor;

        public ExecuteCommand MontaCommand(List<SqlParameter> parametros, string nomeProcedure, int timeout)
        {
            var execute = new ExecuteCommand();

            execute.AmbienteServer = AmbienteServer;

            execute.Database = DatabaseTech;

            execute.UserId = UserIdTech;

            execute.Password = PasswordBDTech;

            execute.TipoComando = CommandType.StoredProcedure;

            execute.ComandoSql = nomeProcedure;

            execute.Parametros = parametros.ToArray();

            execute.TimeOut = timeout;

            return execute;
        }

        #endregion

        #region CONTROLE DE ACESSO

        private readonly string DatabaseControle = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "DatabaseControle").Valor;
        private readonly string UserIdControle = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "UserIdControle").Valor;
        private readonly string PasswordBDControle = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "PasswordBDControle").Valor;

        public ExecuteCommandSGE MontaCommandSGE(List<SqlParameter> parametros, string nomeProcedure, int timeout)
        {
            var execute = new ExecuteCommandSGE();

            execute.AmbienteServer = AmbienteServer;

            execute.Database = DatabaseControle;

            execute.UserId = UserIdControle;

            execute.Password = PasswordBDControle;

            execute.TipoComando = CommandType.StoredProcedure;

            execute.ComandoSql = nomeProcedure;

            execute.Parametros = parametros.ToArray();

            execute.TimeOut = timeout;

            return execute;
        }



        #endregion

        #region COMUNICACAO

        private readonly string DatabaseCom = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "DatabaseCom").Valor;
        private readonly string UserIdCom = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "UserIdCom").Valor;
        private readonly string PasswordBDCom = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "PasswordBDCom").Valor;

        public ExecuteCommandCOM ExecuteCommandCOM(List<SqlParameter> parametros, string nomeProcedure, int timeout)
        {
            var execute = new ExecuteCommandCOM();

            execute.AmbienteServer = AmbienteServer;

            execute.Database = DatabaseCom;

            execute.UserId = UserIdCom;

            execute.Password = PasswordBDCom;

            execute.TipoComando = CommandType.StoredProcedure;

            execute.ComandoSql = nomeProcedure;

            execute.Parametros = parametros.ToArray();

            execute.TimeOut = timeout;

            return execute;
        }

        #endregion

        #region CHAT

        private readonly string DatabaseChat = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "DatabaseChat").Valor;
        private readonly string UserIdChat = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "UserIdChat").Valor;
        private readonly string PasswordBDChat = new LocalMachine().LerParametro("SINDPETSHOP", "ConfiguracoesBD", "PasswordBDChat").Valor;

        public ExecuteCommandCHAT ExecuteCommandCHAT(List<SqlParameter> parametros, string nomeProcedure, int timeout)
        {
            var execute = new ExecuteCommandCHAT();

            execute.AmbienteServer = AmbienteServer;

            execute.Database = DatabaseChat;

            execute.UserId = UserIdChat;

            execute.Password = PasswordBDChat;

            execute.TipoComando = CommandType.StoredProcedure;

            execute.ComandoSql = nomeProcedure;

            execute.Parametros = parametros.ToArray();

            execute.TimeOut = timeout;

            return execute;
        }


        #endregion

    }
}
