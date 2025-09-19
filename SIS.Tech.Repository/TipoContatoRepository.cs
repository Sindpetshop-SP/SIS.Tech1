using SIS.Tech.Domain.Model;
using SIS.Tech.IRepository;
using SISFramework.DataAccess.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Repository
{
    public class TipoContatoRepository : BaseRepository, ITipoContatoRepository
    {
        public List<TipoContato> ListarTipoContato()
        {
            var lstTipoContato = new List<TipoContato>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_TIPO_CONTATO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemTipoContato = new TipoContato
                    {
                        CodTipoContato = (dReader["CodTipoContato"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstTipoContato.Add(itemTipoContato);
                }
            }

            return lstTipoContato;
        }

        public List<TipoContato> ListarTipoContatoFiltro(string codTipoContato, string descricao)
        {
            var lstTipoContato = new List<TipoContato>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodTipoContato", SqlDbType.Int) {Value =  codTipoContato},
                new SqlParameter("@Descricao", SqlDbType.VarChar) {Value =  descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_CONTATO_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemTipoContato = new TipoContato
                    {
                        CodTipoContato = (dReader["CodTipoContato"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstTipoContato.Add(itemTipoContato);
                }
            }

            return lstTipoContato;
        }

        public TipoContato ObterTipoContato(int codTipoContato)
        {
            var _item = new TipoContato();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodTipoContato", SqlDbType.Int) {Value = codTipoContato},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_CONTATO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = new TipoContato();

                    _item.CodTipoContato = (dReader["CodTipoContato"] as int?).GetValueOrDefault();
                    _item.Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao");
                }
            }

            return _item;
        }

        public void AlterarTipoContato(TipoContato tipoContato)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodTipoContato", SqlDbType.Int){Value = tipoContato.CodTipoContato},
                 new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = tipoContato.Descricao},
                 new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = tipoContato.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_CONTATO_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public void ExcluirTipoContato(int codTipoContato, string quem)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodTipoContato", SqlDbType.Int){Value = codTipoContato},
               new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_CONTATO_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public int InserirTipoContato(TipoContato tipoContato)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = tipoContato.Descricao},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = tipoContato.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_CONTATO_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }

    }
}
