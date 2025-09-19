using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class ConvencaoArquivo
    {
        public int CodConvencao { get; set; }

        public int CodArquivo { get; set; }

        public List<ConvencaoArquivo> lstConvencaoArquivo { get; set; }

    }
}
