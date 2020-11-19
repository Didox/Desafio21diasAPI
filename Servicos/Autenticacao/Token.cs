using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json.Linq;
using System.IO;
using System;
using Microsoft.IdentityModel.Tokens;
using Desafio21diasAPI.Models;

namespace Desafio21diasAPI.Servicos.Autenticacao
{
	public class Token
	{
			public static string GerarToken(Cliente cliente)
			{
				var tokenHandler = new JwtSecurityTokenHandler();
      
				JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory,"appsettings.json")));
				var key = Encoding.ASCII.GetBytes(jAppSettings["JwtToken"].ToString());
				var tempoExpiracao = Convert.ToInt32(jAppSettings["TempoExpiracao"]);
				var tokenDescriptor = new SecurityTokenDescriptor()
				{
					Subject = new ClaimsIdentity(new Claim[]{
						new Claim(ClaimTypes.Name, cliente.Login),
						new Claim(ClaimTypes.Role, cliente.RegraAcesso),
					}),
					Expires = DateTime.UtcNow.AddHours(tempoExpiracao),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
				};
				var token = tokenHandler.CreateToken(tokenDescriptor);
				return tokenHandler.WriteToken(token);
			}
}
}
