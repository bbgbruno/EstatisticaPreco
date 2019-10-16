using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstatiscaPreco.Models
{
    public class Produto
    {
        public Produto()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Ean13 { get; set; }
        public double Preco { get; set; }
        public string Origem { get; set; }
        public int Categoria { get; set; }
        public DateTime DataCompra { get; set; }
        public string Chave { get; set; }
    }



}