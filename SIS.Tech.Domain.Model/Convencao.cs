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
    public class Convencao
    {
        public int CodConvencao { get; set; }

        public TipoCCT TipoCCT { get; set; }

        public StatusCCT StatusCCT { get; set; }


        [Display(Name = "Nome Convenção")]
        //[Required(ErrorMessage = "O campo é obrigatório.")]
        //[RegularExpression("^[a-zA-Z0-9]_$", ErrorMessage = "Não pode contain caracteres especiais")]
        //[StringLength(100, ErrorMessage = "O tamanho máximo são 100 caracteres.")]
        public string NomeConvencao { get; set; }


        [Display(Name = "Vigência Inicial")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        [StringLength(4, ErrorMessage = "O tamanho máximo são 4 caracteres.")]
        public string AnoVigenciaInicial { get; set; }


        [Display(Name = "Vigência Final")]
        [Required(ErrorMessage = "O campo é obrigatório.")]
        [StringLength(4, ErrorMessage = "O tamanho máximo são 4 caracteres.")]
        public string AnoVigenciaFinal { get; set; }


        [Display(Name = "Observação")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Observacao { get; set; }

        public bool CCTAssinada { get; set; }

        public int? TotalGeral { get; set; }

        public int? TotalAssinadas { get; set; }

        public int? TotalEmNegociacao { get; set; }

        public int? TotalGeralEmNegociacao { get; set; }

        public int? TotalEmNegociacaoPacifico { get; set; }

        public int? TotalEmNegociacaoJuridico { get; set; }

        public bool Ativo { get; set; }

        [NotMapped]
        public string? Quem { get; set; }

        [NotMapped]
        public List<Convencao>? lstConvencao { get; set; }

    }
}
