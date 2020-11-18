using System;
using System.Collections.Generic;

namespace Desafio21diasAPI
{
    public interface IRepositorio
    {
        void Salvar<T>();
        void Excluir<T>();
        List<T> Todos<T>();
        T BuscaPorId<T>(int id);
    }
}
