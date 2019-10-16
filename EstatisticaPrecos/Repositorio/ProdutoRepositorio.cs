using Dapper;
using EstatiscaPreco.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EstatisticaPrecos.Repositorio
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>
    {


        public ProdutoRepositorio()
        {

        }


        public override void Add(Produto item)
        {

            int count = 0;
            using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    var query = "INSERT INTO Produtos(id, Nome, Codigo, Ean13, Preco, Origem, Categoria, DataCompra) VALUES(@id, @Nome, @Codigo, @Ean13, @Preco, @Origem, @Categoria,@DataCompra); SELECT CAST(SCOPE_IDENTITY() as INT); ";

                    count = dbConnection.Execute(query, item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConnection.Close();
                }
                //return count;
            }
        }

        public override IEnumerable<Produto> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public override Produto FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Produto item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> BuscarProdutos()
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(ConnectionString))
                {

                    return dbConnection.Query<Produto>(" Select * from Produtos").OrderBy(x => x.Nome);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}