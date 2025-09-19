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
    public class AccessRepository : BaseRepository, IAccessRepository
    {
        public List<Perfil> ListarPerfis()
        {
            var lstPerfil = new List<Perfil>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommandSGE(parametros, "dbo.P_PERFIL_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Perfil();

                    _item.CodPerfil = (dReader["CodPerfil"] as int?).GetValueOrDefault();
                    _item.NmePerfil = Util.TrataCampos.GetStringSafe(dReader, "NmePerfil");

                    lstPerfil.Add(_item);
                }
            }

            return lstPerfil;
        }

        public Roles ListarRoles(int codPerfil)
        {
            var _item = new Roles();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPerfil", SqlDbType.Int) {Value =  codPerfil},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_ROLES_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item.CodPerfil = (dReader["CodPerfil"] as int?).GetValueOrDefault();
                    _item.NmePerfil = Util.TrataCampos.GetStringSafe(dReader, "NmePerfil");

                    _item.CodUsuario = (dReader["CodUsuario"] as int?).GetValueOrDefault();
                    _item.NmeUsuario = Util.TrataCampos.GetStringSafe(dReader, "NmeUsuario");

                    _item.QtdeUsuario = (dReader["QtdeUsuario"] as int?).GetValueOrDefault();
                    _item.QtdeControlesAtivos = (dReader["QtdeControlesAtivos"] as int?).GetValueOrDefault();
                }
            }

            return _item;
        }

        public List<ControleAcessoSGE> ListarControleAcessos(int codPerfil, int codUsuario, string nomeUsuario, string nmeLoginUsuario)
        {
            var lstControleAcesso = new List<ControleAcessoSGE>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPerfil", SqlDbType.Int){Value = codPerfil},
                new SqlParameter("@CodSistema", SqlDbType.Int){Value = 1},
                new SqlParameter("@CodUsuario", SqlDbType.Int){Value = codUsuario},
                new SqlParameter("@NomeUsuario", SqlDbType.VarChar,200){Value = nomeUsuario},
                new SqlParameter("@NmeLoginUsuario", SqlDbType.VarChar,50){Value = nmeLoginUsuario},

            };

            var command = MontaCommandSGE(parametros, "dbo.P_LOGIN_CONTROLE_ACESSO_SGE_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new ControleAcessoSGE();

                    _item.CodUsuario = (dReader["CodUsuario"] as int?).GetValueOrDefault();

                    if (_item.CodUsuario > 0)
                        _item.CodPerfil = (dReader["CodPerfil1"] as int?).GetValueOrDefault();
                    else
                        _item.CodPerfil = (dReader["CodPerfil"] as int?).GetValueOrDefault();

                    _item.NmePerfil = Util.TrataCampos.GetStringSafe(dReader, "NmePerfil");

                    _item.CodFormulario = (dReader["CodFormulario"] as int?).GetValueOrDefault();

                    _item.NmeFormulario = Util.TrataCampos.GetStringSafe(dReader, "NmeFormulario");

                    //_item.DscFormulario = Util.TrataCampos.GetStringSafe(dReader, "DscFormulario");

                    _item.CodControle = (dReader["CodControle"] as int?).GetValueOrDefault();

                    _item.NmeControle = Util.TrataCampos.GetStringSafe(dReader, "NmeControle");

                    _item.NomeUsuario = Util.TrataCampos.GetStringSafe(dReader, "NomeUsuario");



                    _item.FlgTemAcesso = (dReader["FlgTemAcesso"] as bool?).GetValueOrDefault();

                    lstControleAcesso.Add(_item);
                }
            }

            return lstControleAcesso;
        }

        public List<Permissions> ListarPermissoesAcessos(string nomeUsuario, string nmeLoginUsuario, string codPerfil)
        {

            var lstPermissions = new List<Permissions>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPerfil", SqlDbType.Int){Value = codPerfil},
                new SqlParameter("@NomeUsuario", SqlDbType.VarChar,200){Value = nomeUsuario},
                new SqlParameter("@NmeLoginUsuario", SqlDbType.VarChar,50){Value = nmeLoginUsuario},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_PERMISSION_CONTROLE_ACESSO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Permissions();

                    _item.CodUsuario = (dReader["CodUsuario"] as int?).GetValueOrDefault();

                    _item.NmeUsuario = Util.TrataCampos.GetStringSafe(dReader, "NmeUsuario");

                    _item.NroCnpjCpf = Util.TrataCampos.GetStringSafe(dReader, "NroCnpjCpf");

                    _item.DscEmail = Util.TrataCampos.GetStringSafe(dReader, "DscEmail");

                    _item.FlgAtivo = (dReader["FlgAtivo"] as bool?).GetValueOrDefault();

                    _item.CodPerfil = (dReader["CodPerfil"] as int?).GetValueOrDefault();

                    _item.NmePerfil = Util.TrataCampos.GetStringSafe(dReader, "NmePerfil");

                    _item.CodFormulario = (dReader["CodFormulario"] as int?).GetValueOrDefault();

                    _item.NmeFormulario = Util.TrataCampos.GetStringSafe(dReader, "NmeFormulario");

                    _item.CodControle = (dReader["CodControle"] as int?).GetValueOrDefault();

                    _item.NmeControle = Util.TrataCampos.GetStringSafe(dReader, "NmeControle");

                    _item.FlgTemAcesso = (dReader["FlgTemAcesso"] as bool?).GetValueOrDefault();

                    lstPermissions.Add(_item);
                }
            }

            return lstPermissions;
        }

        public void AlterarControleUsuarioPorControle(int codControle, bool ativo, int codPerfil, string quem, int codUsusario)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodControle", SqlDbType.Int){Value = codControle},
                new SqlParameter("@CodSistema", SqlDbType.Int){Value = 1},
                new SqlParameter("@Ativo", SqlDbType.Bit){Value = ativo},
                new SqlParameter("@CodPerfil", SqlDbType.Int){Value = codPerfil},
                new SqlParameter("@CodUsuario", SqlDbType.Int){Value = codUsusario},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },

            };

            var command = MontaCommandSGE(parametros, "dbo.P_CONTROLE_SGE_ALTERAR_POR_CONTROLE", 600);

            DbHelper.ExecuteNonQuery(command);
        }

        public void AlterarControleUsuarioPorFormulario(int codFormulario, bool ativo, int codPerfil, string quem, int codUsusario)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodFormulario", SqlDbType.Int){Value = codFormulario},
                new SqlParameter("@CodSistema", SqlDbType.Int){Value = 1},
                new SqlParameter("@Ativo", SqlDbType.Bit){Value = ativo},
                new SqlParameter("@CodPerfil", SqlDbType.Int){Value = codPerfil},
                new SqlParameter("@CodUsuario", SqlDbType.Int){Value = codUsusario},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },
            };

            var command = MontaCommandSGE(parametros, "dbo.P_CONTROLE_SGE_ALTERAR_POR_FORMULARIO", 600);

            DbHelper.ExecuteNonQuery(command);
        }


        public void AlterarControleUsuarioPorPerfil(int codPerfil, bool ativo, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPerfil", SqlDbType.Int){Value = codPerfil},
                new SqlParameter("@CodSistema", SqlDbType.Int){Value = 1},
                new SqlParameter("@Ativo", SqlDbType.Bit){Value = ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },
            };

            var command = MontaCommandSGE(parametros, "dbo.P_CONTROLE_SGE_ALTERAR_POR_PERFIL", 600);

            DbHelper.ExecuteNonQuery(command);
        }

        public int ObterPerfilUsuario(int codUsuario)
        {
            int _item = 0;

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodUsuario", SqlDbType.Int) {Value =  codUsuario},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_PERFIL_USARIO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item = (dReader["CodPerfil"] as int?).GetValueOrDefault();
                }
            }

            return _item;
        }

    }
}
