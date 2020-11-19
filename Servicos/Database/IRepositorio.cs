using System;
using System.Collections.Generic;

namespace Desafio21diasAPI.Servicos.Database
{
    public interface IRepositorio
    {
        void Salvar<T>();
        void Excluir<T>();
        List<T> Todos<T>();
        T BuscaPorId<T>(int id);
    }
}
