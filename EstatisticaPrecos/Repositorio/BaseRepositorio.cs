using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstatisticaPrecos.Repositorio
{
    public abstract class BaseRepositorio<T>
    {
        private string _connectionString;
        protected string ConnectionString => _connectionString;

        public BaseRepositorio()
        {
            _connectionString = "Server = SET-IVIA-D22\\SQLEXPRESS; Database = EstatiscaPrecoDb; User Id = teste; Password = master123";
        }
        public abstract void Add(T item);
        public abstract void Remove(int id);
        public abstract void Update(T item);
        public abstract T FindById(Guid id);
        public abstract IEnumerable<T> BuscarTodos();

    }
}
