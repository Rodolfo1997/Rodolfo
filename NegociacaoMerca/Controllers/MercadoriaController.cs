using NegociacaoMerca.Entidades;
using NegociacaoMerca.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegociacaoMerca.Controllers
{
    public class MercadoriaController : Controller
    {

        private MercadoriaRepo mercadoriaRepo;

        public MercadoriaController(MercadoriaRepo mercadoriaRepo)
        {
            this.mercadoriaRepo = mercadoriaRepo;
        }

        public ActionResult Index()
        {
            var lista = mercadoriaRepo.ListarMercadorias();
            return View("Index", lista);
        }

        public ActionResult ListarMercadorias()
        {
            var lista = mercadoriaRepo.ListarMercadorias();
            return PartialView("Partial/_mercadorias", lista);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Inserir(Mercadoria mercadoria)
        {
            mercadoriaRepo.Inserir(mercadoria);
            return View("Index");
        }

        public ActionResult Editar(int id)
        {
            var mercadoria = mercadoriaRepo.SelecionarMercadoriaId(id);
            //mercadoriaRepo.Editar(mercadoria);
            return View(mercadoria);

        }

        public ActionResult SalvarEdicao(Mercadoria mercadoria)
        {
            mercadoriaRepo.Editar(mercadoria);
            return View("Index");

        }

    }
}