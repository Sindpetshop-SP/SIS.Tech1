using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using SIS.Tech.IDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.App
{
    public class UsuarioApp : IUsuarioApp
    {
        private readonly IUsuarioBo _usuarioBo;

        public UsuarioApp(IUsuarioBo usuarioBo)
        {
            _usuarioBo = usuarioBo;
        }

        public List<UsuarioLogin> ListarUsuariosFiltro(string nomeUsuario, string nmeLoginUsuario, int codDepartamento, string numeroCpf, int codSistema)
        {
            return _usuarioBo.ListarUsuariosFiltro(nomeUsuario, nmeLoginUsuario, codDepartamento, numeroCpf, codSistema);
        }

        public UserTotalizadores ObterUserTotalizadores(int codSistema)
        {
            return _usuarioBo.ObterUserTotalizadores(codSistema);
        }

        
        public UsuarioLogin ObterUsuario(int codUsuario)
        {
            return _usuarioBo.ObterUsuario(codUsuario);
        }

        public string ObterNomeUsuario(string email)
        {
            return _usuarioBo.ObterNomeUsuario(email);
        }
        
    }
}
