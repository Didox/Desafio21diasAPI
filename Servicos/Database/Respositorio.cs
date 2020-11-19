using System;
using System.Collections.Generic;

namespace Desafio21diasAPI.Servicos.Database
{
    public class Repositorio
    {
        public void Salvar<T>(IRepositorio repoBase)
        {
			repoBase.Salvar<T>();
        }

		public static List<T> Todos<T>(IRepositorio repoBase)
        {
			return repoBase.Todos<T>();
		}
    }
}
