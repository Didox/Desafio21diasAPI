using System;
using System.Collections.Generic;
using Desafio21diasAPI.Models;

namespace Desafio21diasAPI.Servicos.Database
{
	public class FabricaDeClientesEmMemoria
	{
		public static void Gerar()
		{
			baseClientes.Add(new Cliente() { Id= 1, Nome = "Cliente 1", Endereco = "Rua 1", Telefone = "1232123", Login = "danilo", Senha= "1234", RegraAcesso="administrador" });
			idIdentity++;
			baseClientes.Add(new Cliente() { Id= 2, Nome = "Cliente 2", Endereco = "Rua 2", Telefone = "2232123", Login = "cli2", Senha= "1234", RegraAcesso="editor"  });
			idIdentity++;
			baseClientes.Add(new Cliente() { Id= 3, Nome = "Cliente 3", Endereco = "Rua 3", Telefone = "3232123", Login = "cli3", Senha= "1234", RegraAcesso="editor"  });
			idIdentity++;
			baseClientes.Add(new Cliente() { Id= 4, Nome = "Cliente 4", Endereco = "Rua 4", Telefone = "4232123", Login = "cli4", Senha= "1234", RegraAcesso="editor"  });
			idIdentity++;
			baseClientes.Add(new Cliente() { Id= 5, Nome = "Cliente 5", Endereco = "Rua 5", Telefone = "5232123", Login = "cli5", Senha= "1234", RegraAcesso="editor"  });
			idIdentity++;
		}

		private static int idIdentity = 1;
		private static List<Cliente> baseClientes = new List<Cliente>();

		public static List<Cliente> Todos()
		{
			return baseClientes;
		}
		public static Cliente BuscaPorId(int id)
		{
			return baseClientes.Find( c => c.Id == id );
		}

		public static void Salvar(ref Cliente cliente)
		{
			if(cliente.Id == 0)
			{
				cliente.Id = idIdentity;
				baseClientes.Add(cliente);
				idIdentity++;
				return;
			}

			foreach(var clienteBase in baseClientes)
			{
				if(clienteBase.Id == cliente.Id)
				{
					clienteBase.Nome = cliente.Nome;
					clienteBase.Telefone = cliente.Telefone;
					clienteBase.Endereco = cliente.Endereco;
				}
			}
		}

		public static void Excluir(int id)
		{
			baseClientes.RemoveAll(c => c.Id == id);
		}
	}
}
