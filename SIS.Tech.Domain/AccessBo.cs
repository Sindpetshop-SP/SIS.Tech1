using SIS.Tech.IDomain;
using SIS.Tech.Domain.Model;
using SIS.Tech.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain
{
    public class AccessBo : IAccessBo
    {
        private readonly IAccessRepository _accessRepository;

        public AccessBo(IAccessRepository accessRepository)
        {
            _accessRepository = accessRepository;
        }

        public List<Perfil> ListarPerfis()
        {
            return _accessRepository.ListarPerfis();
        }

        public Roles ListarRoles(int codPerfil)
        {
            return _accessRepository.ListarRoles(codPerfil);
        }

        public List<ControleAcessoSGE> ListarControleAcessos(int codPerfil, int codUsuario, string nomeUsuario, string nmeLoginUsuario)
        {
            return _accessRepository.ListarControleAcessos(codPerfil, codUsuario, nomeUsuario, nmeLoginUsuario);
        }

        public List<Permissions> ListarPermissoesAcessos(string nomeUsuario, string nmeLoginUsuario, string codPerfil)
        {
            return _accessRepository.ListarPermissoesAcessos(nomeUsuario, nmeLoginUsuario, codPerfil);
        }

        public void AlterarControleUsuarioPorControle(int codControle, bool ativo, int codPerfil, string quem, int codUsusario)
        {
            _accessRepository.AlterarControleUsuarioPorControle(codControle, ativo, codPerfil, quem, codUsusario);
        }

        public void AlterarControleUsuarioPorFormulario(int codFormulario, bool ativo, int codPerfil, string quem, int codUsusario)
        {
            _accessRepository.AlterarControleUsuarioPorFormulario(codFormulario, ativo, codPerfil, quem, codUsusario);
        }

        public void AlterarControleUsuarioPorPerfil(int codPerfil, bool ativo, string quem)
        {
            _accessRepository.AlterarControleUsuarioPorPerfil(codPerfil, ativo, quem);
        }

        public int ObterPerfilUsuario(int codUsuario)
        {
            return _accessRepository.ObterPerfilUsuario(codUsuario);
        }
    }

}
