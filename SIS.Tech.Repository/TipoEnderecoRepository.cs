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
    public class TipoEnderecoRepository : BaseRepository, ITipoEnderecoRepository
    {
        public List<TipoEndereco> ListarTipoEndereco()
        {
            var lstTipoEndereco = new List<TipoEndereco>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_TIPO_ENDERECO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemTipoEndereco = new TipoEndereco
                    {
                        CodTipoEndereco = (dReader["CodTipoEndereco"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstTipoEndereco.Add(itemTipoEndereco);
                }
            }

            return lstTipoEndereco;
        }

        public List<TipoEndereco> ListarTipoEnderecoFiltro(string codTipoEndereco, string descricao)
        {
            var lstTipoEndereco = new List<TipoEndereco>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodTipoEndereco", SqlDbType.Int) {Value =  codTipoEndereco},
                new SqlParameter("@Descricao", SqlDbType.VarChar) {Value =  descricao},
            };


            var command = MontaCommand(parametros, "dbo.P_TIPO_ENDERECO_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemTipoEndereco = new TipoEndereco
                    {
                        CodTipoEndereco = (dReader["CodTipoEndereco"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstTipoEndereco.Add(itemTipoEndereco);
                }
            }

            return lstTipoEndereco;
        }

        public TipoEndereco ObterTipoEndereco(int codTipoEndereco)
        {
            var _item = new TipoEndereco();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodTipoEndereco", SqlDbType.Int) {Value = codTipoEndereco},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_ENDERECO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = new TipoEndereco();

                    _item.CodTipoEndereco = (dReader["CodTipoEndereco"] as int?).GetValueOrDefault();
                    _item.Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao");
                }
            }

            return _item;
        }

        public void AlterarTipoEndereco(TipoEndereco tipoEndereco)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodTipoEndereco", SqlDbType.Int){Value = tipoEndereco.CodTipoEndereco},
                 new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = tipoEndereco.Descricao},
                 new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = tipoEndereco.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_ENDERECO_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public void ExcluirTipoEndereco(int codTipoEndereco, string quem)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodTipoEndereco", SqlDbType.Int){Value = codTipoEndereco},
               new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_ENDERECO_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public int InserirTipoEndereco(TipoEndereco tipoEndereco)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = tipoEndereco.Descricao},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = tipoEndereco.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_TIPO_ENDERECO_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }
    }
}
