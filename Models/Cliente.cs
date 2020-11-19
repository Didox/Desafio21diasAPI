using System;

namespace Desafio21diasAPI.Models
{
    public class Cliente : IModel
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string Telefone {get;set;}
        public string Endereco {get;set;}
        public string Login {get;set;}
        public string Senha {get;set;}
        public string Token {get;set;}
        public string RegraAcesso {get;set;}
    }
}
