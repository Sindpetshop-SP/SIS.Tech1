using SISFramework.DataAccess.Ado;
using SIS.Tech.Domain.Model;
using SIS.Tech.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Repository
{
    public class ContaTipoRepository : BaseRepository, IContaTipoRepository
    {
        public List<ContaTipo> ListarContaTipo()
        {
            var lstContaTipo = new List<ContaTipo>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_CONTA_TIPO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemContaTipo = new ContaTipo
                    {
                        CodContaTipo = (dReader["CodContaTipo"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstContaTipo.Add(itemContaTipo);
                }
            }

            return lstContaTipo;
        }

        public List<ContaTipo> ListarContaTipoFiltro(string codContaTipo, string descricao)
        {
            var lstContaTipo = new List<ContaTipo>();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodContaTipo", SqlDbType.Int) {Value = codContaTipo},
                new SqlParameter("@Descricao", SqlDbType.VarChar, 80) {Value = descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_CONTA_TIPO_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemContaTipo = new ContaTipo
                    {
                        CodContaTipo = (dReader["CodContaTipo"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstContaTipo.Add(itemContaTipo);
                }
            }

            return lstContaTipo;
        }


        public ContaTipo ObterContaTipo(int codContaTipo)
        {
            var _item = new ContaTipo();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodContaTipo", SqlDbType.Int) {Value = codContaTipo},
            };

            var command = MontaCommand(parametros, "dbo.P_CONTA_TIPO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = new ContaTipo();

                    _item.CodContaTipo = (dReader["CodContaTipo"] as int?).GetValueOrDefault();
                    _item.Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao");
                }
            }

            return _item;
        }

        public int AlterarContaTipo(ContaTipo ContaTipo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodContaTipo", SqlDbType.Int){Value = ContaTipo.CodContaTipo},
                 new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = ContaTipo.Descricao},
                 new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = ContaTipo.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_CONTA_TIPO_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int ExcluirContaTipo(int codContaTipo, string quem)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodContaTipo", SqlDbType.Int){Value = codContaTipo},
               new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_CONTA_TIPO_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int InserirContaTipo(ContaTipo ContaTipo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = ContaTipo.Descricao},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = ContaTipo.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_CONTA_TIPO_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }


    }
}
