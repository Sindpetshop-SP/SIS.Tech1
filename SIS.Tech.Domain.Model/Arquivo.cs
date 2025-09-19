using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SIS.Tech.Domain.Model
{
    [Serializable]
    public class Arquivo
    {
        public int CodArquivo { get; set; }

        public string Titulo { get; set; }

        public string Nome { get; set; }

        public string ContentType { get; set; }

        public String ObjArquivo { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Arquivo")]        
        public IFormFile ArquivoFile { get; set; }

        public Boolean Ativo { get; set; }

        public string Quem { get; set; }

        public List<Arquivo> lstArquivos { get; set; }
    }
}
