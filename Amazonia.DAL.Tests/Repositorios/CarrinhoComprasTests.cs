using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Amazonia.DAL.Desconto;
using System.Configuration;
using Amazonia.DAL.Modelo;

namespace Amazonia.DAL.Repositorios.Tests
{
    [TestClass()]
    public class CarrinhoComprasTests
    {
        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosImpressosTest()
        {
            //arrange
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 10, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 20, Nome = "Impresso 02" },
                new LivroImpresso { Preco = 30, Nome = "Impresso 03" }
            };

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();
            var valorEsperado = 60M;

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //assert            
            Assert.AreEqual(valorEsperado, valorObtido);
        }


        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisTest()
        {
            //arrange
            var livrosFake = new List<Livro>
            {
                new LivroDigital { Preco = 10, Nome = "Digital 01" },
                new LivroDigital { Preco = 20, Nome = "Digital 02" },
                new LivroDigital { Preco = 30, Nome = "Digital 03" }
            };

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 54M;

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //assert            
            Assert.AreEqual(valorEsperado, valorObtido);
        }


        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisEImpressosTest()
        {
            //arrange
            var livrosFake = new List<Livro>
            {
                new LivroDigital { Preco = 10, Nome = "Digital 01" },
                new LivroDigital { Preco = 20, Nome = "Digital 02" },
                new LivroDigital { Preco = 30, Nome = "Digital 03" },
                new LivroImpresso { Preco = 10, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 20, Nome = "Impresso 02" },
                new LivroImpresso { Preco = 30, Nome = "Impresso 03" }
            };

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();
            var valorEsperado = 114M; //54 + 60 = 114

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //assert            
            Assert.AreEqual(valorEsperado, valorObtido);
        }


        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisEImpressosEPeriodicosTest()
        {
            //arrange
            var livrosFake = new List<Livro>
            {
                new LivroDigital { Preco = 10, Nome = "Digital 01" },
                new LivroDigital { Preco = 20, Nome = "Digital 02" },
                new LivroDigital { Preco = 30, Nome = "Digital 03" },
                new LivroImpresso { Preco = 10, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 20, Nome = "Impresso 02" },
                new LivroImpresso { Preco = 30, Nome = "Impresso 03" },
                new Periodico { Preco = 10, Nome = "Periodico 01", DataLancamento = DateTime.Today }, //10
                new Periodico { Preco = 20, Nome = "Periodico 02", DataLancamento = DateTime.Today.AddDays(-35) }, //18
                new Periodico { Preco = 30, Nome = "Periodico 03", DataLancamento = DateTime.Today.AddDays(-65) } //24
            };

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 166M; //54 + 60 = 114 + 52

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //assert            
            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        [Ignore] //Atenção ao IGNORE
        public void AplicarDescontoTest()
        {
            //arrange
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" }
            };

            var carrinho = new CarrinhoCompras();
            var valorEsperado = 80M;
            carrinho.Livros = livrosFake;

            //act
            var valorObtidoDesconto = carrinho.AplicarDesconto(null); //Nulo adicionado apenas para guardar o exemplo

            //assert
            Assert.AreEqual(valorEsperado, valorObtidoDesconto);
        }


        [TestMethod()]
        public void AplicarDescontoExemploDescontoPercentualTest()
        {
            //arrange
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" }
            };

            var carrinho = new CarrinhoCompras();

            var valorEsperado = 80M;
            carrinho.Livros = livrosFake;

            var desconto = new DescontoPercentual
            {
                PercentualDesconto = 20
            };

            //act
            var valorObtidoDesconto = carrinho.AplicarDesconto(desconto); //Nulo adicionado apenas para guardar o exemplo

            //assert
            Assert.AreEqual(valorEsperado, valorObtidoDesconto);
        }



        [TestMethod()]
        public void AplicarDescontoExemploDescontoPercentualEDescontoCombinadoParaComparacaoTest()
        {
            //arrange
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" }
            };

            var carrinho = new CarrinhoCompras
            {
                Livros = livrosFake
            };

            var descontoPercentual = new DescontoPercentual
            {
                PercentualDesconto = 20               
            };
            var valorObtidoDescontoPercentual = carrinho.AplicarDesconto(descontoPercentual);


            var descontoCombinado = new DescontoCombinado
            {
                PercentualDesconto = 20,
                LivrosCarrinho = livrosFake,
                LivrosDigitais = 1,
                LivrosImpressos = 2
            };
            var valorObtidoDescontoCombinado = carrinho.AplicarDesconto(descontoCombinado);
        }


        [TestMethod()]
        public void AplicarDescontoExemploDescontoPercentualEDescontoCombinadoParaComparacaoComBaseNoConfigTest()
        {
            //arrange
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" },
                new LivroDigital { Preco = 100, Nome = "Digital 01" },
            };

            var carrinho = new CarrinhoCompras
            {
                Livros = livrosFake
            };

            IDesconto desconto;

            //var condicao = false; //Introdução à Inversão de Dependencia / Dependency Injection / Dependency Inversion
            var condicao = ConfigurationManager.AppSettings["RegraDescontoValida"] == "UsarRegraPercentual";
            if (condicao)
            {
                desconto = new DescontoPercentual
                {
                    PercentualDesconto = 10
                };
            }
            else
            {
                desconto = new DescontoCombinado
                {
                    PercentualDesconto = 20,
                    LivrosCarrinho = livrosFake,
                    LivrosDigitais = 1,
                    LivrosImpressos = 2
                };
            }

            var valorObtidoDesconto = carrinho.AplicarDesconto(desconto);

            //Assert
            if (condicao)
            {
                Assert.AreEqual(171, valorObtidoDesconto);
            }
            else
            {
                Assert.AreEqual(152, valorObtidoDesconto);
            }
        }
    }
}