using Amazonia.DAL;
using Amazonia.DAL.Modelo;
using Amazonia.WebApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.WebApi.Conversores
{
    public static class LivroAdapter
    {
        public static LivroDto ConverterLivroEmDto(Livro livro)
        {
            var dto = new LivroDto
            {
                Id = livro.Id, //TODO: Resolver problema da Listagem
                Autor = livro.Autor,
                Nome = livro.Nome,
                Descricao = livro.Descricao,
                Formato = livro.TipoPorEscrito,
                Idioma = ObterIdiomaLivro(livro.Idioma),
                QuantidadeEmEstoque = new Random().Next() //TODO: Resolver problema da Listagem                
            };

            return dto;
        }

        public static string ObterIdiomaLivro(Idioma idioma)
        {
            return idioma switch
            {
                Idioma.Portugues => "Português",
                Idioma.Espanhol => "Espanhol",
                Idioma.Ingles => "Inglês",
                _ => "Português",
            };
        }
    }
}
