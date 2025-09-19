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
    public class EmpresaRepository : BaseRepository, IEmpresaRepository
    {

        public int AlterarEmpresa(Empresa empresa)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int) {Value = empresa.CodEmpresa},
                new SqlParameter("@CodTipoPessoa", SqlDbType.Int) {Value = empresa.TipoPessoa.CodTipoPessoa},
                new SqlParameter("@CodRamoAtividade", SqlDbType.Int) {Value = empresa.RamoAtividade.CodRamoAtividade},
                new SqlParameter("@Cnpj", SqlDbType.VarChar, 18) {Value = empresa.Cnpj},
                new SqlParameter("@RazaoSocial", SqlDbType.VarChar, 150) {Value = empresa.RazaoSocial},
                new SqlParameter("@NomeFantasia", SqlDbType.VarChar, 150) {Value = empresa.NomeFantasia},
                new SqlParameter("@DataCadastro", SqlDbType.DateTime) {Value = empresa.DataCadastro},
                new SqlParameter("@InscricaoEstadual", SqlDbType.VarChar, 15) {Value = empresa.InscricaoEstadual},
                new SqlParameter("@InscricaoMunicipal", SqlDbType.VarChar, 14) {Value = empresa.InscricaoMunicipal},
                new SqlParameter("@Observacao", SqlDbType.VarChar, 255) {Value = empresa.Observacao},
                new SqlParameter("@Ativo", SqlDbType.Bit) {Value = empresa.Ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = empresa.Quem}
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_ALTERAR", 600);

            DbHelper.ExecuteNonQuery(command);

            return 0;
        }

        public int ExcluirEmpresa(int codEmpresa, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int) {Value = codEmpresa},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }

        public int IncluirEmpresa(Empresa empresa)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodTipoPessoa", SqlDbType.Int) {Value = empresa.TipoPessoa.CodTipoPessoa},
                new SqlParameter("@CodRamoAtividade", SqlDbType.Int) {Value = empresa.RamoAtividade.CodRamoAtividade},
                new SqlParameter("@Cnpj", SqlDbType.VarChar, 18) {Value = empresa.Cnpj},
                new SqlParameter("@RazaoSocial", SqlDbType.VarChar, 150) {Value = empresa.RazaoSocial},
                new SqlParameter("@NomeFantasia", SqlDbType.VarChar, 150) {Value = empresa.NomeFantasia},
                new SqlParameter("@DataCadastro", SqlDbType.DateTime) {Value = empresa.DataCadastro},
                new SqlParameter("@InscricaoEstadual", SqlDbType.VarChar, 15) {Value = empresa.InscricaoEstadual},
                new SqlParameter("@InscricaoMunicipal", SqlDbType.VarChar, 14) {Value = empresa.InscricaoMunicipal},
                new SqlParameter("@Observacao", SqlDbType.VarChar, 255) {Value = empresa.Observacao},
                new SqlParameter("@Ativo", SqlDbType.Bit) {Value = empresa.Ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = empresa.Quem}
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_INCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }

        public List<Empresa> ListarEmpresa()
        {
            var lstEmpresa = new List<Empresa>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Empresa();
                    _item.TipoPessoa = new TipoPessoa();
                    _item.RamoAtividade = new RamoAtividade();

                    _item.CodEmpresa = (dReader["CodEmpresa"] as int?).GetValueOrDefault();

                    _item.TipoPessoa.CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault();
                    _item.TipoPessoa.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoPessoa");

                    _item.RamoAtividade.CodRamoAtividade = (dReader["CodRamoAtividade"] as int?).GetValueOrDefault();
                    _item.RamoAtividade.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescRamoAtividade");

                    _item.Cnpj = Util.TrataCampos.GetStringSafe(dReader, "Cnpj");
                    _item.RazaoSocial = Util.TrataCampos.GetStringSafe(dReader, "RazaoSocial");
                    _item.NomeFantasia = Util.TrataCampos.GetStringSafe(dReader, "NomeFantasia");

                    if (dReader["DataCadastro"].ToString() != "")
                    {
                        _item.DataCadastro = Convert.ToDateTime(dReader["DataCadastro"]);
                    }

                    if (dReader["DataAbertura"].ToString() != "")
                    {
                        _item.DataAbertura = Convert.ToDateTime(dReader["DataAbertura"]);
                    }

                    _item.InscricaoEstadual = Util.TrataCampos.GetStringSafe(dReader, "InscricaoEstadual");
                    _item.InscricaoMunicipal = Util.TrataCampos.GetStringSafe(dReader, "InscricaoMunicipal");
                    _item.Sindicalizada = (dReader["Sindicalizada"] as bool?).GetValueOrDefault();
                    _item.EhMatrizFilial = (dReader["EhMatrizFilial"] as bool?).GetValueOrDefault();
                    _item.QuantidadeFUncionarios = (dReader["QuantidadeFUncionarios"] as int?).GetValueOrDefault();
                    _item.ValorTotalFolha = Convert.ToDecimal(dReader["ValorTotalFolha"]);
                    _item.CapitalSocial = Convert.ToDecimal(dReader["CapitalSocial"]);

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");
                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");

                    lstEmpresa.Add(_item);
                }
            }

            return lstEmpresa;
        }

        public List<Empresa> ListarEmpresaFiltro(string cnpj, string nome, string nomeFantasia)
        {
            var lstEmpresa = new List<Empresa>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Cnpj", SqlDbType.VarChar,18) {Value =  cnpj},
                new SqlParameter("@RazaoSocial", SqlDbType.VarChar, 150) {Value =  nome},
                new SqlParameter("@NomeFantasia", SqlDbType.VarChar, 150) {Value = nomeFantasia},
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Empresa();
                    _item.TipoPessoa = new TipoPessoa();
                    _item.RamoAtividade = new RamoAtividade();

                    _item.CodEmpresa = (dReader["CodEmpresa"] as int?).GetValueOrDefault();

                    _item.TipoPessoa.CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault();
                    _item.TipoPessoa.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoPessoa");

                    _item.RamoAtividade.CodRamoAtividade = (dReader["CodRamoAtividade"] as int?).GetValueOrDefault();
                    _item.RamoAtividade.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescRamoAtividade");

                    _item.Cnpj = Util.TrataCampos.GetStringSafe(dReader, "Cnpj");
                    _item.RazaoSocial = Util.TrataCampos.GetStringSafe(dReader, "RazaoSocial");
                    _item.NomeFantasia = Util.TrataCampos.GetStringSafe(dReader, "NomeFantasia");

                    if (dReader["DataCadastro"].ToString() != "")
                    {
                        _item.DataCadastro = Convert.ToDateTime(dReader["DataCadastro"]);
                    }

                    if (dReader["DataAbertura"].ToString() != "")
                    {
                        _item.DataAbertura = Convert.ToDateTime(dReader["DataAbertura"]);
                    }

                    _item.InscricaoEstadual = Util.TrataCampos.GetStringSafe(dReader, "InscricaoEstadual");
                    _item.InscricaoMunicipal = Util.TrataCampos.GetStringSafe(dReader, "InscricaoMunicipal");
                    _item.Sindicalizada = (dReader["Sindicalizada"] as bool?).GetValueOrDefault();
                    _item.EhMatrizFilial = (dReader["EhMatrizFilial"] as bool?).GetValueOrDefault();
                    _item.QuantidadeFUncionarios = (dReader["QuantidadeFUncionarios"] as int?).GetValueOrDefault();
                    _item.ValorTotalFolha = Convert.ToDecimal(dReader["ValorTotalFolha"]);
                    _item.CapitalSocial = Convert.ToDecimal(dReader["CapitalSocial"]);

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");
                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");

                    lstEmpresa.Add(_item);
                }
            }

            return lstEmpresa;
        }

        public List<Empresa> ListarEmpresaFiltro(string codEmpresa, string descricao)
        {
            throw new NotImplementedException();
        }

        public Empresa ObterEmpresa(int codEmpresa)
        {
            var empresas = new Empresa();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int) {Value = codEmpresa},
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Empresa();
                    _item.TipoPessoa = new TipoPessoa();
                    _item.RamoAtividade = new RamoAtividade();

                    _item.CodEmpresa = (dReader["CodEmpresa"] as int?).GetValueOrDefault();

                    _item.TipoPessoa.CodTipoPessoa = (dReader["CodTipoPessoa"] as int?).GetValueOrDefault();
                    _item.TipoPessoa.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoPessoa");

                    _item.RamoAtividade.CodRamoAtividade = (dReader["CodRamoAtividade"] as int?).GetValueOrDefault();
                    _item.RamoAtividade.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescRamoAtividade");

                    _item.Cnpj = Util.TrataCampos.GetStringSafe(dReader, "Cnpj");
                    _item.RazaoSocial = Util.TrataCampos.GetStringSafe(dReader, "RazaoSocial");
                    _item.NomeFantasia = Util.TrataCampos.GetStringSafe(dReader, "NomeFantasia");

                    if (dReader["DataCadastro"].ToString() != "")
                    {
                        _item.DataCadastro = Convert.ToDateTime(dReader["DataCadastro"]);
                    }

                    if (dReader["DataAbertura"].ToString() != "")
                    {
                        _item.DataAbertura = Convert.ToDateTime(dReader["DataAbertura"]);
                    }

                    _item.InscricaoEstadual = Util.TrataCampos.GetStringSafe(dReader, "InscricaoEstadual");
                    _item.InscricaoMunicipal = Util.TrataCampos.GetStringSafe(dReader, "InscricaoMunicipal");
                    _item.Sindicalizada = (dReader["Sindicalizada"] as bool?).GetValueOrDefault();
                    _item.EhMatrizFilial = (dReader["EhMatrizFilial"] as bool?).GetValueOrDefault();
                    _item.QuantidadeFUncionarios = (dReader["QuantidadeFUncionarios"] as int?).GetValueOrDefault();
                    _item.ValorTotalFolha = Convert.ToDecimal(dReader["ValorTotalFolha"]);
                    _item.CapitalSocial = Convert.ToDecimal(dReader["CapitalSocial"]);

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");
                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");


                    //FUNCIONARIOS
                    FuncionarioRepository repository = new FuncionarioRepository();
                    _item.Funcionario = new Funcionario();
                    _item.Funcionario.lstFuncionarios = repository.ListarFuncionariosEmpresa(codEmpresa);

                    //SOCIOS
                    SocioRepository socioRepository = new SocioRepository();
                    _item.Socio = new Socios();
                    _item.Socio.lstSocios = socioRepository.ListarSociosEmpresa(codEmpresa);

                    //CONTATOS
                    ContatoRepository contatoRepository = new ContatoRepository();
                    _item.Contato = new Contato();
                    _item.Contato.lstContatos = contatoRepository.ListarContatosEmpresa(codEmpresa);

                    //ENDERECOS
                    EnderecoRepository enderecoRepository = new EnderecoRepository();
                    _item.Endereco = new Endereco();
                    _item.Endereco.lstEnderecos = enderecoRepository.ListarEnderecosEmpresa(codEmpresa);


                    empresas = _item;
                }
            }

            return empresas;
        }

         

    }
}
