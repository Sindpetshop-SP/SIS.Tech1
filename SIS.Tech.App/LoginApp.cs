using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using SIS.Tech.IDomain;

namespace SIS.Tech.App
{
    public class LoginApp : ILoginApp
    {
        private readonly ILoginBo _loginBo;

        public LoginApp(ILoginBo loginBo)
        {
            _loginBo = loginBo;
        }

        public int InserirLoginUsuario(UsuarioLogin usuarioLogin)
        {
            return _loginBo.InserirLoginUsuario(usuarioLogin);
        }

        public List<Departamento> ListarDepartamentos()
        {
            return _loginBo.ListarDepartamentos();
        }

        public void BloqueiaDesbloqueiaUsuario(int codUsuario, int codSistema, int flgAtivo, string quem)
        {
            _loginBo.BloqueiaDesbloqueiaUsuario(codUsuario, codSistema, flgAtivo, quem);
        }

        public void AlterarSenhaUsuario(int codUsuario, int codSistema, string vlrSenhaUsuario, string quem)
        {
            _loginBo.AlterarSenhaUsuario(codUsuario, codSistema, vlrSenhaUsuario, quem);
        }

        public string ResetarSenhaUsuario(int codUsuario, int codSistema, string quem)
        {
            return _loginBo.ResetarSenhaUsuario(codUsuario, codSistema, quem);
        }

        public string ObterNomeUsuarioLogin(int codUsuario)
        {
            return _loginBo.ObterNomeUsuarioLogin(codUsuario);
        }

        public void ResetarSenhaPorEmailUsuario(string email, int codSistema, string quem)
        {
            _loginBo.ResetarSenhaPorEmailUsuario(email, codSistema, quem);
        }

        public List<Perfil> ListarPerfis(int codSistema)
        {
            return _loginBo.ListarPerfis(codSistema);
        }

        public void AlterarControleUsuarioPorControle(int codControle, int codSistema, Boolean ativo, int codPerfil, string quem)
        {
            _loginBo.AlterarControleUsuarioPorControle(codControle, codSistema, ativo, codPerfil, quem);
        }

        public void AlterarControleUsuarioPorFormulario(int codFormulario, int codSistema, Boolean ativo, int codPerfil, string quem)
        {
            _loginBo.AlterarControleUsuarioPorFormulario(codFormulario, codSistema, ativo, codPerfil, quem);
        }

        public string GeraCodigoParaEsqueceuSenha(string email)
        {
            return _loginBo.GeraCodigoParaEsqueceuSenha(email);
        }

        public UsuarioLogin ValidaCodigoParaEsqueceuSenha(string codForamtado)
        {
            return _loginBo.ValidaCodigoParaEsqueceuSenha(codForamtado);
        }

        public UsuarioLogin ObtemDadosUsuarioParaEmail(string codUsuario)
        {
            return _loginBo.ObtemDadosUsuarioParaEmail(codUsuario);
        }

        

        public void ExcluirCodigoParaEsqueceuSenha(int codusuario)
        {
            _loginBo.ExcluirCodigoParaEsqueceuSenha(codusuario);
        }
        

    }
}
