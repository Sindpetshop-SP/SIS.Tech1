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
    public class TipoSenhaRepository : BaseRepository, ITipoSenhaRepository
    {
        public List<TipoSenha> ListarTipoSenha()
        {
            var lstTipoSenha = new List<TipoSenha>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_TIPO_SENHA_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemTipoSenha = new TipoSenha
                    {
                        CodTipoSenha = (dReader["CodTipoSenha"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstTipoSenha.Add(itemTipoSenha);
                }
            }

            return lstTipoSenha;
        }

        public List<TipoSenha> ListarTipoSenhaFiltro(string codTipoSenha, string descricao)
        {
            var lstTipoSenha = new List<TipoSenha>();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodTipoSenha", SqlDbType.Int) {Value = codTipoSenha},
                new SqlParameter("@Descricao", SqlDbType.VarChar, 80) {Value = descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_SENHA_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemTipoSenha = new TipoSenha
                    {
                        CodTipoSenha = (dReader["CodTipoSenha"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstTipoSenha.Add(itemTipoSenha);
                }
            }

            return lstTipoSenha;
        }


        public TipoSenha ObterTipoSenha(int codTipoSenha)
        {
            var _item = new TipoSenha();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodTipoSenha", SqlDbType.Int) {Value = codTipoSenha},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_SENHA_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = new TipoSenha();

                    _item.CodTipoSenha = (dReader["CodTipoSenha"] as int?).GetValueOrDefault();
                    _item.Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao");
                }
            }

            return _item;
        }

        public int AlterarTipoSenha(TipoSenha TipoSenha)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodTipoSenha", SqlDbType.Int){Value = TipoSenha.CodTipoSenha},
                 new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = TipoSenha.Descricao},
                 new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = TipoSenha.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_SENHA_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int ExcluirTipoSenha(int codTipoSenha, string quem)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodTipoSenha", SqlDbType.Int){Value = codTipoSenha},
               new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_SENHA_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int InserirTipoSenha(TipoSenha TipoSenha)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = TipoSenha.Descricao},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = TipoSenha.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_SENHA_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }


    }
}
