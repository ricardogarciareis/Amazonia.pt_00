using System.Collections.Generic;
using System;
using System.Linq;
using Amazonia.DAL.Infraestrutura;
using Amazonia.DAL.Modelo;

namespace Amazonia.DAL.Repositorios
{
    public class RepositorioCliente : IRepositorio<Cliente>
    {
        private List<Cliente> Lista;
        public RepositorioCliente()
        {
            Lista = new List<Cliente>();
            var joao = new Cliente();
            joao.Nome = "Joao";
            joao.DataNascimento = new DateTime(1984, 05, 29);

            var maria = new Cliente { Nome = "Maria", DataNascimento = new DateTime(1950, 01, 01) };
            var marta = new Cliente { Nome = "Marta", DataNascimento = new DateTime(2021, 01, 02) };

            Lista.Add(joao);
            Lista.Add(maria);
            Lista.Add(marta);
        }

        public void Apagar(Cliente obj)
        {
            try
            {
                if (obj == null)
                    throw new Exception("Ops");
                else
                    System.Console.WriteLine("Valor do objeto [" + obj + "]");

                System.Console.WriteLine("Cliente a apagar: " + obj);
                Lista.Remove(obj);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Ops, não conheco essa pessoa");
            }
        }




        public Cliente Atualizar(string nomeAntigo, string nomeNovo)
        {
            var temp = ObterPorNome(nomeAntigo);
            temp.Nome = nomeNovo;

            return temp;
        }

        public void Criar(Cliente obj)
        {
            Lista.Add(obj);
        }

        public Cliente ObterPorNome(string Nome)
        {
            Console.WriteLine("ObterPorNome");
            var resultado = Lista
                            .Where(x => x.Nome == Nome)
                            .OrderByDescending(x => x.Idade)
                            .FirstOrDefault();
            return resultado;
        }

        public List<Cliente> ObterTodos()
        {
            return Lista;
        }


        public List<Cliente> ObterTodosQueComecemPor(string comeco)
        {
            var resultado = Lista
                            .Where(x => x.Nome.StartsWith(comeco))
                            .ToList();
            return resultado;
        }

        public List<Cliente> ObterTodosQueTenhamPeloMenos18Anos()
        {
            System.Console.WriteLine("ObterTodosQueTenhamPeloMenos18Anos");
            var resultado = Lista
                    .Where(x => x.Idade >= 18)
                    .ToList();
            return resultado;
        }
        /*
        Select top 10 * from Cliente

        Select * from cliente where rowno < 10        
        */


        public List<Cliente> ObterTodosQueTenhamPeloMenos18AnosENomeComecePor(string comeco)
        {
            System.Console.WriteLine("ObterTodosQueTenhamPeloMenos18AnosENomeComecePor");
            var resultado = Lista
                    .Where(x => x.Idade >= 18 && x.Nome.StartsWith(comeco))
                    .ToList();
            return resultado;
        }


        public List<string> ObterNomeDeTodosQueTenhamPeloMenos18AnosENomeComecePor(string comeco)
        {
            System.Console.WriteLine("ObterNomeDeTodosQueTenhamPeloMenos18AnosENomeComecePor");
            var resultado = Lista  //Conjunto de Pesquisa
                .Where(x => x.Idade >= 18 && x.Nome.StartsWith(comeco)) //Filtro
                .Select(x => x.Nome.ToUpper()) //Saída/Projeção
                .ToList();

            return resultado;
        }

        public void GerarRelatorio(IImpressora impressora)
        {            
            impressora.Imprimir();
        }
    }
}