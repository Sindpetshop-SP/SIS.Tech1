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
    public class SocioRepository : BaseRepository, ISocioRepository
    {

        public int AlterarSocios(Socios socios)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodSocio", SqlDbType.Int) {Value = socios.CodSocio},
                new SqlParameter("@Nome", SqlDbType.VarChar, 150) {Value = socios.Nome},
                new SqlParameter("@Cpf", SqlDbType.VarChar, 14) {Value = socios.Cpf},
                new SqlParameter("@Observacao", SqlDbType.VarChar, 255) {Value = socios.Observacao},
                new SqlParameter("@Ativo", SqlDbType.Bit) {Value = socios.Ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = socios.Quem}
            };

            var command = MontaCommand(parametros, "dbo.P_SOCIO_ALTERAR", 600);

            DbHelper.ExecuteNonQuery(command);

            return 0;
        }

        public int ExcluirSocios(int codSocios, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodSocio", SqlDbType.Int) {Value = codSocios},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = quem},
            };

            var command = MontaCommand(parametros, "dbo.P_SOCIO_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }

        public int IncluirSocios(Socios socios)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodSocio", SqlDbType.Int) {Value = socios.CodSocio},
                new SqlParameter("@Nome", SqlDbType.VarChar, 150) {Value = socios.Nome},
                new SqlParameter("@Cpf", SqlDbType.VarChar, 14) {Value = socios.Cpf},
                new SqlParameter("@Observacao", SqlDbType.VarChar, 255) {Value = socios.Observacao},
                new SqlParameter("@Ativo", SqlDbType.Bit) {Value = socios.Ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = socios.Quem}
            };

            var command = MontaCommand(parametros, "dbo.P_SOCIO_INCLUIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }

        public List<Socios> ListarSocios(int codSocio, string nome, string cpf)
        {
            var lstSocios = new List<Socios>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodSocio", SqlDbType.Int) {Value = codSocio},
                new SqlParameter("@Nome", SqlDbType.VarChar, 150) {Value = nome},
                new SqlParameter("@Cpf", SqlDbType.VarChar, 14) {Value = cpf},                
            };

            var command = MontaCommand(parametros, "dbo.P_SOCIO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Socios();

                    _item.CodSocio = (dReader["CodSocio"] as int?).GetValueOrDefault();
                    _item.Nome = Util.TrataCampos.GetStringSafe(dReader, "Nome");
                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "Cpf");
                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");
                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();

                    lstSocios.Add(_item);
                }
            }

            return lstSocios;
        }


        public List<Socios> ListarSociosEmpresa(int codEmpresa)
        {
            var lstSocios = new List<Socios>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodEmpresa", SqlDbType.Int) {Value = codEmpresa}
            };

            var command = MontaCommand(parametros, "dbo.P_EMPRESA_SOCIO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Socios();

                    _item.CodSocio = (dReader["CodSocio"] as int?).GetValueOrDefault();
                    _item.Nome = Util.TrataCampos.GetStringSafe(dReader, "Nome");
                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "Cpf");
                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");
                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();

                    lstSocios.Add(_item);
                }
            }

            return lstSocios;
        }

        public Socios ObterSocios(int codSocio)
        {
            var socio = new Socios();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodSocio", SqlDbType.Int) {Value = codSocio},
            };

            var command = MontaCommand(parametros, "dbo.P_Socios_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Socios();

                    _item.CodSocio = (dReader["CodSocio"] as int?).GetValueOrDefault();
                    _item.Nome = Util.TrataCampos.GetStringSafe(dReader, "Nome");
                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "Cpf");
                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");
                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();

                    socio = _item;
                }
            }

            return socio;
        }

        
    }
}
