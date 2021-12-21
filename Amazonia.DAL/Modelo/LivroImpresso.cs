using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.DAL.Modelo
{
    public class LivroImpresso : Livro
    {
        public int QuantidadePaginas { get; set; }

        ///Largura em Centimetros
        [Required]
        [Range(1, 100)]
        public float Largura { get; set; }

        ///Altura em Centimetros        
        [Required]
        [Range(1, 100)]
        public float Altura { get; set; }

        ///Profundide em Centimetros
        [Required]
        [Range(1, 100)]
        public float Profundidade { get; set; }

        ///Peso em gramas
        [Required]
        [Range(50, 10000)]
        public float Peso { get; set; }

        [NotMapped]
        public float Volume => Largura * Altura * Profundidade;


        public float ObterVolume()
        {
            return Largura * Altura * Profundidade;
        }

        public override string ToString()
        {
            return $"Livro Impresso: {Nome}";
        }

        [NotMapped]
        public override string TipoPorEscrito => "Impresso";
    }
}
