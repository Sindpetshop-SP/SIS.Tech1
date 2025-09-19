using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IDomain
{
    public interface IAccessBo
    {
        List<Perfil> ListarPerfis();

        Roles ListarRoles(int codPerfil);

        List<ControleAcessoSGE> ListarControleAcessos(int codPerfil, int codUsuario, string nomeUsuario, string nmeLoginUsuario);

        List<Permissions> ListarPermissoesAcessos(string nomeUsuario, string nmeLoginUsuario, string codPerfil);

        void AlterarControleUsuarioPorControle(int codControle, bool ativo, int codPerfil, string quem, int codUsusario);

        void AlterarControleUsuarioPorFormulario(int codFormulario, bool ativo, int codPerfil, string quem, int codUsusario);

        void AlterarControleUsuarioPorPerfil(int codPerfil, bool ativo, string quem);

        int ObterPerfilUsuario(int codUsuario);
        

    }
}
