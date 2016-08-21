using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao_Modelos;
using Aplicacao_Repositorio;
namespace Aplicacao_web.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        EventoRepositori eventoRepository = new EventoRepositori();
        Tipo_Evento_Repository tipoEventoRepository = new Tipo_Evento_Repository();
        AlunoRepository alunoRepository = new AlunoRepository();
        // GET: Evento
        public ActionResult Index(int id)
        {
            decimal horas = eventoRepository.GetHoras(id);

            ViewBag.minutos = (int)(horas % 1) * 100;
            ViewBag.horas = (int)horas;

            ViewBag.aluno = alunoRepository.getAluno(id);

            var eventos = eventoRepository.GetAll(id);

            ViewBag.cgu = id;


            return View(eventos);
        }

        public ActionResult Create(int id)
        {
            ViewBag.cgu = id;
            ViewBag.tipo = tipoEventoRepository.GetTipoEvento();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Evento evento)
        {
            eventoRepository.Create(evento);

            return RedirectToAction("../evento/index/" + evento.idAluno);
        }


        public ActionResult Update(int id)
        {

            ViewBag.id = id;
            var evento = eventoRepository.getEvento(id);
            ViewBag.tipo = tipoEventoRepository.GetTipoEvento();


            return View(evento);
        }
        [HttpPost]
        public ActionResult Update(Evento evento)
        {
            eventoRepository.update(evento);

            return RedirectToAction("../Index/" + evento.idAluno);
        }

        public ActionResult Excluir(int id) // aqui ele busca para editar.
        {
            var evento = eventoRepository.getEvento(id); // seria uma validação de erro

            return View(evento);
        }
        [HttpPost, ActionName("Excluir")]// esse metodo é para encanar o C#, porque nao podemos tem metodos com a mesma assinatura
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            var eventos = new EventoRepositori();
            eventos.delete(id);
            return RedirectToAction("../aluno/index");// aqui é para ele voltar a o index
        }

    }
}