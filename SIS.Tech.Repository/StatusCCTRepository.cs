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
    public class StatusCCTRepository : BaseRepository, IStatusCCTRepository
    {
        public List<StatusCCT> ListarStatusCCT()
        {
            var lstStatusCCT = new List<StatusCCT>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_STATUS_CCT_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemStatusCCT = new StatusCCT
                    {
                        CodStatusCCT = (dReader["CodStatusCCT"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstStatusCCT.Add(itemStatusCCT);
                }
            }

            return lstStatusCCT;
        }

        public List<StatusCCT> ListarStatusCCTFiltro(string codStatusCCT, string descricao)
        {
            var lstStatusCCT = new List<StatusCCT>();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodStatusCCT", SqlDbType.Int) {Value = codStatusCCT},
                new SqlParameter("@Descricao", SqlDbType.VarChar, 80) {Value = descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_STATUS_CCT_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemStatusCCT = new StatusCCT
                    {
                        CodStatusCCT = (dReader["CodStatusCCT"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstStatusCCT.Add(itemStatusCCT);
                }
            }

            return lstStatusCCT;
        }


        public StatusCCT ObterStatusCCT(int codStatusCCT)
        {
            var _item = new StatusCCT();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodStatusCCT", SqlDbType.Int) {Value = codStatusCCT},
            };

            var command = MontaCommand(parametros, "dbo.P_STATUS_CCT_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = new StatusCCT();

                    _item.CodStatusCCT = (dReader["CodStatusCCT"] as int?).GetValueOrDefault();
                    _item.Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao");
                }
            }

            return _item;
        }

        public int AlterarStatusCCT(StatusCCT StatusCCT)
        {
            var parametros = new List<SqlParameter>
            {
                 new SqlParameter("@CodStatusCCT", SqlDbType.Int){Value = StatusCCT.CodStatusCCT},
                 new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = StatusCCT.Descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_STATUS_CCT_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int ExcluirStatusCCT(int codStatusCCT, string quem)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodStatusCCT", SqlDbType.Int){Value = codStatusCCT},
               new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_STATUS_CCT_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int InserirStatusCCT(StatusCCT StatusCCT)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = StatusCCT.Descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_STATUS_CCT_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }


    }
}
