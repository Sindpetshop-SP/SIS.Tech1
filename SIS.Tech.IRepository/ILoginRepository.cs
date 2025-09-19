using SIS.Tech.Domain.Model;

namespace SIS.Tech.IRepository
{
    public interface ILoginRepository
    {
        int InserirLoginUsuario(UsuarioLogin usuarioLogin);

        List<Departamento> ListarDepartamentos();

        void BloqueiaDesbloqueiaUsuario(int codUsuario, int codSistema, int flgAtivo, string quem);

        void AlterarSenhaUsuario(int codUsuario, int codSistema, string vlrSenhaUsuario, string quem);

        string ResetarSenhaUsuario(int codUsuario, int codSistema, string quem);

        string ObterNomeUsuarioLogin(int codUsuario);

        void ResetarSenhaPorEmailUsuario(string email, int codSistema, string quem);

        List<Perfil> ListarPerfis(int codSistema);

        void AlterarControleUsuarioPorControle(int codControle, int codSistema, bool ativo, int codPerfil, string quem);

        void AlterarControleUsuarioPorFormulario(int codFormulario, int codSistema, bool ativo, int codPerfil, string quem);

        string GeraCodigoParaEsqueceuSenha(string email);

        UsuarioLogin ValidaCodigoParaEsqueceuSenha(string codForamtado);

        UsuarioLogin ObtemDadosUsuarioParaEmail(string codUsuario);

        void ExcluirCodigoParaEsqueceuSenha(int codusuario);
    }
}
