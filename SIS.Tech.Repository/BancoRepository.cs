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
    public class BancoRepository : BaseRepository, IBancoRepository
    {
        public List<Banco> ListarBanco()
        {
            var lstBanco = new List<Banco>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_BANCO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemBanco = new Banco
                    {
                        CodBanco = (dReader["CodBanco"] as int?).GetValueOrDefault(),
                        NumeroBanco = Util.TrataCampos.GetStringSafe(dReader, "NumeroBanco"),
                        NomeBanco = Util.TrataCampos.GetStringSafe(dReader, "NomeBanco"),
                    };

                    lstBanco.Add(itemBanco);
                }
            }

            return lstBanco;
        }

        public List<Banco> ListarBancoFiltro(string codBanco, string nomeBanco)
        {
            var lstBanco = new List<Banco>();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodBanco", SqlDbType.Int) {Value = codBanco},
                new SqlParameter("@NomeBanco", SqlDbType.VarChar, 80) {Value = nomeBanco},
            };

            var command = MontaCommand(parametros, "dbo.P_BANCO_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemBanco = new Banco
                    {
                        CodBanco = (dReader["CodBanco"] as int?).GetValueOrDefault(),
                        NumeroBanco = Util.TrataCampos.GetStringSafe(dReader, "NumeroBanco"),
                        NomeBanco = Util.TrataCampos.GetStringSafe(dReader, "NomeBanco"),
                    };

                    lstBanco.Add(itemBanco);
                }
            }

            return lstBanco;
        }


        public Banco ObterBanco(int codBanco)
        {
            var _item = new Banco();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodBanco", SqlDbType.Int) {Value = codBanco},
            };

            var command = MontaCommand(parametros, "dbo.P_BANCO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = new Banco();

                    _item.CodBanco = (dReader["CodBanco"] as int?).GetValueOrDefault();
                    _item.NumeroBanco = Util.TrataCampos.GetStringSafe(dReader, "NumeroBanco");
                    _item.NomeBanco = Util.TrataCampos.GetStringSafe(dReader, "NomeBanco");
                }
            }

            return _item;
        }

        public int AlterarBanco(Banco banco)
        {
            var parametros = new List<SqlParameter>
            {
                 new SqlParameter("@CodBanco", SqlDbType.Int){Value = banco.CodBanco},
                 new SqlParameter("@NumeroBanco", SqlDbType.VarChar, 100){Value = banco.NumeroBanco},
                 new SqlParameter("@NomeBanco", SqlDbType.VarChar, 100){Value = banco.NomeBanco},
                 new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = banco.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_BANCO_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int ExcluirBanco(int codBanco, string quem)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodBanco", SqlDbType.Int){Value = codBanco},
               new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_BANCO_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int InserirBanco(Banco banco)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodBanco", SqlDbType.Int){Value = banco.CodBanco},
                 new SqlParameter("@NumeroBanco", SqlDbType.VarChar, 100){Value = banco.NumeroBanco},
                 new SqlParameter("@NomeBanco", SqlDbType.VarChar, 100){Value = banco.NomeBanco},
                 new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = banco.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_BANCO_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }


    }
}
