using SISFramework.DataAccess.Ado;
using SIS.Tech.Domain.Model;
using SIS.Tech.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Repository
{
    public class PessoaRepository : BaseRepository, IPessoaRepository
    {

        public List<Pessoa> ListarPessoa()
        {
            var lstPessoa = new List<Pessoa>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_PESSOA_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Pessoa();
                    _item.PessoaCategoria = new PessoaCategoria();
                    _item.TipoPessoa = new TipoPessoa();

                    _item.CodPessoa = (dReader["CodPessoa"] as int?).GetValueOrDefault();

                    _item.PessoaCategoria.CodPessoaCategoria = (dReader["CodPessoaCategoria"] as int?).GetValueOrDefault();
                    _item.PessoaCategoria.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescPessoaCategoria");

                    _item.TipoPessoa.CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault();
                    _item.TipoPessoa.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoPessoa");

                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "Cpf");
                    _item.Nome = Util.TrataCampos.GetStringSafe(dReader, "Nome");

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");

                    _item.Email = Util.TrataCampos.GetStringSafe(dReader, "Email");


                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");

                    lstPessoa.Add(_item);
                }
            }

            return lstPessoa;
        }



        public List<Pessoa> ListarPessoaFiltro(string codPessoa, string nome)
        {
            var lstPessoa = new List<Pessoa>();
            int cdPessoa = 0;

            if (!string.IsNullOrEmpty(codPessoa))
            {
                cdPessoa = Convert.ToInt32(codPessoa);
            }

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoa", SqlDbType.Int) {Value =  cdPessoa},
                new SqlParameter("@Nome", SqlDbType.VarChar, 150) {Value =  nome},
            };

            var command = MontaCommand(parametros, "dbo.P_PESSOA_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Pessoa();
                    _item.PessoaCategoria = new PessoaCategoria();
                    _item.TipoPessoa = new TipoPessoa();

                    _item.CodPessoa = (dReader["CodPessoa"] as int?).GetValueOrDefault();

                    _item.PessoaCategoria.CodPessoaCategoria = (dReader["CodPessoaCategoria"] as int?).GetValueOrDefault();
                    _item.PessoaCategoria.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescPessoaCategoria");

                    _item.TipoPessoa.CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault();
                    _item.TipoPessoa.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoPessoa");

                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "Cpf");
                    _item.Nome = Util.TrataCampos.GetStringSafe(dReader, "Nome");

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");

                    _item.Email = Util.TrataCampos.GetStringSafe(dReader, "Email");

                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");

                    lstPessoa.Add(_item);
                }
            }

            return lstPessoa;
        }


        public Pessoa ObterPessoa(int codPessoa)
        {
            var Pessoas = new Pessoa();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoa", SqlDbType.Int) {Value = codPessoa},
            };

            var command = MontaCommand(parametros, "dbo.P_PESSOA_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Pessoa();
                    _item.PessoaCategoria = new PessoaCategoria();                    
                    _item.TipoPessoa = new TipoPessoa();

                    _item.CodPessoa = (dReader["CodPessoa"] as int?).GetValueOrDefault();

                    _item.PessoaCategoria.CodPessoaCategoria = (dReader["CodPessoaCategoria"] as int?).GetValueOrDefault();
                    _item.PessoaCategoria.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescPessoaCategoria");

                    _item.TipoPessoa.CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault();
                    _item.TipoPessoa.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoPessoa");

                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "Cpf");
                    _item.Nome = Util.TrataCampos.GetStringSafe(dReader, "Nome");

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");

                    _item.Email = Util.TrataCampos.GetStringSafe(dReader, "Email");

                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");

                    Pessoas = _item;
                }
            }

            return Pessoas;
        }


        /// <summary>
        /// Incluir nova pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public int IncluirPessoa(Pessoa pessoa)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoaCategoria", SqlDbType.Int) {Value = pessoa.PessoaCategoria.CodPessoaCategoria},
                new SqlParameter("@CodTipoPessoa", SqlDbType.Int) {Value = pessoa.TipoPessoa.CodTipoPessoa},
                new SqlParameter("@Cpf", SqlDbType.VarChar, 18) {Value = pessoa.Cpf},
                new SqlParameter("@Nome", SqlDbType.VarChar, 150) {Value = pessoa.Nome},
                new SqlParameter("@Observacao", SqlDbType.VarChar, 255) {Value = pessoa.Observacao},
                new SqlParameter("@Email", SqlDbType.VarChar, 100) {Value = pessoa.Email},
                new SqlParameter("@Ativo", SqlDbType.Bit) {Value = pessoa.Ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = pessoa.Quem}
            };

            var command = MontaCommand(parametros, "dbo.P_PESSOA_INCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }



        /// <summary>
        /// Alterar Tipo de Contato
        /// </summary>
        /// <param name="venda"></param>
        public void AlterarPessoa(Pessoa pessoa)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoa", SqlDbType.Int) {Value = pessoa.CodPessoa},
                new SqlParameter("@CodPessoaCategoria", SqlDbType.Int) {Value = pessoa.PessoaCategoria.CodPessoaCategoria},
                new SqlParameter("@CodTipoPessoa", SqlDbType.Int) {Value = pessoa.TipoPessoa.CodTipoPessoa},
                new SqlParameter("@Cpf", SqlDbType.VarChar, 18) {Value = pessoa.Cpf},
                new SqlParameter("@Nome", SqlDbType.VarChar, 150) {Value = pessoa.Nome},
                new SqlParameter("@Observacao", SqlDbType.VarChar, 255) {Value = pessoa.Observacao},
                new SqlParameter("@Email", SqlDbType.VarChar, 100) {Value = pessoa.Email},
                new SqlParameter("@Ativo", SqlDbType.Bit) {Value = pessoa.Ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = pessoa.Quem}
            };

            var command = MontaCommand(parametros, "dbo.P_PESSOA_ALTERAR", 600);

            DbHelper.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Alterar Tipo de Contato
        /// </summary>
        /// <param name="venda"></param>
        public int ExcluirPessoa(int idPessoa, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoa", SqlDbType.Int) {Value = idPessoa},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_PESSOA_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }




        public List<PessoaCategoria> ListarPessoaCategoria()
        {
            var lstPessoaCategoria = new List<PessoaCategoria>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_PESSOACATEGORIA_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var itemPessoaCategoria = new PessoaCategoria
                    {
                        CodPessoaCategoria = (dReader["CodPessoaCategoria"] as int?).GetValueOrDefault(),
                        Descricao = Util.TrataCampos.GetStringSafe(dReader, "Descricao")
                    };

                    lstPessoaCategoria.Add(itemPessoaCategoria);
                }
            }

            return lstPessoaCategoria;
        }


    }
}
