using GRUDShield.DAO;
using GRUDShield.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GRUDShield.Controllers
{
    public class ViloesController : Controller
    {
        // GET: Agentes

        VilaoRepository VilaoConn = new VilaoRepository();

        public ActionResult Index()
        {
            var lista = VilaoConn.Listar("");
            return View(lista);
        }
        
        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            var agente = VilaoConn.ListarPorId(id);
            
            return View(agente);
        }

        public ActionResult Inserir(Vilao vilao)
        {
            VilaoConn.Insert(vilao);
            var lista = VilaoConn.Listar("");
            
            return View("Index",lista);
            
        }

        public ActionResult Update(Vilao vilao)
        {
            VilaoConn.Update(vilao);
            var lista = VilaoConn.Listar("");

            return View("Index", lista);
        }

        public ActionResult Listar()
        {
            var lista = VilaoConn.Listar("");

            return Content("");
        }

        public ActionResult Alterar()
        {
            return Content("");

        }

        public ActionResult Excluir(int id)
        {
            VilaoConn.Delete(id);
            var lista = VilaoConn.Listar("");
            return View("Index",lista);
        }

        public ActionResult BuscarVilao(string nome)
        {
            var busca = VilaoConn.Listar(nome);
            return View("Index", busca);

        }

    }
}