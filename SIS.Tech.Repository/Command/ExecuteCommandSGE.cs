using SISFramework.DataAccess.Ado.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Repository.Command
{
    public class ExecuteCommandSGE : IExecute
    {
        public string SistemaSISParameter
        {
            get { return "SINDPETSHOP"; }
        }

        public string ConnectionNameParameter
        {
            get { return "SIS.Controle.Connection"; }
        }

        public string AmbienteServer { get; set; }

        public string Database { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }

        public int? TimeOut { get; set; }

        public CommandType TipoComando { get; set; }

        public string ComandoSql { get; set; }

        public SqlParameter[] Parametros { get; set; }
    }
}
