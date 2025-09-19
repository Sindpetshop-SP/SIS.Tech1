using SIS.Tech.Domain.Model;
using SIS.Tech.IDomain;
using SIS.Tech.IRepository;

namespace SIS.Tech.Domain
{
    public class LoginBo : ILoginBo
    {
        private readonly ILoginRepository _loginRepository;

        public LoginBo(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public int InserirLoginUsuario(UsuarioLogin usuarioLogin)
        {
            return _loginRepository.InserirLoginUsuario(usuarioLogin);
        }

        public List<Departamento> ListarDepartamentos()
        {
            return _loginRepository.ListarDepartamentos();
        }

        public void BloqueiaDesbloqueiaUsuario(int codUsuario, int codSistema, int flgAtivo, string quem)
        {
            _loginRepository.BloqueiaDesbloqueiaUsuario(codUsuario, codSistema, flgAtivo, quem);
        }

        public void AlterarSenhaUsuario(int codUsuario, int codSistema, string vlrSenhaUsuario, string quem)
        {
            _loginRepository.AlterarSenhaUsuario(codUsuario, codSistema, vlrSenhaUsuario, quem);
        }

        public string ResetarSenhaUsuario(int codUsuario, int codSistema, string quem)
        {
           return _loginRepository.ResetarSenhaUsuario(codUsuario, codSistema, quem);
        }

        public string ObterNomeUsuarioLogin(int codUsuario)
        {
            return _loginRepository.ObterNomeUsuarioLogin(codUsuario);
        }

        public void ResetarSenhaPorEmailUsuario(string email, int codSistema, string quem)
        {
            _loginRepository.ResetarSenhaPorEmailUsuario(email, codSistema, quem);
        }

        public List<Perfil> ListarPerfis(int codSistema)
        {
            return _loginRepository.ListarPerfis(codSistema);
        }

        public void AlterarControleUsuarioPorControle(int codControle, int codSistema, Boolean ativo, int codPerfil, string quem)
        {
            _loginRepository.AlterarControleUsuarioPorControle(codControle, codSistema, ativo, codPerfil, quem);
        }

        public void AlterarControleUsuarioPorFormulario(int codFormulario, int codSistema, Boolean ativo, int codPerfil, string quem)
        {
            _loginRepository.AlterarControleUsuarioPorFormulario(codFormulario, codSistema, ativo, codPerfil, quem);
        }

        public string GeraCodigoParaEsqueceuSenha(string email)
        {
            return _loginRepository.GeraCodigoParaEsqueceuSenha(email);
        }

        public UsuarioLogin ValidaCodigoParaEsqueceuSenha(string codForamtado)
        {
            return _loginRepository.ValidaCodigoParaEsqueceuSenha(codForamtado);
        }

        public UsuarioLogin ObtemDadosUsuarioParaEmail(string codUsuario)
        {
            return _loginRepository.ObtemDadosUsuarioParaEmail(codUsuario);
        }
        



        public void ExcluirCodigoParaEsqueceuSenha(int codusuario)
        {
            _loginRepository.ExcluirCodigoParaEsqueceuSenha(codusuario);
        }
    }
}
