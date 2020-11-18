using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public void Atualizar(int id, [FromBody] Cliente cliente)
        {
            cliente.Id = id;
            FabricaDeClientesEmMemoria.Salvar(ref cliente);
        }

        [HttpDelete]
        [Route("/clientes/{id}")]
        public void Apagar(int id)
        {
            FabricaDeClientesEmMemoria.Excluir(id);
        }
    }
}
