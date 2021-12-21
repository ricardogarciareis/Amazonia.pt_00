using Amazonia.DAL.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Amazonia.DAL.Entidades.Tests
{
    [TestClass()]
    public class PeriodicoTests
    {
        [TestMethod()]
        public void DeveObterParametrosPorConfiguracaoTest()
        {
            //arrange
            var livroExemplo = new Periodico
            {
                Preco = 100,
                DataLancamento = DateTime.Today
            };

            ////act
            //var precoObtido = livroExemplo.ObterPreco();

            ////assert
            //Assert.IsTrue(precoObtido != 0);

            throw new NotImplementedException("FAlta mover para o local correto");
        }


        [TestMethod]
        public void DeveObterPrecoLivroCom20DiasTest()
        {
            //arrange
            var livroExemplo = new Periodico
            {
                Preco = 100,
                DataLancamento = DateTime.Today.AddDays(-20)
            };

            ////act
            //var precoObtido = livroExemplo.ObterPreco();

            ////assert
            //Assert.AreEqual(precoObtido, 100);

            throw new NotImplementedException("FAlta mover para o local correto");
        }


        [TestMethod]
        public void DeveObterPrecoLivroCom35DiasEMenos60Test()
        {
            //arrange
            var livroExemplo = new Periodico
            {
                Preco = 100,
                DataLancamento = DateTime.Today.AddDays(-35)
            };

            ////act
            //var precoObtido = livroExemplo.ObterPreco();

            ////assert
            //Assert.AreEqual(precoObtido, 90);

            throw new NotImplementedException("FAlta mover para o local correto");
        }


        [TestMethod]
        public void DeveObterPrecoLivroComMais60DiasTest()
        {
            //arrange
            var livroExemplo = new Periodico
            {
                Preco = 100,
                DataLancamento = DateTime.Today.AddDays(-61)
            };

            ////act
            //var precoObtido = livroExemplo.ObterPreco();

            ////assert
            //Assert.AreEqual(precoObtido, 80);

            throw new NotImplementedException("FAlta mover para o local correto");
        }
    }
}