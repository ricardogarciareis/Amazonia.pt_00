using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using Amazonia.DAL.Modelo;
using Amazonia.DAL.Repositorios;
using Amazonia.DAL.Utils;
using Microsoft.EntityFrameworkCore;

namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new HttpClient();
            //var resultado = client.GetAsync("https://localhost:44381/api/Cliente/Maria").Result;
            //var conteudo = resultado.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(conteudo);

            //return;




            //  ExemploJSON.Carregar();
            ExemploJSON.CriarArquivoNovo();



            var ctx = new AmazoniaContexto();

            //ProjecaoDadosEspecificos(ctx);


            //PlaygroundLinq(ctx);
            return;  //GuardCondition






            //CREATE
            //AdicionarClienteExemplo(ctx);
            AdicionarLivrosExemplo(ctx);
            //ImprimirValorBaseadoEmConfiguracao();

            //READ
            var livroEscolhido = ctx.Livros.FirstOrDefault(x => x.Nome.StartsWith("Harry"));
            Console.WriteLine(livroEscolhido);


            var primeiroAudioLivroEncontrato = ctx.AudioLivros.FirstOrDefault(x => x.DuracaoLivroEmMinutos >= 10);
            /*
             Select top 1 * from livros where duracaoEmMinutos >= 10;
             */

            Console.WriteLine(primeiroAudioLivroEncontrato);


            //UPDATE
            primeiroAudioLivroEncontrato.DuracaoLivroEmMinutos = 90;

     
            ctx.SaveChanges(); //Update livros set duracaoEmMinutos = 90 where Id = '12321';



            //Delete
            //var primeiroLivroImpressto = ctx.LivroImpressos.FirstOrDefault();
            //Console.WriteLine(primeiroLivroImpressto);
            //ctx.LivroImpressos.Remove(primeiroLivroImpressto);
            //ctx.SaveChanges();


            var exemploLeituraComSql = ctx.Livros.FromSqlRaw("SELECT TOP 10 * FROM LIVROS");

            foreach (var item in exemploLeituraComSql)
            {
                Console.WriteLine(item);
            }

        }

        private static void PlaygroundLinq(AmazoniaContexto ctx)
        {
            //SelecaoSimples(ctx);
            //SelecaoComPaginacao(ctx);
            //SelecaoComOrdenacao(ctx);
            //CriacaoNovosClientes(ctx);
            //ProjecaoDadosEspecificos(ctx);
            //ProjecaoComJuncao(ctx);


            var clientesMoramPorto = ctx.Clientes.Where(x => x.Morada.Localidade == "Porto").ToList();


            var clientesMoramPortoComDadosMorada = ctx.Clientes.Include("Morada").Where(x => x.Morada.Localidade == "Porto").ToList();




            var clientesQueMoramPortoSQLRaw = ctx.Clientes
                .FromSqlRaw("SELECT c.* " +
                            "FROM clientes c " +
                            "LEFT JOIN moradas m on c.moradaId = m.id " +
                            "WHERE m.Localidade = 'PORTO' ")
                .ToList();

            //BUG: Como mapear o SQL para o enttity sem um dbset??
            //        var clientesQueMoramPortoSQLRaw = ctx.Clientes
            //.FromSqlRaw("SELECT c.nome, m.endereco " +
            //            "FROM clientes c " +
            //            "LEFT JOIN moradas m on c.moradaId = m.id " +
            //            "WHERE m.Localidade = 'PORTO' ")
            //.ToList();


            throw new NotImplementedException();
        }

        private static void ProjecaoComJuncao(AmazoniaContexto ctx)
        {
            var clientesQueMoramPorto = from c in ctx.Clientes
                                        join m in ctx.Moradas
                                        on c.Morada.Id equals m.Id
                                        where m.Localidade == "Porto"
                                        select new
                                        {
                                            c.Nome,
                                            m.Endereco
                                        };


            var clientesQueMoramPortoFluentAPI = ctx.Clientes
                .Where(c => c.Morada.Localidade == "Porto")
                .Select(c => new
                {
                    NomeExemplo = c.Nome,
                    MoradaExemplo = c.Morada.Endereco
                });

            foreach (var item in clientesQueMoramPortoFluentAPI)
            {
                Console.WriteLine($"Nome cliente: {item.NomeExemplo}");

                var moradaLocal = item.MoradaExemplo;
                Console.WriteLine($"Morada cliente: {moradaLocal}");
            }





            var primeiroClientesQueMoraPortoFluentAPI = ctx.Clientes
            .Where(c => c.Morada.Localidade == "Porto")
            .Select(c => new
            {
                NomeExemplo = c.Nome,
                MoradaExemplo = c.Morada.Endereco
            })
            .FirstOrDefault();

            Console.WriteLine($"Nome cliente {primeiroClientesQueMoraPortoFluentAPI.NomeExemplo}");




            var clientesQueMoramPortoDadosEspecificosDto = ctx.Clientes
            .Where(c => c.Morada.Localidade == "Porto")
            .Select(c => new DadosEspecificosDto
            {
                NomeEspecifico = c.Nome,
                EnderecoEspecifico = c.Morada.Endereco
            });

            var nomeDaPrimeiraPessoaDoPorto = ctx.Clientes.FirstOrDefault(c => c.Morada.Localidade == "Porto").Nome;

            var nomeDasPessoasDoPorto = ctx.Clientes.Where(c => c.Morada.Localidade == "Porto").Select(x => x.Nome);
        }

        class DadosEspecificosDto
        {
            public string NomeEspecifico { get; set; }
            public string EnderecoEspecifico { get; set; }
        }

        private static void ProjecaoDadosEspecificos(AmazoniaContexto ctx)
        {

            //AGRUPAMENTO
            //count
            var contagemGeral = ctx.Livros.Count();
            var contagemAgrupadoPorNome = ctx.Livros
                                                .AsEnumerable()
                                                .GroupBy(x => x.Nome)                                                
                                                .Select(ex => 
                                                    new {    
                                                        NomeLivro = ex.FirstOrDefault().Nome,
                                                        Contagem = ex.Count()
                                                    });
            foreach (var item in contagemAgrupadoPorNome)
            {
                Console.WriteLine($"Nome : {item.NomeLivro} - Contagem: {item.Contagem}");
            }





            var contagemAgrupadoPorNomeEAutor = ctx.Livros
                                             .GroupBy(x => new
                                             {
                                                 x.Nome,
                                                 x.Autor
                                             })
                                             .Select(ex =>
                                                 new {
                                                     NomeLivro = ex.FirstOrDefault().Nome,
                                                     NomeAutor = ex.FirstOrDefault().Autor,
                                                     Contagem = ex.Count()
                                                 });

            //sum
            var somatorioDoVolumeDosLivros = ctx.LivroImpressos
                                         .GroupBy(x => x.Nome)
                                         .Select(ex =>
                                             new {
                                                 NomeLivro = ex.FirstOrDefault().Nome,
                                                 Somatorio = ex.Sum(x => x.ObterVolume())
                                             });

            //avg //max //Min
            var mediaDoVolumeDosLivros = ctx.LivroImpressos
                                         .GroupBy(x => x.Nome)
                                         .Select(ex =>
                                             new {
                                                 NomeLivro = ex.FirstOrDefault().Nome,
                                                 Somatorio = ex.Average(x => x.ObterVolume()),
                                                 LivroMaiorVolume = ex.Max(x => x.ObterVolume()),
                                                 LivroMaisLeve = ex.Min(x => x.Peso)
                                             });




            //
            /*
             Select * 
             from clientes c 
             left join moradas m on m.id = c.moradaId 
             where m.Distrito = porto 
             */
            var clientesQueMoramNoPorto = ctx.Clientes.Where(c => c.Morada.Distrito == "Porto").ToList();

            /*
             Select c.nome, c.NumeroIdentificacaoFiscal
             from clientes c 
             left join moradas m on m.id = c.moradaId 
             where m.Distrito = porto 
             */
            var dadosEspecificos = clientesQueMoramNoPorto.Select(x => new
            {
                x.Nome,
                x.NumeroIdentificacaoFiscal
            });


            var dadosEspecificosModificado = clientesQueMoramNoPorto.Select(x => new
            {
                NomeEmMaiusulo = x.Nome.ToUpper(),
                NIF = x.NumeroIdentificacaoFiscal
            });
        }

        private static void CriacaoNovosClientes(AmazoniaContexto ctx)
        {
            for (int i = 1; i <= 5; i++)
            {
                var clienteNovo = new Cliente
                {
                    DataNascimento = new DateTime(1984, i, i),
                    Nome = "Joao da Silva - " + i,
                    NumeroIdentificacaoFiscal = "123456789",
                    UserName = "joao.silva" + i,
                    Password = "abc,1234",
                    Morada = new Morada
                    {
                        CodigoPostal = "123443" + (i - 1),
                        Distrito = "Porto",
                        Localidade = "Porto",
                        Endereco = "Rua das Casas no" + i,
                        Nome = "Morada Principal"
                    }
                };
                ctx.Clientes.Add(clienteNovo);
            }

            ctx.SaveChanges();
        }

        private static void SelecaoComOrdenacao(AmazoniaContexto ctx)
        {
            var listaNomes = new List<string> { "Zélia", "Joao", "Mateus", "Marcos", "Lucas", "Maria", "Pedro", "Ana" };
            var nomesOrdenados = listaNomes.OrderBy(x => x);
            var nomesOrdenadosDescendente = listaNomes.OrderByDescending(x => x);
            var livrosMaisBaratoPrimeiro = ctx.Livros.OrderBy(l => l.ObterPreco);

            //Select * from livros order by nome, preco desc
            var ordenarPorPrecoEdepoisPorNome = ctx.Livros.OrderBy(x => x.Nome).ThenByDescending(x => x.ObterPreco);
        }

        private static void SelecaoComPaginacao(AmazoniaContexto ctx)
        {
            //Selecionar primeiro livro e transformar NOME em UPPERCASE;
            var primeiroLivro = ctx.Livros.FirstOrDefault(x => x.Idioma == DAL.Idioma.Portugues);
            var primeiroLivroNome = primeiroLivro.Nome.ToUpper();

            //Select top 1 * from livros
            var primeiroLivroNOME = ctx.Livros.FirstOrDefault(x => x.Idioma == DAL.Idioma.Portugues).Nome.ToUpper();

            //Select top 10 * from livros
            var primeiros10Livros = ctx.Livros.Take(10).Where(x => x.Idioma == DAL.Idioma.Portugues);

            //Select top 10 * from livros OFFSET 10
            var primeiros10LivrosEscapando10iniciais = ctx.Livros.Skip(10).Take(10).Where(x => x.Idioma == DAL.Idioma.Portugues);
        }

        private static void SelecaoSimples(AmazoniaContexto ctx)
        {
            //ExemploSelect
            //Select * from tabela
            var listaResultado = new List<Livro>();
            foreach (var livro in ctx.Livros)
            {
                if (livro.Nome.StartsWith("H"))
                    listaResultado.Add(livro);
            }

            //LINQ - 3.5 (2005y)
            var livrosComH = from livro in ctx.Livros
                             where livro.Nome.StartsWith("h")
                             orderby livro.Nome
                             select livro;
            /* 461 
             Select * 
             from livros 
             where nome like 'h%' 
            */

            //FluentAPI - 4.5 (2008 y)
            var livros = ctx.Livros.Where(l => l.Nome.StartsWith("h")).ToList();
            foreach (var livro in livros)
            {
                Console.WriteLine(livro);
            }


            var livrosComHOuL = from livro in ctx.Livros
                                where livro.Nome.StartsWith("h") || livro.Nome.StartsWith("l")
                                orderby livro.Nome
                                select livro;

            var senhorDosAneisOuHarryPotter = ctx.Livros.Where(l => l.Nome.StartsWith("h") || l.Nome.StartsWith("l")).ToList();


            //Exemplo QuebraLinha
            var senhorDosAneisOuHarryPotter2 =
                ctx.Livros
                .Where(l => l.Nome.StartsWith("h"))
                .Where(l => l.Nome.EndsWith("r"))
                .ToList();
        }

        private static void ImprimirValorBaseadoEmConfiguracao()
        {
            var valorObtidoPeloMetodo = Exemplo.ObterValorDoConfig("chaveExemplo");


            var chaveExemplo = ConfigurationManager.AppSettings["chaveExemplo"];

            var usarRegranovaStr = ConfigurationManager.AppSettings["regraNovaAtiva"];
            var usarRegranova = Convert.ToBoolean(usarRegranovaStr);

            if (usarRegranova)
            {
                ListarClientes();
            }
            else
            {
                ListarLivros();
            }
        }

        private static void AdicionarLivrosExemplo(AmazoniaContexto ctx)
        {
            var livroDigigal = new LivroDigital
            {
                Nome = "Harry Potter Digital",
                Autor = "JK",
                Descricao = "Livro harry potter",
                FormatoFicheiro = "PDF",
                Idioma = DAL.Idioma.Portugues,
                InformacoesLicenca = "",
                Preco = 100,
                TamanhoEmMB = 10
            };

            var audioLivro = new AudioLivro
            {
                Nome = "Harry Potter Audio Livro",
                Autor = "JK",
                Descricao = "Livro harry potter",
                FormatoFicheiro = "MP3",
                Idioma = DAL.Idioma.Portugues,
                Preco = 100,
                DuracaoLivroEmMinutos = 60
            };


            var livroImpresso = new LivroImpresso
            {
                Nome = "Harry Potter Impresso",
                Autor = "JK",
                Descricao = "Livro harry potter",
                Idioma = DAL.Idioma.Portugues,
                Preco = 100,
                Altura = 10,
                Largura = 10,
                Profundidade = 10
            };

            ctx.Livros.Add(livroImpresso);
            ctx.Livros.Add(audioLivro);
            ctx.Livros.Add(livroDigigal);
            ctx.SaveChanges();
        }

        private static void AdicionarClienteExemplo(AmazoniaContexto ctx)
        {
            ctx.Clientes.Add(new Cliente
            {
                UserName = "joao.silva",
                DataNascimento = new DateTime(1984, 05, 29),
                Nome = "João da Silva",
                NumeroIdentificacaoFiscal = "123456789",
                Password = "senha"
            });
            ctx.SaveChanges();
        }

        public static void ListarLivros(){
            
            var repo = new RepositorioLivro();
            var listaLivros = repo.ObterTodos();

            foreach (var item in listaLivros)
            {
                System.Console.WriteLine(item);
            }
        }



        public static void ListarClientes(){
             Console.WriteLine("Consulta do Database");

            var repo = new RepositorioCliente();
            // var listaClientes = repo.ObterTodos()

            var listaClientes = repo.ObterTodosQueComecemPor("J");


            foreach (var item in listaClientes)
            {
               Console.WriteLine(item);
            }



            var listaClientesAdultos = repo.ObterTodosQueTenhamPeloMenos18Anos();
            foreach (var item in listaClientesAdultos)
            {
               Console.WriteLine(item);
            }


            var listaClientesAdultosComecandoComJ = repo.ObterTodosQueTenhamPeloMenos18AnosENomeComecePor("J");
            foreach (var item in listaClientesAdultosComecandoComJ)
            {
               Console.WriteLine(item);
            }



            var listagemTotal = repo.ObterTodos();
            var joao = repo.ObterPorNome("Joao");
            System.Console.WriteLine(joao);
            System.Console.WriteLine($"Database contem: {listagemTotal.Count} clientes");
            repo.Apagar(joao);
            

            var listagemAposApagar = repo.ObterTodos();
              System.Console.WriteLine($"Database contem: {listagemAposApagar.Count} clientes");


            var maria = repo.ObterPorNome("Maria");
            var clienteNovo = repo.Atualizar(maria.Nome, "Maria Joao da Silva");
            System.Console.WriteLine(clienteNovo);


            // Console.WriteLine("Criacao de Novos Clientes no Database");
            // do{
            //     var novoCliente = new Cliente();
            //     Console.WriteLine("Informe o nome");
            //     novoCliente.Nome = Console.ReadLine();
            //     repo.Criar(novoCliente);
            //     Console.WriteLine($"{novoCliente.Nome} Criado");
            // }while(Console.ReadKey().Key != ConsoleKey.Tab);

            // var listaClientesNovosEAntigos = repo.ObterTodos();
            // foreach (var item in listaClientesNovosEAntigos)
            // {
            //    Console.WriteLine(item);
            // }
        }
    }
}
