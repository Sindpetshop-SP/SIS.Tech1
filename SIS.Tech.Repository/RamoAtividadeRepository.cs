using SISFramework.DataAccess.Ado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Tech.Domain.Model;
using SIS.Tech.IRepository;

namespace SIS.Tech.Repository
{
    public class RamoAtividadeRepository : BaseRepository, IRamoAtividadeRepository
    {

        public List<RamoAtividade> ListarRamoAtividade()
        {
            var lstRamoAtividade = new List<RamoAtividade>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_RAMO_ATIVIDADE_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemRamoAtividade = new RamoAtividade
                    {
                        CodRamoAtividade = (dReader["CodRamoAtividade"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstRamoAtividade.Add(itemRamoAtividade);
                }
            }

            return lstRamoAtividade;
        }

        public List<RamoAtividade> ListarRamoAtividadeFiltro(string codRamoAtividade, string descricao)
        {
            var lstRamoAtividade = new List<RamoAtividade>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodRamoAtividade", SqlDbType.Int) {Value =  codRamoAtividade},
                new SqlParameter("@Descricao", SqlDbType.VarChar) {Value =  descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_RAMO_ATIVIDADE_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemRamoAtividade = new RamoAtividade
                    {
                        CodRamoAtividade = (dReader["CodRamoAtividade"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstRamoAtividade.Add(itemRamoAtividade);
                }
            }

            return lstRamoAtividade;
        }

        public RamoAtividade ObterRamoAtividade(int codRamoAtividade)
        {
            var _item = new RamoAtividade();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodRamoAtividade", SqlDbType.Int) {Value = codRamoAtividade},
            };

            var command = MontaCommand(parametros, "dbo.P_RAMO_ATIVIDADE_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = new RamoAtividade();

                    _item.CodRamoAtividade = (dReader["CodRamoAtividade"] as int?).GetValueOrDefault();
                    _item.Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao");
                }
            }

            return _item;
        }

        public void AlterarRamoAtividade(RamoAtividade RamoAtividade)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodRamoAtividade", SqlDbType.Int){Value = RamoAtividade.CodRamoAtividade},
                 new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = RamoAtividade.Descricao},
                 new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = RamoAtividade.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_RAMO_ATIVIDADE_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public void ExcluirRamoAtividade(int codRamoAtividade, string quem)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodRamoAtividade", SqlDbType.Int){Value = codRamoAtividade},
               new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_RAMO_ATIVIDADE_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public int InserirRamoAtividade(RamoAtividade RamoAtividade)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = RamoAtividade.Descricao},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = RamoAtividade.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_RAMO_ATIVIDADE_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }
    }
}
