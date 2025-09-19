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
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        public void AlterarEndereco(Endereco endereco)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEndereco", SqlDbType.Int){Value = endereco.CodEndereco},
                new SqlParameter("@CodTipoEndereco", SqlDbType.Int){Value = endereco.TipoEndereco.CodTipoEndereco},
                new SqlParameter("@Cep", SqlDbType.VarChar, 9){Value = endereco.Cep},
                new SqlParameter("@Logradouro", SqlDbType.VarChar, 255){Value = endereco.Logradouro},
                new SqlParameter("@Numero", SqlDbType.VarChar, 5){Value = endereco.Numero},
                new SqlParameter("@Complemento", SqlDbType.VarChar, 100){Value = endereco.Complemento},
                new SqlParameter("@Bairro", SqlDbType.VarChar, 100){Value = endereco.Bairro},
                new SqlParameter("@Cidade", SqlDbType.VarChar, 100){Value = endereco.Cidade},
                new SqlParameter("@Estado", SqlDbType.VarChar, 2){Value = endereco.Estado},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = endereco.Quem },
            };

            var command = MontaCommand(parametros, "dbo.P_ENDERECO_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public void ExcluirEnderecoEmpresa(int codEmpresa, int codEndereco, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int) { Value = codEmpresa },
                new SqlParameter("@CodEndereco", SqlDbType.Int) { Value = codEndereco },
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_ENDERECO_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public void ExcluirEnderecoPessoa(int codPessoa, int codEndereco, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoa", SqlDbType.Int) { Value = codPessoa },
                new SqlParameter("@CodEndereco", SqlDbType.Int) { Value = codEndereco },
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },
            };

            var command = MontaCommand(parametros, "dbo.P_ENDERECO_CLIENTE_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public int InserirEnderecoEmpresa(Empresa empresa)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int){Value = empresa.CodEmpresa},
                new SqlParameter("@CodTipoEndereco", SqlDbType.Int){Value = empresa.Endereco.TipoEndereco.CodTipoEndereco},
                new SqlParameter("@Cep", SqlDbType.VarChar, 9){Value = empresa.Endereco.Cep},
                new SqlParameter("@Logradouro", SqlDbType.VarChar, 150){Value = empresa.Endereco.Logradouro},
                new SqlParameter("@Numero", SqlDbType.VarChar, 5){Value = empresa.Endereco.Numero},
                new SqlParameter("@Complemento", SqlDbType.VarChar, 100){Value = empresa.Endereco.Complemento},
                new SqlParameter("@Bairro", SqlDbType.VarChar, 80){Value = empresa.Endereco.Bairro},
                new SqlParameter("@Cidade", SqlDbType.VarChar, 80){Value = empresa.Endereco.Cidade},
                new SqlParameter("@Estado", SqlDbType.VarChar, 80){Value = empresa.Endereco.Estado},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = empresa.Endereco.Quem },
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_ENDERECO_INCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());

        }

        public int InserirEnderecoPessoa(Pessoa pessoa)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoa", SqlDbType.Int){Value = pessoa.CodPessoa},
                new SqlParameter("@CodTipoEndereco", SqlDbType.Int){Value = pessoa.Endereco.TipoEndereco.CodTipoEndereco},
                new SqlParameter("@Cep", SqlDbType.VarChar, 9){Value = pessoa.Endereco.Cep},
                new SqlParameter("@Logradouro", SqlDbType.VarChar, 150){Value = pessoa.Endereco.Logradouro},
                new SqlParameter("@Numero", SqlDbType.VarChar, 5){Value = pessoa.Endereco.Numero},
                new SqlParameter("@Complemento", SqlDbType.VarChar, 100){Value = pessoa.Endereco.Complemento},
                new SqlParameter("@Bairro", SqlDbType.VarChar, 80){Value = pessoa.Endereco.Bairro},
                new SqlParameter("@Cidade", SqlDbType.VarChar, 80){Value = pessoa.Endereco.Cidade},
                new SqlParameter("@Estado", SqlDbType.VarChar, 80){Value = pessoa.Endereco.Estado},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = pessoa.Endereco.Quem },
            };

            var command = MontaCommand(parametros, "dbo.P_ENDERECO_CLIENTE_INCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());

        }

        public List<Endereco> ListarEnderecosEmpresa(int codEmpresa)
        {
            var lstEnderecos = new List<Endereco>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int) {Value = codEmpresa},
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_ENDERECO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Endereco();
                    _item.TipoEndereco = new TipoEndereco();

                    _item.CodEndereco = (dReader["CodEndereco"] as int?).GetValueOrDefault();
                    _item.CodEmpresa = (dReader["CodEmpresa"] as int?).GetValueOrDefault();
                    _item.TipoEndereco.CodTipoEndereco = (dReader["CodTipoEndereco"] as int?).GetValueOrDefault();
                    _item.TipoEndereco.Descricao = Util.TrataCampos.GetStringSafe(dReader, "descTipoEndereco");
                    _item.Cep = Util.TrataCampos.GetStringSafe(dReader, "Cep");
                    _item.Logradouro = Util.TrataCampos.GetStringSafe(dReader, "Logradouro");
                    _item.Numero = Util.TrataCampos.GetStringSafe(dReader, "Numero");
                    _item.Complemento = Util.TrataCampos.GetStringSafe(dReader, "Complemento");
                    _item.Bairro = Util.TrataCampos.GetStringSafe(dReader, "Bairro");
                    _item.Cidade = Util.TrataCampos.GetStringSafe(dReader, "Cidade");
                    _item.Estado = Util.TrataCampos.GetStringSafe(dReader, "Estado");

                    lstEnderecos.Add(_item);
                }
            }

            return lstEnderecos;
        }

        public List<Endereco> ListarEnderecosPessoa(int codPessoa)
        {
            var lstEnderecos = new List<Endereco>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoa", SqlDbType.Int) {Value = codPessoa},
            };

            var command = MontaCommand(parametros, "dbo.P_ENDERECO_CLIENTE_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Endereco();
                    _item.TipoEndereco = new TipoEndereco();

                    _item.CodEndereco = (dReader["CodEndereco"] as int?).GetValueOrDefault();
                    _item.CodPessoa = (dReader["CodPessoa"] as int?).GetValueOrDefault();
                    _item.TipoEndereco.CodTipoEndereco = (dReader["CodTipoEndereco"] as int?).GetValueOrDefault();
                    _item.TipoEndereco.Descricao = Util.TrataCampos.GetStringSafe(dReader, "descTipoEndereco");
                    _item.Cep = Util.TrataCampos.GetStringSafe(dReader, "Cep");
                    _item.Logradouro = Util.TrataCampos.GetStringSafe(dReader, "Logradouro");
                    _item.Numero = Util.TrataCampos.GetStringSafe(dReader, "Numero");
                    _item.Complemento = Util.TrataCampos.GetStringSafe(dReader, "Complemento");
                    _item.Bairro = Util.TrataCampos.GetStringSafe(dReader, "Bairro");
                    _item.Cidade = Util.TrataCampos.GetStringSafe(dReader, "Cidade");
                    _item.Estado = Util.TrataCampos.GetStringSafe(dReader, "Estado");

                    lstEnderecos.Add(_item);
                }
            }

            return lstEnderecos;
        }

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

        public Endereco ObterEndereco(int codEndereco)
        {
            var _item = new Endereco();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEndereco", SqlDbType.Int) {Value = codEndereco},
            };

            var command = MontaCommand(parametros, "dbo.P_ENDERECO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item.TipoEndereco = new TipoEndereco();

                    _item.CodEndereco = (dReader["CodEndereco"] as int?).GetValueOrDefault();
                    _item.CodEmpresa = (dReader["CodEmpresa"] as int?).GetValueOrDefault();
                    _item.CodPessoa = (dReader["CodPessoa"] as int?).GetValueOrDefault();
                    _item.TipoEndereco.CodTipoEndereco = (dReader["CodTipoEndereco"] as int?).GetValueOrDefault();
                    _item.TipoEndereco.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoEndereco");
                    _item.Cep = Util.TrataCampos.GetStringSafe(dReader, "Cep");
                    _item.Logradouro = Util.TrataCampos.GetStringSafe(dReader, "Logradouro");
                    _item.Numero = Util.TrataCampos.GetStringSafe(dReader, "Numero");
                    _item.Complemento = Util.TrataCampos.GetStringSafe(dReader, "Complemento");
                    _item.Bairro = Util.TrataCampos.GetStringSafe(dReader, "Bairro");
                    _item.Cidade = Util.TrataCampos.GetStringSafe(dReader, "Cidade");
                    _item.Estado = Util.TrataCampos.GetStringSafe(dReader, "Estado");

                }
            }

            return _item;
        }
    }
}
