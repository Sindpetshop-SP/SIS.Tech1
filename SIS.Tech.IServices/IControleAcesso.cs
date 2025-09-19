using SIS.ControleAcesso.Model;

namespace SIS.Tech.IServices
{
    public interface IControleAcesso
    {
        Task<UsuarioSistemaPerfilInfo> LoginUsuario(int idSistema, string login, string senha, string ip);
    }
}
