using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstatiscaPreco.Models
{
    public class Arquivo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public string Origem { get; set; }
    }
}