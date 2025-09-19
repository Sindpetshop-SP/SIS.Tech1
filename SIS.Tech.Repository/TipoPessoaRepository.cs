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
    public class TipoPessoaRepository : BaseRepository, ITipoPessoaRepository
    {
        public List<TipoPessoa> ListarTipoPessoa()
        {
            var lstTipoPessoa = new List<TipoPessoa>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_TIPO_PESSOA_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemTipoPessoa = new TipoPessoa
                    {
                        CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstTipoPessoa.Add(itemTipoPessoa);
                }
            }

            return lstTipoPessoa;
        }

        public List<TipoPessoa> ListarTipoPessoaFiltro(string codTipoPessoa, string descricao)
        {
            var lstTipoPessoa = new List<TipoPessoa>();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodTipoPessoa", SqlDbType.Int) {Value = codTipoPessoa},
                new SqlParameter("@Descricao", SqlDbType.VarChar, 80) {Value = descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_PESSOA_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemTipoPessoa = new TipoPessoa
                    {
                        CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstTipoPessoa.Add(itemTipoPessoa);
                }
            }

            return lstTipoPessoa;
        }


        public TipoPessoa ObterTipoPessoa(int codTipoPessoa)
        {
            var _item = new TipoPessoa();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodTipoPessoa", SqlDbType.Int) {Value = codTipoPessoa},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_PESSOA_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = new TipoPessoa();

                    _item.CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault();
                    _item.Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao");
                }
            }

            return _item;
        }

        public int AlterarTipoPessoa(TipoPessoa tipoPessoa)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodTipoPessoa", SqlDbType.Int){Value = tipoPessoa.CodTipoPessoa},
                 new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = tipoPessoa.Descricao},
                 new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = tipoPessoa.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_PESSOA_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int ExcluirTipoPessoa(int codTipoPessoa, string quem)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodTipoPessoa", SqlDbType.Int){Value = codTipoPessoa},
               new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_PESSOA_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int InserirTipoPessoa(TipoPessoa tipoPessoa)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = tipoPessoa.Descricao},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = tipoPessoa.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_PESSOA_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }


    }
}
