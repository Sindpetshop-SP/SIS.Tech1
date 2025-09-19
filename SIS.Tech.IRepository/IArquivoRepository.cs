using SIS.Tech.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.IRepository
{
    public interface IArquivoRepository
    {
        int InserirArquivo(Arquivo arquivo);
    }
}
