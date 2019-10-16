using EstatisticaPrecos.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstatiscaPreco.Controllers
{
    public class ProdutoController : Controller
    {

        private ProdutoRepositorio _ProdutoRepositorio;

        public ProdutoController()
        {
            _ProdutoRepositorio = new ProdutoRepositorio();
        }
    

        // GET: Produto
        public ActionResult Index()
        {
            var produtos = _ProdutoRepositorio.BuscarProdutos();

            return View(produtos);

        }

        public ActionResult Listar()
        {
           
            return View();
        }


    }
}


