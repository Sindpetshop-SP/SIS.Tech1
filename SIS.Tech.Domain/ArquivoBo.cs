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
    public class ArquivoBo : IArquivoBo
    {

        private readonly IArquivoRepository _arquivoRepository;

        public ArquivoBo(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }

        public int InserirArquivo(Arquivo arquivo)
        {
            return _arquivoRepository.InserirArquivo(arquivo);
        }


    }
}
