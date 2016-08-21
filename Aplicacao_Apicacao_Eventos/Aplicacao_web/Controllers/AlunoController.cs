using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao_Repositorio;
using Aplicacao_Modelos;
namespace Aplicacao_web.Controllers
{
    public class AlunoController : Controller
    {

        AlunoRepository alunoRepository
          = new AlunoRepository();

        // GET: Aluno



        public ActionResult Index()
        {
            var alunos = alunoRepository.GetAll();

            return View(alunos);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            alunoRepository.Create(aluno);

            return RedirectToAction("../Aluno/Index");
        }
        public ActionResult Excluir(int id) // aqui ele busca para editar.
        {
            var aluno = alunoRepository.getAluno(id);

            return View(aluno);
        }
        [HttpPost, ActionName("Excluir")]// esse metodo é para encanar o C#, porque nao podemos tem metodos com a mesma assinatura
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            var alunos = new AlunoRepository();
            alunos.delete(id);
            return RedirectToAction("index");// aqui é para ele voltar a o index
        }
        public ActionResult Update(int id)
        {
            var aluno = alunoRepository.getAluno(id);


            return View(aluno);
        }
        [HttpPost]
        public ActionResult Update(Aluno aluno)
        {
            alunoRepository.update(aluno);

            return RedirectToAction("index");
        }


    }
}