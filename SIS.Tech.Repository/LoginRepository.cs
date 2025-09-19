using SIS.Tech.Domain.Model;
using SIS.Tech.IRepository;
using SISFramework.DataAccess.Ado;
using SISFramework.Security.Criptografia;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace SIS.Tech.Repository
{
  public class LoginRepository : BaseRepository, ILoginRepository
  {

        public int InserirLoginUsuario(UsuarioLogin usuarioLogin)
        {
            var parametros = new List<SqlParameter>
            {

                new SqlParameter("@VlrSenhaUsuario", SqlDbType.VarChar, 1000) {Value = usuarioLogin.VlrSenhaUsuario},
                new SqlParameter("@NroCnpjCpf", SqlDbType.VarChar, 14) {Value = usuarioLogin.Cpf},
                new SqlParameter("@NmeUsuario", SqlDbType.VarChar, 200) {Value = usuarioLogin.NmeUsuario},
                new SqlParameter("@DscEmail", SqlDbType.VarChar, 100) {Value = usuarioLogin.Email},
                new SqlParameter("@CodDepartamento", SqlDbType.Int) {Value = usuarioLogin.Departamento.CodDepartamento},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) {Value = "fixo01"},
                new SqlParameter("@CodSistemaOri", SqlDbType.Int) {Value = usuarioLogin.CodSistema},

            };

            var command = MontaCommandSGE(parametros, "dbo.P_LOGIN_REGISTRO", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            RepliacarAcessos(usuarioLogin.Departamento.CodDepartamento);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }

        public void RepliacarAcessos(int codPerfil)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodPerfil", SqlDbType.Int) {Value = codPerfil},             

            };

            var command = MontaCommandSGE(parametros, "dbo.P_ACESSOS_REPLICAR", 600);

            DbHelper.ExecuteNonQuery(command);
        }

        public List<Departamento> ListarDepartamentos()
        {
            var lstDepartamento = new List<Departamento>();

            var parametros = new List<SqlParameter>();

            var command = MontaCommandSGE(parametros, "dbo.P_LOGIN_DEPARTAMENTO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Departamento();

                    _item.CodDepartamento = (dReader["CodDepartamento"] as int?).GetValueOrDefault();

                    _item.Descricao = Util.TrataCampos.GetStringSafe(dReader, "NmeDepto");


                    lstDepartamento.Add(_item);
                }
            }

            return lstDepartamento;
        }

        public void BloqueiaDesbloqueiaUsuario(int codUsuario, int codSistema, int flgAtivo, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodUsuario", SqlDbType.Int){Value = codUsuario},
                new SqlParameter("@CodSistema", SqlDbType.Int){Value = codSistema},
                new SqlParameter("@FlgAtivo", SqlDbType.Int){Value = flgAtivo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },
            };

            var command = MontaCommandSGE(parametros, "dbo.P_LOGIN_BLOQUEIO_DESBLOQUEIO_USUARIO", 600);

            DbHelper.ExecuteNonQuery(command);
        }

        public void AlterarSenhaUsuario(int codUsuario, int codSistema, string vlrSenhaUsuario, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodUsuario", SqlDbType.Int){Value = codUsuario},
                new SqlParameter("@CodSistema", SqlDbType.Int){Value = codSistema},
                new SqlParameter("@VlrSenhaUsuario", SqlDbType.VarChar){Value = vlrSenhaUsuario},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },
            };

            var command = MontaCommandSGE(parametros, "dbo.P_LOGIN_ALTERAR_SENHA_USUARIO", 600);

            DbHelper.ExecuteNonQuery(command);
        }

        public string ResetarSenhaUsuario(int codUsuario, int codSistema, string quem)
        {
            string senhaCryptoNew = "Sindpetshop" + DateTime.Now.Hour + DateTime.Now.Millisecond;

            var senhaCrypto = Helper.Criptografar(senhaCryptoNew, EncryptAlgorithm.EncryptionAlgorithm.Rijndael);

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodUsuario", SqlDbType.Int){Value = codUsuario},
                new SqlParameter("@CodSistema", SqlDbType.Int){Value = codSistema},                
                new SqlParameter("@SenhaCryptoNew", SqlDbType.VarChar, 1000) { Value = senhaCrypto },
                
            };

            var command = MontaCommandSGE(parametros, "dbo.P_LOGIN_RESETAR_SENHA_USUARIO", 600);

            DbHelper.ExecuteNonQuery(command);

            return senhaCryptoNew;
        }

        public string ObterNomeUsuarioLogin(int codUsuario)
        {
            var _item = new UsuarioLogin();

            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@CodUsuario", SqlDbType.Int) {Value = codUsuario},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_LOGIN_NOME_USUARIO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item.NmeUsuario = Util.TrataCampos.GetStringSafe(dReader, "NmeLoginUsuario");
                }
            }

            return _item.NmeUsuario;
        }


        public void ResetarSenhaPorEmailUsuario(string email, int codSistema, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@DscEmail", SqlDbType.VarChar, 100){Value = email},
                new SqlParameter("@CodSistema", SqlDbType.Int){Value = codSistema},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },
            };

            var command = MontaCommandSGE(parametros, "dbo.P_LOGIN_RESETAR_SENHA_POR_EMAIL_USUARIO", 600);

            DbHelper.ExecuteNonQuery(command);
        }

        


        public List<Perfil> ListarPerfis(int codSistema)
        {
            var lstPerfil = new List<Perfil>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodSistema", SqlDbType.Int){Value = codSistema},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_LOGIN_PERFIL_LISTAR", 600);

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


        public void AlterarControleUsuarioPorControle(int codControle, int codSistema, Boolean ativo, int codPerfil, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodControle", SqlDbType.Int){Value = codControle},
                new SqlParameter("@CodSistema", SqlDbType.Int){Value = codSistema},
                new SqlParameter("@Ativo", SqlDbType.Bit){Value = ativo},
                new SqlParameter("@CodPerfil", SqlDbType.Int){Value = codPerfil},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },

            };

            var command = MontaCommandSGE(parametros, "dbo.P_CONTROLE_SGE_ALTERAR_POR_CONTROLE", 600);

            DbHelper.ExecuteNonQuery(command);
        }

        public void AlterarControleUsuarioPorFormulario(int codFormulario, int codSistema, Boolean ativo, int codPerfil, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodFormulario", SqlDbType.Int){Value = codFormulario},
                new SqlParameter("@CodSistema", SqlDbType.Int){Value = codSistema},
                new SqlParameter("@Ativo", SqlDbType.Bit){Value = ativo},
                new SqlParameter("@CodPerfil", SqlDbType.Int){Value = codPerfil},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },
            };

            var command = MontaCommandSGE(parametros, "dbo.P_CONTROLE_SGE_ALTERAR_POR_FORMULARIO", 600);

            DbHelper.ExecuteNonQuery(command);
        }

        public string GeraCodigoParaEsqueceuSenha(string email)
        {
            string codigoTEMP = GerarSenhasInt();

            string codFormatado = string.Empty;

            if (!string.IsNullOrEmpty(codigoTEMP))
            {
                for (int i = 0; i < codigoTEMP.Length; i++)
                {
                    if (i == 5 )
                        codFormatado = codFormatado + codigoTEMP[i];
                    else
                        codFormatado = codFormatado + codigoTEMP[i] + " - ";
                }
            }

            var parametros = new List<SqlParameter>
            {                
                new SqlParameter("@Email", SqlDbType.VarChar, 150) { Value = email},
                new SqlParameter("@codigoTEMP", SqlDbType.VarChar, 21) { Value = codFormatado},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_SALVAR_CODIGO_ESQUECEU_SENHA_USUARIO", 600);

            DbHelper.ExecuteNonQuery(command);

            return codFormatado;
        }

        public string GerarSenhasInt()
        {
            int Tamanho = 6; // Numero de digitos da senha

            string codigo1 = string.Empty;
            string codigo2 = string.Empty;
            string codigo3 = string.Empty;
            string codigo4 = string.Empty;
            string codigo5 = string.Empty;
            string codigo6 = string.Empty;

            Random random = new Random();
            codigo1 = random.Next(1, 10).ToString();
            codigo2 = random.Next(1, 10).ToString();
            codigo3 = random.Next(1, 10).ToString();
            codigo4 = random.Next(1, 10).ToString();
            codigo5 = random.Next(1, 10).ToString();
            codigo6 = random.Next(1, 10).ToString();

            return codigo1 + codigo2 + codigo3 + codigo4 + codigo5 + codigo6;
        }

        public string GerarSenhas()
        {
            int Tamanho = 6; // Numero de digitos da senha
            string senha = string.Empty;
            for (int i = 0; i < Tamanho; i++)
            {
                Random random = new Random();
                int codigo = Convert.ToInt32(random.Next(48, 122).ToString());

                if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122))
                {
                    string _char = ((char)codigo).ToString();
                    if (!senha.Contains(_char))
                    {
                        senha += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }
            return senha;
        }


        public UsuarioLogin ValidaCodigoParaEsqueceuSenha(string codForamtado)
        {
            UsuarioLogin usuario = new UsuarioLogin();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodFormatado", SqlDbType.VarChar, 21){Value = codForamtado},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_CODIGO_ESQUECEU_SENHA_USUARIO_VALIDAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    usuario.CodUsuario = (dReader["CodUsuario"] as int?).GetValueOrDefault();
                    usuario.NmeUsuario = Util.TrataCampos.GetStringSafe(dReader, "NmeUsuario");
                    usuario.Email = Util.TrataCampos.GetStringSafe(dReader, "Email");
                }
            }

            if (usuario.CodUsuario > 0)
            {
                ExcluirCodigoParaEsqueceuSenha(usuario.CodUsuario);

                usuario.senhaCryptoNew = ResetarSenhaUsuario(usuario.CodUsuario, 1, "sistec");

            }

            return usuario;
        }

        public UsuarioLogin ObtemDadosUsuarioParaEmail(string codUsuario)
        {
            UsuarioLogin usuario = new UsuarioLogin();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodUsuario", SqlDbType.Int){Value = codUsuario},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_OBTEM_DADOS_USUARIO_PARA_EMAIL", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    usuario.CodUsuario = (dReader["CodUsuario"] as int?).GetValueOrDefault();
                    usuario.NmeUsuario = Util.TrataCampos.GetStringSafe(dReader, "NmeUsuario");
                    usuario.Email = Util.TrataCampos.GetStringSafe(dReader, "Email");
                }
            }

            return usuario;
        }

        public void ExcluirCodigoParaEsqueceuSenha(int codusuario)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodUsuario", SqlDbType.Int){Value = codusuario},
            };

            var command = MontaCommandSGE(parametros, "dbo.P_CODIGO_ESQUECEU_SENHA_USUARIO_EXCLUIR", 600);

            DbHelper.ExecuteNonQuery(command);            
        }

    }
}
