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
    public class SenhaBancoRepository : BaseRepository, ISenhaBancoRepository
    {
        public List<SenhaBanco> ListarSenhaBanco(string usuario)
        {
            var lstSenhaBanco = new List<SenhaBanco>();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@Usuario", SqlDbType.VarChar, 6) {Value = usuario},
            };

            var command = MontaCommand(parametros, "dbo.P_SENHA_BANCO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {

                    var _item = new SenhaBanco();

                    _item.CodSenhaBanco = (dReader["CodSenhaBanco"] as int?).GetValueOrDefault();

                    _item.Instituicao = new Instituicao();
                    _item.Instituicao.CodInstituicao = (dReader["CodInstituicao"] as int?).GetValueOrDefault();
                    _item.Instituicao.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescInstituicao");

                    _item.Banco = new Banco();
                    _item.Banco.CodBanco = (dReader["CodBanco"] as int?).GetValueOrDefault();
                    _item.Banco.NomeBanco = Util.TrataCampos.GetStringSafe(dReader, "NomeBanco");

                    _item.ContaTipo = new ContaTipo();
                    _item.ContaTipo.CodContaTipo = (dReader["CodContaTipo"] as int?).GetValueOrDefault();
                    _item.ContaTipo.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescContaTipo");


                    _item.NumAgencia = Util.TrataCampos.GetStringSafe(dReader, "NumAgencia");
                    _item.NumConta = Util.TrataCampos.GetStringSafe(dReader, "NumConta");
                    _item.CpfTitular = Util.TrataCampos.GetStringSafe(dReader, "CpfTitular");
                    _item.SenhaEletronica = Util.TrataCampos.GetStringSafe(dReader, "SenhaEletronica");
                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");

                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");


                    lstSenhaBanco.Add(_item);
                }
            }

            return lstSenhaBanco;
        }

        public List<SenhaBanco> ListarSenhaBancoFiltro(string codInstituicao, string usuario)
        {
            var lstSenhaBanco = new List<SenhaBanco>();

            int codInstituicaoAux = 0;
            int codBancoAux = 0;
            int codContaTipoAux = 0;

            if (!string.IsNullOrEmpty(codInstituicao))
            {
                codInstituicaoAux = Convert.ToInt32(codInstituicao);
            }

            //if (!string.IsNullOrEmpty(codBanco))
            //{
            //    codBancoAux = Convert.ToInt32(codBanco);
            //}

            //if (!string.IsNullOrEmpty(codContaTipo))
            //{
            //    codContaTipoAux = Convert.ToInt32(codContaTipo);
            //}
             
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodInstituicao", SqlDbType.Int) {Value = codInstituicaoAux},
                new SqlParameter("@Usuario", SqlDbType.VarChar, 6) {Value = usuario},
                //new SqlParameter("@CodBanco", SqlDbType.Int) {Value = codBancoAux},
                //new SqlParameter("@CodContaTipo", SqlDbType.Int) {Value = codContaTipoAux},
            };

            var command = MontaCommand(parametros, "dbo.P_SENHA_BANCO_LISTAR_FILTRO", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new SenhaBanco();

                    _item.CodSenhaBanco = (dReader["CodSenhaBanco"] as int?).GetValueOrDefault();

                    _item.Instituicao = new Instituicao();
                    _item.Instituicao.CodInstituicao = (dReader["CodInstituicao"] as int?).GetValueOrDefault();
                    _item.Instituicao.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescInstituicao");

                    _item.Banco = new Banco();
                    _item.Banco.CodBanco = (dReader["CodBanco"] as int?).GetValueOrDefault();
                    _item.Banco.NomeBanco = Util.TrataCampos.GetStringSafe(dReader, "NomeBanco");

                    _item.ContaTipo = new ContaTipo();
                    _item.ContaTipo.CodContaTipo = (dReader["CodContaTipo"] as int?).GetValueOrDefault();
                    _item.ContaTipo.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescContaTipo");


                    _item.NumAgencia = Util.TrataCampos.GetStringSafe(dReader, "NumAgencia");
                    _item.NumConta = Util.TrataCampos.GetStringSafe(dReader, "NumConta");
                    _item.CpfTitular = Util.TrataCampos.GetStringSafe(dReader, "CpfTitular");
                    _item.SenhaEletronica = Util.TrataCampos.GetStringSafe(dReader, "SenhaEletronica");
                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");

                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");

                    lstSenhaBanco.Add(_item);
                }
            }

            return lstSenhaBanco;
        }


        public SenhaBanco ObterSenhaBanco(int codSenhaBanco, string usuario)
        {
            var _item = new SenhaBanco();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodSenhaBanco", SqlDbType.Int) {Value = codSenhaBanco},
                new SqlParameter("@Usuario", SqlDbType.VarChar, 6) {Value = usuario},
            };

            var command = MontaCommand(parametros, "dbo.P_SENHA_BANCO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = new SenhaBanco();

                    _item.CodSenhaBanco = (dReader["CodSenhaBanco"] as int?).GetValueOrDefault();

                    _item.Instituicao = new Instituicao();
                    _item.Instituicao.CodInstituicao = (dReader["CodInstituicao"] as int?).GetValueOrDefault();
                    _item.Instituicao.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescInstituicao");

                    _item.Banco = new Banco();
                    _item.Banco.CodBanco = (dReader["CodBanco"] as int?).GetValueOrDefault();
                    _item.Banco.NomeBanco = Util.TrataCampos.GetStringSafe(dReader, "NomeBanco");

                    _item.ContaTipo = new ContaTipo();
                    _item.ContaTipo.CodContaTipo = (dReader["CodContaTipo"] as int?).GetValueOrDefault();
                    _item.ContaTipo.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescContaTipo");


                    _item.NumAgencia = Util.TrataCampos.GetStringSafe(dReader, "NumAgencia");
                    _item.NumConta = Util.TrataCampos.GetStringSafe(dReader, "NumConta");
                    _item.CpfTitular = Util.TrataCampos.GetStringSafe(dReader, "CpfTitular");
                    _item.SenhaEletronica = Util.TrataCampos.GetStringSafe(dReader, "SenhaEletronica");
                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");

                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();
                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");
                }
            }

            return _item;
        }

        public int AlterarSenhaBanco(SenhaBanco senhaBanco)
        {
            var parametros = new List<SqlParameter>
            {
                 new SqlParameter("@CodSenhaBanco", SqlDbType.Int){Value = senhaBanco.CodSenhaBanco},
                new SqlParameter("@CodInstituicao", SqlDbType.Int){Value = senhaBanco.Instituicao.CodInstituicao},
                 new SqlParameter("@CodBanco", SqlDbType.VarChar, 100){Value = senhaBanco.Banco.CodBanco},
                 new SqlParameter("@CodContaTipo", SqlDbType.VarChar, 100){Value = senhaBanco.ContaTipo.CodContaTipo},
                 new SqlParameter("@NumAgencia", SqlDbType.VarChar, 80){Value = senhaBanco.NumAgencia},
                 new SqlParameter("@NumConta", SqlDbType.VarChar, 80){Value = senhaBanco.NumConta},
                 new SqlParameter("@CpfTitular", SqlDbType.VarChar, 14){Value = senhaBanco.CpfTitular},
                 new SqlParameter("@SenhaEletronica", SqlDbType.VarChar, 80){Value = senhaBanco.SenhaEletronica},
                 new SqlParameter("@Observacao", SqlDbType.VarChar, 255){Value = senhaBanco.Observacao},
                 new SqlParameter("@Ativo", SqlDbType.Bit){Value = senhaBanco.Ativo},
                 new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = senhaBanco.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_SENHA_BANCO_ALTERAR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int ExcluirSenhaBanco(int codSenhaBanco, string quem)
        {
            var parametros = new List<SqlParameter>
            {
               new SqlParameter("@CodSenhaBanco", SqlDbType.Int){Value = codSenhaBanco},
               new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_SENHA_BANCO_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public int InserirSenhaBanco(SenhaBanco senhaBanco)
        {
            var parametros = new List<SqlParameter>
            {
                 new SqlParameter("@CodInstituicao", SqlDbType.Int){Value = senhaBanco.Instituicao.CodInstituicao},
                 new SqlParameter("@CodBanco", SqlDbType.VarChar, 100){Value = senhaBanco.Banco.CodBanco},
                 new SqlParameter("@CodContaTipo", SqlDbType.VarChar, 100){Value = senhaBanco.ContaTipo.CodContaTipo},
                 new SqlParameter("@NumAgencia", SqlDbType.VarChar, 80){Value = senhaBanco.NumAgencia},
                 new SqlParameter("@NumConta", SqlDbType.VarChar, 80){Value = senhaBanco.NumConta},
                 new SqlParameter("@CpfTitular", SqlDbType.VarChar, 14){Value = senhaBanco.CpfTitular},
                 new SqlParameter("@SenhaEletronica", SqlDbType.VarChar, 80){Value = senhaBanco.SenhaEletronica},
                 new SqlParameter("@Observacao", SqlDbType.VarChar, 255){Value = senhaBanco.Observacao},
                 new SqlParameter("@Ativo", SqlDbType.Bit){Value = senhaBanco.Ativo},
                 new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = senhaBanco.Quem},
            };

            var command = MontaCommand(parametros, "dbo.P_SENHA_BANCO_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }


    }
}
