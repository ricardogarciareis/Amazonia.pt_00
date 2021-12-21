using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.DAL.Modelo
{
    public abstract class Livro : Entidade
    {
        [Required]
        [Range(0, 1000)]
        public decimal Preco { protected get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(255)]
        public string Autor { get; set; }

        public Idioma Idioma { get; set; }   //Portugues, Espanhol, Ingles, Frances

        [NotMapped]
        public virtual decimal ObterPreco => Preco;

        //Poderia ter feito assim, mas preferimos, usando a observacao do colega, modificar a acessibilidade da propriedade preco
        //public virtual void InformarPreco(decimal precoSemDesconto)
        //{
        //    Preco = precoSemDesconto;
        //}


        [NotMapped]
        public virtual string TipoPorEscrito => "Não Informado";
    }
}

