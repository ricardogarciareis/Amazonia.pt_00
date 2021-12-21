using Amazonia.DAL.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Amazonia.DAL.Entidades.Tests
{
    [TestClass]    
    public class ClienteTests
    {
        [TestMethod]
        public void NifEstaValidoTest()
        {
            //Arrange
            var cliente = new Cliente
            {
                NumeroIdentificacaoFiscal = "269234950"
            };

            ////Act
            //var nifValido = cliente.NifEstaValido();

            ////Assert
            //Assert.IsTrue(nifValido);

            throw new NotImplementedException("FAlta mover para o local correto");
        }

        [TestMethod]
        public void Nif2EstaValidoTest()
        {
            //Arrange
            var cliente = new Cliente
            {
                NumeroIdentificacaoFiscal = "260697915"
            };

            ////Act
            //var nifValido = cliente.NifEstaValido();

            ////Assert
            //Assert.IsTrue(nifValido);

            throw new NotImplementedException("FAlta mover para o local correto");
        }


        [TestMethod]
        public void NifEstaInValidoTest()
        {
            //Arrange
            var cliente = new Cliente
            {
                NumeroIdentificacaoFiscal = "269234951"
            };

            ////Act
            //var nifValido = cliente.NifEstaValido();

            ////Assert
            //Assert.IsFalse(nifValido);

            throw new NotImplementedException("FAlta mover para o local correto");
        }


        [TestMethod]
        public void DeveInvalidarNifMaiorDoQue9Digitos()
        {
            //Arrange
            var cliente = new Cliente
            {
                NumeroIdentificacaoFiscal = "2692349500"
            };

            ////Act
            //var nifInvalido = !cliente.NifEstaValido();

            ////Assert
            //Assert.IsTrue(nifInvalido);

            throw new NotImplementedException("FAlta mover para o local correto");
        }


        [TestMethod]
        public void DeveInvalidarNifMenorDoQue9Digitos()
        {
            //Arrange
            var cliente = new Cliente
            {
                NumeroIdentificacaoFiscal = "26923495"
            };

            ////Act
            //var nifInvalido = !cliente.NifEstaValido();

            ////Assert
            //Assert.IsTrue(nifInvalido);


            throw new NotImplementedException("FAlta mover para o local correto");
        }


        [TestMethod]
        public void DeveInvalidarNifNumerosIguais()
        {
            //Arrange
            var cliente = new Cliente
            {
                NumeroIdentificacaoFiscal = "111111111"
            };

            ////Act
            //var nifInvalido = !cliente.NifEstaValido();

            ////Assert
            //Assert.IsTrue(nifInvalido);

            throw new NotImplementedException("FAlta mover para o local correto");
        }
    }
}