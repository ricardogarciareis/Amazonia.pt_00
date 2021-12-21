using System;

namespace Amazonia.WebApi.Dto
{
    public class LivroDto
    {
        public Guid Id { get; set; }        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public EnumTipoLivro TipoLivro { get; set; }
        public string Formato { get; set; }

        public string Idioma { get; set; }
        
        public int QuantidadeEmEstoque { get; set; }
    }
}
