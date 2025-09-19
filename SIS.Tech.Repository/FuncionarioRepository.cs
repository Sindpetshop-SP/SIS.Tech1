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
    public class FuncionarioRepository : BaseRepository, IFuncionarioRepository
    {

        public int AlterarFuncionario(Funcionario funcionario)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodFuncionario", SqlDbType.Int) {Value = funcionario.CodFuncionario},
                new SqlParameter("@CodTipoPessoa", SqlDbType.Int) {Value = funcionario.TipoPessoa.CodTipoPessoa},
                new SqlParameter("@Cpf", SqlDbType.VarChar, 14) {Value = funcionario.Cpf},
                new SqlParameter("@Nome", SqlDbType.VarChar, 150) {Value = funcionario.Nome},
                new SqlParameter("@Idade", SqlDbType.Int) {Value = funcionario.Idade},
                new SqlParameter("@Sexo", SqlDbType.Int) {Value = funcionario.Sexo},                
                new SqlParameter("@DataCadastro", SqlDbType.DateTime) {Value = funcionario.DataCadastro},
                new SqlParameter("@Observacao", SqlDbType.VarChar) {Value = funcionario.Observacao},
                new SqlParameter("@Sindicalizado", SqlDbType.Bit) {Value = funcionario.Sindicalizado},
                new SqlParameter("@Ativo", SqlDbType.Bit) {Value = funcionario.Ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = funcionario.Quem}
            };

            var command = MontaCommand(parametros, "dbo.P_FUNCIONARIO_ALTERAR", 600);

            DbHelper.ExecuteNonQuery(command);

            return 0;
        }

        public int ExcluirFuncionario(int codFuncionario, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodFuncionario", SqlDbType.Int) {Value = codFuncionario},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_FUNCIONARIO_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }

        public int IncluirFuncionario(Funcionario funcionario)
        {
            var parametros = new List<SqlParameter>
            {                
                new SqlParameter("@CodTipoPessoa", SqlDbType.Int) {Value = funcionario.TipoPessoa.CodTipoPessoa},
                new SqlParameter("@Cpf", SqlDbType.VarChar, 14) {Value = funcionario.Cpf},
                new SqlParameter("@Nome", SqlDbType.VarChar, 150) {Value = funcionario.Nome},
                new SqlParameter("@Idade", SqlDbType.Int) {Value = funcionario.Idade},
                new SqlParameter("@Sexo", SqlDbType.Int) {Value = funcionario.Sexo},
                new SqlParameter("@DataCadastro", SqlDbType.DateTime) {Value = funcionario.DataCadastro},
                new SqlParameter("@Observacao", SqlDbType.VarChar) {Value = funcionario.Observacao},
                new SqlParameter("@Sindicalizado", SqlDbType.Bit) {Value = funcionario.Sindicalizado},
                new SqlParameter("@Ativo", SqlDbType.Bit) {Value = funcionario.Ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = funcionario.Quem}
            };

            var command = MontaCommand(parametros, "dbo.P_FUNCIONARIO_INCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }

        public List<Funcionario> ListarFuncionario()
        {
            var lstFuncionario = new List<Funcionario>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_FUNCIONARIO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Funcionario();
                    _item.CodFuncionario = (dReader["CodFuncionario"] as int?).GetValueOrDefault();


                    _item.Empresa = new Empresa();
                    _item.Empresa.CodEmpresa = (dReader["CodEmpresa"] as int?).GetValueOrDefault();
                    _item.Empresa.Cnpj = Util.TrataCampos.GetStringSafe(dReader, "Cnpj");
                    _item.Empresa.RazaoSocial = Util.TrataCampos.GetStringSafe(dReader, "RazaoSocial");
                    _item.Empresa.NomeFantasia = Util.TrataCampos.GetStringSafe(dReader, "NomeFantasia");

                    _item.TipoPessoa = new TipoPessoa();
                    _item.TipoPessoa.CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault();
                    _item.TipoPessoa.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoPessoa");

                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "Cpf");
                    _item.Nome = Util.TrataCampos.GetStringSafe(dReader, "Nome");
                    _item.Idade = (dReader["Idade"] as int?).GetValueOrDefault();
                    _item.Sexo = (dReader["Sexo"] as int?).GetValueOrDefault();

                    if (dReader["DataCadastro"].ToString() != "")
                    {
                        _item.DataCadastro = Convert.ToDateTime(dReader["DataCadastro"]);
                    }

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");
                    _item.Sindicalizado = (dReader["Sindicalizado"] as bool?).GetValueOrDefault();
                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");

                    lstFuncionario.Add(_item);
                }
            }

            return lstFuncionario;
        }

        public List<Funcionario> ListarFuncionarioFiltro(string cpf, string nome, int codEmpresa)
        {
            var lstFuncionario = new List<Funcionario>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int) {Value =  codEmpresa},
                new SqlParameter("@Cpf", SqlDbType.VarChar,18) {Value =  cpf},
                new SqlParameter("@Nome", SqlDbType.VarChar, 150) {Value =  nome},
            };

            var command = MontaCommand(parametros, "dbo.P_FUNCIONARIO_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Funcionario();
                    _item.CodFuncionario = (dReader["CodFuncionario"] as int?).GetValueOrDefault();


                    _item.Empresa = new Empresa();
                    _item.Empresa.CodEmpresa = (dReader["CodEmpresa"] as int?).GetValueOrDefault();
                    _item.Empresa.Cnpj = Util.TrataCampos.GetStringSafe(dReader, "Cnpj");
                    _item.Empresa.RazaoSocial = Util.TrataCampos.GetStringSafe(dReader, "RazaoSocial");
                    _item.Empresa.NomeFantasia = Util.TrataCampos.GetStringSafe(dReader, "NomeFantasia");

                    _item.TipoPessoa = new TipoPessoa();
                    _item.TipoPessoa.CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault();
                    _item.TipoPessoa.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoPessoa");

                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "Cpf");
                    _item.Nome = Util.TrataCampos.GetStringSafe(dReader, "Nome");
                    _item.Idade = (dReader["Idade"] as int?).GetValueOrDefault();
                    _item.Sexo = (dReader["Sexo"] as int?).GetValueOrDefault();

                    if (dReader["DataCadastro"].ToString() != "")
                    {
                        _item.DataCadastro = Convert.ToDateTime(dReader["DataCadastro"]);
                    }

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");
                    _item.Sindicalizado = (dReader["Sindicalizado"] as bool?).GetValueOrDefault();
                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");

                    lstFuncionario.Add(_item);
                }
            }

            return lstFuncionario;
        }

        public List<Funcionario> ListarFuncionariosEmpresa(int codEmpresa)
        {
            var lstFuncionario = new List<Funcionario>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int) {Value =  codEmpresa}
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_FUNCIONARIO_LISTAR", 600);            

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Funcionario();
                    _item.CodFuncionario = (dReader["CodFuncionario"] as int?).GetValueOrDefault();


                    _item.Empresa = new Empresa();
                    _item.Empresa.CodEmpresa = (dReader["CodEmpresa"] as int?).GetValueOrDefault();
                    _item.Empresa.Cnpj = Util.TrataCampos.GetStringSafe(dReader, "Cnpj");
                    _item.Empresa.RazaoSocial = Util.TrataCampos.GetStringSafe(dReader, "RazaoSocial");
                    _item.Empresa.NomeFantasia = Util.TrataCampos.GetStringSafe(dReader, "NomeFantasia");

                    _item.TipoPessoa = new TipoPessoa();
                    _item.TipoPessoa.CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault();
                    _item.TipoPessoa.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoPessoa");

                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "Cpf");
                    _item.Nome = Util.TrataCampos.GetStringSafe(dReader, "Nome");
                    _item.Idade = (dReader["Idade"] as int?).GetValueOrDefault();
                    _item.Sexo = (dReader["Sexo"] as int?).GetValueOrDefault();

                    if (dReader["DataCadastro"].ToString() != "")
                    {
                        _item.DataCadastro = Convert.ToDateTime(dReader["DataCadastro"]);
                    }

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");
                    _item.Sindicalizado = (dReader["Sindicalizado"] as bool?).GetValueOrDefault();
                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");

                    lstFuncionario.Add(_item);
                }
            }

            return lstFuncionario;
        }

        public Funcionario ObterFuncionario(int codFuncionario)
        {
            var Funcionarios = new Funcionario();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodFuncionario", SqlDbType.Int) {Value = codFuncionario},
            };

            var command = MontaCommand(parametros, "dbo.P_FUNCIONARIO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Funcionario();
                    _item.CodFuncionario = (dReader["CodFuncionario"] as int?).GetValueOrDefault();


                    _item.Empresa = new Empresa();
                    _item.Empresa.CodEmpresa = (dReader["CodEmpresa"] as int?).GetValueOrDefault();
                    _item.Empresa.Cnpj = Util.TrataCampos.GetStringSafe(dReader, "Cnpj");
                    _item.Empresa.RazaoSocial = Util.TrataCampos.GetStringSafe(dReader, "RazaoSocial");
                    _item.Empresa.NomeFantasia = Util.TrataCampos.GetStringSafe(dReader, "NomeFantasia");                    

                    _item.TipoPessoa = new TipoPessoa();
                    _item.TipoPessoa.CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault();
                    _item.TipoPessoa.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoPessoa");

                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "Cpf");
                    _item.Nome = Util.TrataCampos.GetStringSafe(dReader, "Nome");
                    _item.Idade = (dReader["Idade"] as int?).GetValueOrDefault();
                    _item.Sexo = (dReader["Sexo"] as int?).GetValueOrDefault();

                    if (dReader["DataCadastro"].ToString() != "")
                    {
                        _item.DataCadastro = Convert.ToDateTime(dReader["DataCadastro"]);
                    }

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");
                    _item.Sindicalizado = (dReader["Sindicalizado"] as bool?).GetValueOrDefault();
                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");

                    Funcionarios = _item;
                }
            }

            return Funcionarios;
        }

        
    }
}
