using SIS.Tech.Domain.Model;
using SIS.Tech.IDomain;
using SIS.Tech.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain
{
    public class UsuarioBo : IUsuarioBo
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioBo(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<UsuarioLogin> ListarUsuariosFiltro(string nomeUsuario, string nmeLoginUsuario, int codDepartamento, string numeroCpf, int codSistema)
        {
            return _usuarioRepository.ListarUsuariosFiltro(nomeUsuario, nmeLoginUsuario, codDepartamento, numeroCpf, codSistema);
        }

        public UserTotalizadores ObterUserTotalizadores(int codSistema)
        {
            return _usuarioRepository.ObterUserTotalizadores(codSistema);
        }
        public UsuarioLogin ObterUsuario(int codUsuario)
        {
            return _usuarioRepository.ObterUsuario(codUsuario);
        }

        public string ObterNomeUsuario(string email)
        {
            return _usuarioRepository.ObterNomeUsuario(email);
        }
    }
}
