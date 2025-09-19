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
    public class AccessApp : IAccessApp
    {
        private readonly IAccessBo _accessBo;

        public AccessApp(IAccessBo accessBo)
        {
            _accessBo = accessBo;
        }

        public List<Perfil> ListarPerfis()
        {
            return _accessBo.ListarPerfis();
        }

        public Roles ListarRoles(int codPerfil)
        {
            return _accessBo.ListarRoles(codPerfil);
        }

        public List<ControleAcessoSGE> ListarControleAcessos(int codPerfil, int codUsuario, string nomeUsuario, string nmeLoginUsuario)
        {
            return _accessBo.ListarControleAcessos(codPerfil, codUsuario, nomeUsuario, nmeLoginUsuario);
        }
        public List<Permissions> ListarPermissoesAcessos(string nomeUsuario, string nmeLoginUsuario, string codPerfil)
        {
            return _accessBo.ListarPermissoesAcessos(nomeUsuario, nmeLoginUsuario, codPerfil);
        }
        
        public void AlterarControleUsuarioPorControle(int codControle, bool ativo, int codPerfil, string quem, int codUsusario)
        {
            _accessBo.AlterarControleUsuarioPorControle(codControle, ativo, codPerfil, quem, codUsusario);
        }

        public void AlterarControleUsuarioPorFormulario(int codFormulario, bool ativo, int codPerfil, string quem, int codUsusario)
        {
            _accessBo.AlterarControleUsuarioPorFormulario(codFormulario, ativo, codPerfil, quem, codUsusario);
        }

        public void AlterarControleUsuarioPorPerfil(int codPerfil, bool ativo, string quem)
        {
            _accessBo.AlterarControleUsuarioPorPerfil(codPerfil, ativo, quem);
        }

        public int ObterPerfilUsuario(int codUsuario)
        {
            return _accessBo.ObterPerfilUsuario(codUsuario);
        }
        
    }
}
