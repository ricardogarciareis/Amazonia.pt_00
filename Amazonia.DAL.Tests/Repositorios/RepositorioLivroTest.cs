using Amazonia.DAL.Infraestrutura;
using Amazonia.DAL.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.DAL.Repositorios.Tests
{
    [TestClass]
    public class RepositorioLivroTest
    {
        [TestMethod]
        public void DeveCriarUmObjetoDoTipoRepositorioLivros()
        {
            //Arrange
            RepositorioLivro repositorio;

            //Act
            repositorio = new RepositorioLivro();

            //Assert
            Assert.IsNotNull(repositorio);
        }

        [TestMethod]
        public void DeveCriarUmaListaDeLivrosNoObjetoDoTipoRepositorioLivros()
        {
            //Arrange
            RepositorioLivro repositorio;
            List<Livro> livros;
            var minElementos = 1;

            //Act
            repositorio = new RepositorioLivro();
            livros = repositorio.ObterTodos();
            var quantidadeLivrosNoRepositorio = livros.Count;

            //Assert
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(livros);
            Assert.IsTrue(quantidadeLivrosNoRepositorio >= minElementos);
        }


        [Ignore] //TODO: Modificar esse teste quando a action estiver OK no GitHub
        [TestMethod]
        public void DeveCriarUmaListaDeLivrosNoObjetoDoTipoRepositorioLivrosComFalha()
        {
            //Arrange
            RepositorioLivro repositorio;
            List<Livro> livros;
            var quantidadeElementos = 4;

            //Act
            repositorio = new RepositorioLivro();
            livros = repositorio.ObterTodos();
            var quantidadeLivrosNoRepositorio = livros.Count;

            //Assert
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(livros);
            //Assert.IsTrue(quantidadeLivrosNoRepositorio == quantidadeElementos);
            Assert.AreEqual(quantidadeLivrosNoRepositorio, quantidadeElementos);
        }


        [TestMethod]
        public void DeveApagarUmLivroDaLista()
        {
            //arrange
            var repo = new RepositorioLivro();
            var livros = repo.ObterTodos();
            var livroAApagar = livros.FirstOrDefault();

            //action
            var livrosInicialmente = livros.Count;
            repo.Apagar(livroAApagar);
            var livrosDepoisDeApagar = livros.Count;

            //assert
            Assert.IsTrue(livrosInicialmente > livrosDepoisDeApagar);
        }


#if !DEBUG
        [Ignore]
#endif
        [TestMethod]
        [ExpectedException(typeof(AmazoniaException))]
        public void DeveGerarExceptionQuandoTentaApagarLivroInexistente()
        {
            //arrange
            var repo = new RepositorioLivro();
            var livros = repo.ObterTodos();
            var livroInexistente = new LivroDigital();

            //action
            var livrosInicialmente = livros.Count;
            repo.Apagar(livroInexistente);
            var livrosDepoisDeApagar = livros.Count;

            //assert
            Assert.IsTrue(livrosInicialmente > livrosDepoisDeApagar);
        }
    }
}
