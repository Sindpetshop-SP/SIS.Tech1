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
    public class ContatoRepository : BaseRepository, IContatoRepository
    {
        public void AlterarContato(Contato contato)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodContato", SqlDbType.Int){Value = contato.CodContato},
                new SqlParameter("@CodTipoContato", SqlDbType.Int){Value = contato.TipoContato.CodTipoContato},
                new SqlParameter("@DDD", SqlDbType.VarChar, 3){Value = contato.Ddd},
                new SqlParameter("@Telefone", SqlDbType.VarChar, 15){Value = contato.Telefone},
                new SqlParameter("@Email", SqlDbType.VarChar, 100){Value = contato.Email},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = contato.Quem },
            };

            var command = MontaCommand(parametros, "dbo.P_CONTATO_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public void ExcluirContatoEmpresa(int codEmpresa, int codContato, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int) { Value = codEmpresa },
                new SqlParameter("@CodContato", SqlDbType.Int) { Value = codContato },
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_CONTATO_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }
                
        public void ExcluirContatoPessoa(int codPessoa, int codContato, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoa", SqlDbType.Int) { Value = codPessoa },
                new SqlParameter("@CodContato", SqlDbType.Int) { Value = codContato },
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },
            };

            var command = MontaCommand(parametros, "dbo.P_CONTATO_CLIENTE_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }

        public int InserirContatoEmpresa(Empresa empresa)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int){Value = empresa.CodEmpresa},
                new SqlParameter("@CodTipoContato", SqlDbType.Int){Value = empresa.Contato.TipoContato.CodTipoContato},
                new SqlParameter("@DDD", SqlDbType.VarChar, 3){Value = empresa.Contato.Ddd},
                new SqlParameter("@Telefone", SqlDbType.VarChar, 15){Value = empresa.Contato.Telefone},
                new SqlParameter("@Email", SqlDbType.VarChar, 100){Value = empresa.Contato.Email},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value =  empresa.Contato.Quem },
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_CONTATO_INCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }

        public int InserirContatoPessoa(Pessoa pessoa)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoa", SqlDbType.Int){Value = pessoa.CodPessoa},
                new SqlParameter("@CodTipoContato", SqlDbType.Int){Value = pessoa.Contato.TipoContato.CodTipoContato},
                new SqlParameter("@DDD", SqlDbType.VarChar, 3){Value = pessoa.Contato.Ddd},
                new SqlParameter("@Telefone", SqlDbType.VarChar, 15){Value = pessoa.Contato.Telefone},
                new SqlParameter("@Email", SqlDbType.VarChar, 100){Value = pessoa.Contato.Email},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value =  pessoa.Contato.Quem },
            };

            var command = MontaCommand(parametros, "dbo.P_CONTATO_CLIENTE_INCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }

        public List<Contato> ListarContatosEmpresa(int codEmpresa)
        {
            var lstcontatos = new List<Contato>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int) {Value = codEmpresa},
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_CONTATO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Contato();
                    _item.TipoContato = new TipoContato();

                    _item.CodContato = (dReader["CodContato"] as int?).GetValueOrDefault();
                    _item.CodEmpresa = (dReader["CodEmpresa"] as int?).GetValueOrDefault();
                    _item.TipoContato.CodTipoContato = (dReader["CodTipoContato"] as int?).GetValueOrDefault();
                    _item.TipoContato.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoContato");
                    _item.Ddd = Util.TrataCampos.GetStringSafe(dReader, "DDD");
                    _item.Telefone = Util.TrataCampos.GetStringSafe(dReader, "Telefone");
                    _item.Email = Util.TrataCampos.GetStringSafe(dReader, "Email");

                    lstcontatos.Add(_item);
                }
            }

            return lstcontatos;
        }

        public List<Contato> ListarContatosPessoa(int codPessoa)
        {
            var lstcontatos = new List<Contato>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPessoa", SqlDbType.Int) {Value = codPessoa},
            };

            var command = MontaCommand(parametros, "dbo.P_CONTATO_CLIENTE_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Contato();
                    _item.TipoContato = new TipoContato();

                    _item.CodContato = (dReader["CodContato"] as int?).GetValueOrDefault();
                    _item.CodPessoa = (dReader["CodPessoa"] as int?).GetValueOrDefault();
                    _item.TipoContato.CodTipoContato = (dReader["CodTipoContato"] as int?).GetValueOrDefault();
                    _item.TipoContato.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoContato");
                    _item.Ddd = Util.TrataCampos.GetStringSafe(dReader, "DDD");
                    _item.Telefone = Util.TrataCampos.GetStringSafe(dReader, "Telefone");
                    _item.Email = Util.TrataCampos.GetStringSafe(dReader, "Email");

                    lstcontatos.Add(_item);
                }
            }

            return lstcontatos;
        }

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

        public Contato ObterContato(int codContato)
        {
            var _item = new Contato();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodContato", SqlDbType.Int) {Value = codContato},
            };

            var command = MontaCommand(parametros, "dbo.P_CONTATO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item.TipoContato = new TipoContato();

                    _item.CodContato = (dReader["CodContato"] as int?).GetValueOrDefault();
                    _item.CodEmpresa = (dReader["CodEmpresa"] as int?).GetValueOrDefault();
                    _item.TipoContato.CodTipoContato = (dReader["CodTipoContato"] as int?).GetValueOrDefault();
                    _item.TipoContato.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoContato");
                    _item.Ddd = Util.TrataCampos.GetStringSafe(dReader, "DDD");
                    _item.Telefone = Util.TrataCampos.GetStringSafe(dReader, "Telefone");
                    _item.Email = Util.TrataCampos.GetStringSafe(dReader, "Email");
                }
            }

            return _item;
        }

        
    }
}
