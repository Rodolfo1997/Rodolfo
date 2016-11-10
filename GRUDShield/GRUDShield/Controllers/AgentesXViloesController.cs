using GRUDShield.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GRUDShield.Controllers
{
    public class AgentesXViloesController : Controller
    {
        AgenteXVilaoRepository agenteXVilaoConn = new AgenteXVilaoRepository();
        // GET: AgentesXViloes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgentesXViloes()
        {
            var lista = agenteXVilaoConn.AgenteXVilaoJoin();
            return View(lista);
        }
    }
}