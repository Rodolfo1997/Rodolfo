using GRUDShield.DAO;
using GRUDShield.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GRUDShield.Controllers
{
    public class AgentesController : Controller
    {
        // GET: Agentes

        AgenteRepository agenteConn = new AgenteRepository();

        public ActionResult Index()
        {
            var lista = agenteConn.Listar("");
            return View(lista);
        }
        
        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            var agente = agenteConn.ListarPorId(id);
            
            return View(agente);
        }

        public ActionResult Inserir(Agente agente)
        {
            agenteConn.Insert(agente);
            var lista = agenteConn.Listar("");
            
            return View("Index",lista);
            
        }

        public ActionResult Update(Agente agente)
        {
            agenteConn.Update(agente);
            var lista = agenteConn.Listar("");

            return View("Index", lista);
        }

        public ActionResult Listar()
        {
            var lista = agenteConn.Listar("");

            return Content("");
        }

        public ActionResult Alterar()
        {
            return Content("");

        }
        public ActionResult Excluir(int id)
        {
            agenteConn.Delete(id);
            var lista = agenteConn.Listar("");
            return View("Index",lista);
        }

        public ActionResult BuscarAgente(string nome)
        {
            var busca = agenteConn.Listar(nome);
            return View("Index", busca);

        }

    }
}