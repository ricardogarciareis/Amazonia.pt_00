using System;
using System.Collections.Generic;
using System.Linq;
using Amazonia.DAL.Infraestrutura;
using Amazonia.DAL.Modelo;

namespace Amazonia.DAL.Repositorios
{
    public class RepositorioLivro : IRepositorio<Livro>
    {
        private readonly List<Livro> Lista;

        public RepositorioLivro()
        {
            Lista = new List<Livro>();

            var lotrImp = new LivroImpresso
            {
                Nome = "O Senhor dos Aneis",
                Autor = "J.R.R. Tolkien"
            };
            Lista.Add(lotrImp);

            var lotrAud = new AudioLivro
            {
                Nome = "O Senhor dos Aneis",
                Autor = "J.R.R. Tolkien",
                DuracaoLivroEmMinutos = 6,
                FormatoFicheiro = "MP3"
            };
            Lista.Add(lotrAud);

            var lotrEbook = new LivroDigital
            {
                Nome = "O Senhor dos Aneis",
                Autor = "J.R.R. Tolkien",
                InformacoesLicenca = "Gratuito ....",
                FormatoFicheiro = "PDF",
                TamanhoEmMB = 100
            };
            Lista.Add(lotrEbook);

            var hpImp = new LivroImpresso
            {
                Nome = "Harry Potter",
                Autor = "JK"
            };
            Lista.Add(hpImp);


            var hgImpresso = new LivroImpresso
            {
                Nome = "Hunger Games",
                Autor = "..."
            };
            Lista.Add(hgImpresso);
        }


        public void Apagar(Livro obj)
        {
            if (Lista.Remove(obj) == false)
            {
                throw new AmazoniaException("Falha ao apagar livro"); //Inicialmente uma Exceção Genérica.
            }
        }

        public Livro Atualizar(string nomeAntigo, string nomeNovo)
        {
            var temp = ObterPorNome(nomeAntigo);
            temp.Nome = nomeNovo;

            return temp;
        }

        public void Criar(Livro obj)
        {
            Lista.Add(obj);
        }

        public Livro ObterPorNome(string Nome)
        {
            Console.WriteLine("ObterPorNome");
            var resultado = Lista
                            .Where(x => x.Nome == Nome)
                            .FirstOrDefault();
            return resultado;
        }

        public List<Livro> ObterTodos()
        {
            return Lista;
        }
    }
}