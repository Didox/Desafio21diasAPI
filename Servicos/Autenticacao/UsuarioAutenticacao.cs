using System;
using System.Collections.Generic;
using Desafio21diasAPI.Models;
using Desafio21diasAPI.Servicos.Database;

namespace Desafio21diasAPI.Servicos.Autenticacao
{
	public class UsuarioAutenticacao
	{
			public static Cliente Autenticar(string login, string senha)
			{
					var cliente = FabricaDeClientesEmMemoria.Todos().Find( c => c.Login == login && c.Senha == senha);

					if (cliente == null)
							return null;

					cliente.Token = Token.GerarToken(cliente);

					//cliente.Senha = null;

					return cliente;
			}
  }
}
