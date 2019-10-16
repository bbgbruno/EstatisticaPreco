using EstatiscaPreco.Models;
using EstatisticaPrecos.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace EstatiscaPreco.Controllers
{
    public class ArquivoController : Controller
    {
        private ProdutoRepositorio _ProdutoRepositorio;


        public ArquivoController()
        {
            _ProdutoRepositorio = new ProdutoRepositorio();
        }

        // GET: Arquivos
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);



                    XNamespace xnameSpace = @"http://www.portalfiscal.inf.br/nfe";

                    var xml = XElement.Load(_path);

                    
                    var dets = xml.Descendants(xnameSpace + "det").ToList();
                    var emit = xml.Descendants(xnameSpace + "emit").ToList();
                    var ide = xml.Descendants(xnameSpace + "ide").ToList();
                    var infNFe = xml.Descendants(xnameSpace + "infNFe").ToList();
                    var chave = infNFe[0].Element(xnameSpace + "Id").Value;
                    //System.Xml.Linq.XElement)infNFe[0].NextNode).Value

                    foreach (var item in dets)
                    {
                        var prod = item.Element(xnameSpace + "prod");

                        var produto = new Produto()
                        {
                            Preco = Convert.ToDouble(prod.Element(xnameSpace + "vUnCom").Value.Replace('.', ',')),
                            Nome = prod.Element(xnameSpace + "xProd").Value,
                            Codigo = prod.Element(xnameSpace + "cProd").Value,
                            Ean13 = prod.Element(xnameSpace + "cEAN").Value,
                            Origem = emit[0].Element(xnameSpace + "xNome").Value,
                            DataCompra = Convert.ToDateTime(ide[0].Element(xnameSpace + "dhEmi").Value)
                        };
                        _ProdutoRepositorio.Add(produto);


                    }

                }


                return RedirectToAction("Index", "Produto");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }
}