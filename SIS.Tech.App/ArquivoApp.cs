using SIS.Tech.IDomain;
using SIS.Tech.Domain.Model;
using SIS.Tech.IApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.App
{
    public class ArquivoApp : IArquivoApp
    {
        private readonly IArquivoBo _arquivoBo;

        public ArquivoApp(IArquivoBo arquivoBo)
        {
            _arquivoBo = arquivoBo;
        }

        public int InserirArquivo(Arquivo arquivo)
        {
            return _arquivoBo.InserirArquivo(arquivo);
        }
    }
}
