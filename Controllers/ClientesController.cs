using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio21diasAPI.Models;
using Desafio21diasAPI.Servicos.Autenticacao;
using Desafio21diasAPI.Servicos.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Desafio21diasAPI.Controllers
{
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("/clientes/login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Cliente clienteLogin)
        {
            try
            {
                var cliente = UsuarioAutenticacao.Autenticar(clienteLogin.Login, clienteLogin.Senha);

                if (cliente == null)
                    return BadRequest(new { message = "Usuário ou senha inválidos" });

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("/clientes")]
        public IEnumerable<Cliente> Get()
        {
            return FabricaDeClientesEmMemoria.Todos();
        }

        [HttpPost]
        [Route("/clientes")]
        public Cliente Criar([FromBody] Cliente cliente)
        {
            FabricaDeClientesEmMemoria.Salvar(ref cliente);
            return cliente;
        }

        [HttpGet]
        [Route("/clientes/{id}")]
        public Cliente Ver(int id)
        {
            var cliente = FabricaDeClientesEmMemoria.BuscaPorId(id);
            return cliente;
        }

        [HttpPut]
        [Route("/clientes/{id}")]
        [Authorize(Roles = "editor, administrador")]
        public void Atualizar(int id, [FromBody] Cliente cliente)
        {
            cliente.Id = id;
            FabricaDeClientesEmMemoria.Salvar(ref cliente);
        }

        [HttpDelete]
        [Authorize(Roles = "administrador")]
        [Route("/clientes/{id}")]
        public void Apagar(int id)
        {
            FabricaDeClientesEmMemoria.Excluir(id);
        }
    }
}
