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
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public List<UsuarioLogin> ListarUsuariosFiltro(string nomeUsuario, string nmeLoginUsuario, int codDepartamento, string numeroCpf, int codSistema)
        {
            var lstUsuarios = new List<UsuarioLogin>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@nomeUsuario", SqlDbType.VarChar, 200) {Value = (object)nomeUsuario ?? DBNull.Value},
                new SqlParameter("@nmeLoginUsuario", SqlDbType.VarChar, 50) {Value = (object)nmeLoginUsuario ?? DBNull.Value},
                new SqlParameter("@codSistema", SqlDbType.Int) {Value = codSistema},
                new SqlParameter("@codDepartamento", SqlDbType.Int) {Value = (object)codDepartamento ?? DBNull.Value},
                new SqlParameter("@numeroCpf", SqlDbType.VarChar, 15) {Value = (object)numeroCpf ?? DBNull.Value},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_USUARIO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new UsuarioLogin();
                    _item.Departamento = new Departamento();

                    _item.CodUsuario = (dReader["CodUsuario"] as int?).GetValueOrDefault();

                    _item.Departamento.CodDepartamento = (dReader["CodDepartamento"] as int?).GetValueOrDefault();
                    _item.Departamento.Descricao = Util.TrataCampos.GetStringSafe(dReader, "NmeDepto");

                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "NroCnpjCpf");

                    _item.NmeUsuario = Util.TrataCampos.GetStringSafe(dReader, "NmeUsuario");

                    _item.NmeLoginUsuario = Util.TrataCampos.GetStringSafe(dReader, "NmeLoginUsuario");

                    _item.SitSenha = Util.TrataCampos.GetStringSafe(dReader, "SitSenha");

                    _item.Email = Util.TrataCampos.GetStringSafe(dReader, "DscEmail");

                    _item.Ativo = (dReader["FlgAtivo"] as bool?).GetValueOrDefault();


                    lstUsuarios.Add(_item);
                }
            }

            return lstUsuarios;
        }

        public UserTotalizadores ObterUserTotalizadores(int codSistema)
        {
            var _item = new UserTotalizadores();            

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodSistema", SqlDbType.Int) {Value = codSistema},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_USUARIOS_TOTALIZADORES_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item.TotalGeral = (dReader["TotalGeral"] as int?).GetValueOrDefault();
                    _item.TotalAtivo = (dReader["TotalAtivo"] as int?).GetValueOrDefault();
                    _item.TotalInativo = (dReader["TotalInativo"] as int?).GetValueOrDefault();
                    _item.TotalBloqueado = (dReader["TotalBloqueado"] as int?).GetValueOrDefault();
                }
            }

            return _item;
        }

        public UsuarioLogin ObterUsuario(int codUsuario)
        {

            var _item = new UsuarioLogin();
            _item.Departamento = new Departamento();


            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodUsuario", SqlDbType.Int) {Value = codUsuario},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_USUARIO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item.CodUsuario = (dReader["CodUsuario"] as int?).GetValueOrDefault();

                    _item.Departamento.CodDepartamento = (dReader["CodDepartamento"] as int?).GetValueOrDefault();
                    _item.Departamento.Descricao = Util.TrataCampos.GetStringSafe(dReader, "NmeDepto");

                    _item.Cpf = Util.TrataCampos.GetStringSafe(dReader, "NroCnpjCpf");

                    _item.NmeUsuario = Util.TrataCampos.GetStringSafe(dReader, "NmeUsuario");

                    _item.Email = Util.TrataCampos.GetStringSafe(dReader, "DscEmail");

                    _item.Ativo = (dReader["FlgAtivo"] as bool?).GetValueOrDefault();
                }
            }

            return _item;
        }


        public string ObterNomeUsuario(string email)
        {
            string nomeUsuario = string.Empty;

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Email", SqlDbType.VarChar, 150) {Value = email},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_USUARIO_OBTER_NOME", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    nomeUsuario = Util.TrataCampos.GetStringSafe(dReader, "NmeUsuario");

                }
            }

            return nomeUsuario;
        }
    }
}
