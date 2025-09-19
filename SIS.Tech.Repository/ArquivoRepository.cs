using SISFramework.DataAccess.Ado;
using SIS.Tech.Domain.Model;
using SIS.Tech.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Repository
{
    public class ArquivoRepository : BaseRepository, IArquivoRepository
    {
        public int InserirArquivo(Arquivo arquivo)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Titulo", SqlDbType.VarChar, 50) {Value = arquivo.Titulo},
                new SqlParameter("@Nome", SqlDbType.VarChar, 50) {Value = arquivo.Nome},
                new SqlParameter("@ContentType", SqlDbType.VarChar, 50) {Value = arquivo.ContentType},
                new SqlParameter("@Arquivo", SqlDbType.VarChar) {Value = arquivo.ObjArquivo},
                new SqlParameter("@Ativo", SqlDbType.Bit) {Value = arquivo.Ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = arquivo.Quem },
            };

            var command = MontaCommand(parametros, "dbo.P_ARQUIVOS_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }
    }
}
