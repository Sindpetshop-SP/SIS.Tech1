using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IApp
{
    public interface IUsuarioApp
    {
        List<UsuarioLogin> ListarUsuariosFiltro(string nomeUsuario, string nmeLoginUsuario, int codDepartamento, string numeroCpf, int codSistema);

        UserTotalizadores ObterUserTotalizadores(int codSistema);

        UsuarioLogin ObterUsuario(int codUsuario);

        string ObterNomeUsuario(string email);
    }
}
