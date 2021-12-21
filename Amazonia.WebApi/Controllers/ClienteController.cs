﻿using Amazonia.DAL.Modelo;
using Amazonia.DAL.Repositorios;
using Amazonia.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Amazonia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly RepositorioCliente repo;
        public ClienteController()
        {
            repo = new RepositorioCliente();
        }


        /// <summary>
        /// Listagem de Clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Cliente> GetClientes()
        {
            return repo.ObterTodos();
        }

        /// <summary>
        /// Obtem Cliente Especifico pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("{nome}")]
        public Cliente GetClientePorNome(string nome)
        {
            return repo.ObterPorNome(nome);
        }

        [HttpPost]
        public Guid PostClienteNovo(string nome, DateTime dataNascimento, string nif)
        {
            var clienteNovo = new Cliente
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                NumeroIdentificacaoFiscal = nif
            };

            repo.Criar(clienteNovo);
            return clienteNovo.Id;
        }

        [HttpDelete]
        public bool DeleteClientePorNome(string nome)
        {
            var cli = repo.ObterPorNome(nome);
            if(cli == null)
            {
                return false;                
            }

            repo.Apagar(cli);
            return true;
        }

        [HttpPut]
        public bool UpdateClientePorNome(string nome, ClienteDto dadosNovos)
        {
            var cli = repo.ObterPorNome(nome);
            if (cli == null)
            {
                return false;
            }

            repo.Atualizar(nome, dadosNovos.Nome);
            return true;
        }
    }
}
