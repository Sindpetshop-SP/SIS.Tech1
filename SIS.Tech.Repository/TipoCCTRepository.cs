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
    public class TipoCCTRepository : BaseRepository, ITipoCCTRepository
    {
        public List<TipoCCT> ListarTipoCCT()
        {
            var lstTipoCCT = new List<TipoCCT>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_TIPO_CCT_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemTipoCCT = new TipoCCT
                    {
                        CodTipoCCT = (dReader["CodTipoCCT"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstTipoCCT.Add(itemTipoCCT);
                }
            }

            return lstTipoCCT;
        }

        public List<TipoCCT> ListarTipoCCTFiltro(string codTipoCCT, string descricao)
        {
            var lstTipoCCT = new List<TipoCCT>();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodTipoCCT", SqlDbType.Int) {Value = codTipoCCT},
                new SqlParameter("@Descricao", SqlDbType.VarChar, 80) {Value = descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_CCT_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemTipoCCT = new TipoCCT
                    {
                        CodTipoCCT = (dReader["CodTipoCCT"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstTipoCCT.Add(itemTipoCCT);
                }
            }

            return lstTipoCCT;
        }


        public TipoCCT ObterTipoCCT(int codTipoCCT)
        {
            var _item = new TipoCCT();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodTipoCCT", SqlDbType.Int) {Value = codTipoCCT},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_CCT_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = new TipoCCT();

                    _item.CodTipoCCT = (dReader["CodTipoCCT"] as int?).GetValueOrDefault();
                    _item.Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao");
                }
            }

            return _item;
        }

        public int AlterarTipoCCT(TipoCCT TipoCCT)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodTipoCCT", SqlDbType.Int){Value = TipoCCT.CodTipoCCT},
                new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = TipoCCT.Descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_CCT_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int ExcluirTipoCCT(int codTipoCCT, string quem)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodTipoCCT", SqlDbType.Int){Value = codTipoCCT},
               new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_CCT_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int InserirTipoCCT(TipoCCT TipoCCT)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = TipoCCT.Descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_CCT_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }


    }
}
