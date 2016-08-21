using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao_Modelos;
using Aplicacao_Repositorio;
namespace Aplicacao_web.Controllers
{
    public class TipoeventoController : Controller
    {
        TipoRepositoriu tipoRepository = new TipoRepositoriu();

        Tipo_Evento_Repository tipoEventoRepository = new Tipo_Evento_Repository();
        // GET: TipoEvento
        public ActionResult Index()
        {
            var tipoEvento = tipoEventoRepository.GetAll();

            return View(tipoEvento);
        }

        public ActionResult Create()
        {
            ViewBag.tipo = tipoRepository.GetTipo();

            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoEvento tipoEvento)
        {
            tipoEventoRepository.Create(tipoEvento);

            return RedirectToAction("Index");
        }
        public ActionResult Excluir(int id) // aqui ele busca para editar.
        {
            
            var tipoEvento = tipoEventoRepository.getTipoEvento(id);
            return View(tipoEvento);
            
        }
        [HttpPost, ActionName("Excluir")]// esse metodo é para encanar o C#, porque nao podemos tem metodos com a mesma assinatura
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            tipoEventoRepository.delete(id);
            return RedirectToAction("index");// aqui é para ele voltar a o index
        }
      

        public ActionResult Update(int id)
        {

            ViewBag.tipo = tipoRepository.GetTipo();
            var tipoEvento = tipoEventoRepository.getTipoEvento(id);
            return View(tipoEvento);

        }
        [HttpPost]
        public ActionResult Update(TipoEvento tipoEvento)
        {
            tipoEventoRepository.update(tipoEvento);

            return RedirectToAction("Index");
        }
    }
}