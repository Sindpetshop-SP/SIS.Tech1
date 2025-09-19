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
    public class PessoaCategoriaRepository : BaseRepository, IPessoaCategoriaRepository
    {
        public List<PessoaCategoria> ListarPessoaCategoria()
        {
            var lstPessoaCategoria = new List<PessoaCategoria>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_PESSOA_CATEGORIA_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemPessoaCategoria = new PessoaCategoria
                    {
                        CodPessoaCategoria = (dReader["CodPessoaCategoria"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao"),
                        Sigla = Util.TrataCampos.GetStringSafe(dReader, "Sigla")
                    };

                    lstPessoaCategoria.Add(itemPessoaCategoria);
                }
            }

            return lstPessoaCategoria;
        }

        public List<PessoaCategoria> ListarPessoaCategoriaFiltro(string codPessoaCategoria, string descricao)
        {
            var lstPessoaCategoria = new List<PessoaCategoria>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoaCategoria", SqlDbType.Int) {Value =  codPessoaCategoria},
                new SqlParameter("@Descricao", SqlDbType.VarChar) {Value =  descricao},
            };

            var command = MontaCommand(parametros, "dbo.P_PESSOA_CATEGORIA_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemPessoaCategoria = new PessoaCategoria
                    {
                        CodPessoaCategoria = (dReader["CodPessoaCategoria"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao"),
                        Sigla = Util.TrataCampos.GetStringSafe(dReader, "Sigla")
                    };

                    lstPessoaCategoria.Add(itemPessoaCategoria);
                }
            }

            return lstPessoaCategoria;
        }

        public PessoaCategoria ObterPessoaCategoria(int codPessoaCategoria)
        {
            var _item = new PessoaCategoria();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodPessoaCategoria", SqlDbType.Int) {Value = codPessoaCategoria},
            };

            var command = MontaCommand(parametros, "dbo.P_PESSOA_CATEGORIA_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = new PessoaCategoria();

                    _item.CodPessoaCategoria = (dReader["CodPessoaCategoria"] as int?).GetValueOrDefault();
                    _item.Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao");
                    _item.Sigla = Util.TrataCampos.GetStringSafe(dReader, "Sigla");

                }
            }

            return _item;
        }

        public void AlterarPessoaCategoria(PessoaCategoria PessoaCategoria)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoaCategoria", SqlDbType.Int){Value = PessoaCategoria.CodPessoaCategoria},
                new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = PessoaCategoria.Descricao},
                new SqlParameter("@Sigla", SqlDbType.VarChar, 3){Value = PessoaCategoria.Sigla},
                   new SqlParameter("@Quem", SqlDbType.VarChar, 6){Value = PessoaCategoria.Quem},

        };

            var command = MontaCommand(parametros, "dbo.P_PESSOA_CATEGORIA_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public void ExcluirPessoaCategoria(int codPessoaCategoria, string quem)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodPessoaCategoria", SqlDbType.Int){Value = codPessoaCategoria},
               new SqlParameter("@Quem", SqlDbType.VarChar, 6){Value = quem},

            };

            var command = MontaCommand(parametros, "dbo.P_PESSOA_CATEGORIA_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public int InserirPessoaCategoria(PessoaCategoria PessoaCategoria)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Descricao", SqlDbType.VarChar, 100){Value = PessoaCategoria.Descricao},
                new SqlParameter("@Sigla", SqlDbType.VarChar, 3){Value = PessoaCategoria.Sigla},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6){Value = PessoaCategoria.Quem},

            };

            var command = MontaCommand(parametros, "dbo.P_PESSOA_CATEGORIA_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }
    }
}
