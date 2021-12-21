

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.DAL.Modelo
{
    public class LivroDigital : Livro
    {
        public int TamanhoEmMB { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(5)]
        public string FormatoFicheiro { get; set; }  //PDF, DOC, EPUB ....
        public string InformacoesLicenca { get; set; }

        //public override decimal ObterPreco()
        //{
        //    return base.ObterPreco() * 0.9M;
        //}

        public override string ToString()
        {
            return $"Livro Digital: " + base.ToString() + $"Informacoes Licenca: {InformacoesLicenca}";
        }

        [NotMapped]
        public override string TipoPorEscrito => "Digital";

        /*
         if(entre 30 e 60 dias valor desconto = 10)
         */
    }
}