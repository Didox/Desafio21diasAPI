using System;

namespace Desafio21diasAPI
{
    public class Cliente : IModel
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string Telefone {get;set;}
        public string Endereco {get;set;}
    }
}
