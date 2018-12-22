using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgileFood.Models;

namespace AgileFood.Controllers
{
    public class PessoaFisicasController : Controller
    {
        private AgileFoodContext db = new AgileFoodContext();
        
        public ActionResult Index()
        {
            return View(db.PessoaFisicas.ToList());            
        }

        public ActionResult Create()
        {
            //comuni~cação entre controller e view
            ViewBag.PessoaTiposId = new SelectList(db.PessoaTipos, "PessoaTiposId", "Descricao");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoaTipoDescricao, Ativo, Email, Telefone, Endereco, PessoaTiposId, Nome," +
                                                   " CPF, RG, DataNascimento")]PessoaFisicas pessoaFisicas)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.PessoaFisicas.Add(pessoaFisicas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Não é possível salvar as alterações. Tente novamente e, se o problema persistir, " +
                    "consulte o administrador do sistema.");
            }

            return View(pessoaFisicas);            
        }

        //Metodo com problema ERRO

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaFisicas pessoaFisicas = db.PessoaFisicas.Find(id);

            if (pessoaFisicas == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaTiposId = new SelectList(db.PessoaTipos, "PessoaTiposId", "Descricao", pessoaFisicas.PessoaTiposId);
            return View(pessoaFisicas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoasId,Ativo,Email,Telefone,Endereco,PessoaTiposId,PessoaFisicaId,Nome,CPF,RG,DataNascimento")] PessoaFisicas pessoaFisicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoaFisicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaTiposId = new SelectList(db.PessoaTipos, "PessoaTiposId", "Descricao", pessoaFisicas.PessoaTiposId);
            return View(pessoaFisicas);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PessoaFisicas pessoaFisicas = db.PessoaFisicas.Find(id);
                 
            if(pessoaFisicas == null)
            {
                return HttpNotFound();
            }
            return View(pessoaFisicas);
        }

        public ActionResult Delete(int? id, bool? erroAoSalvar = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (erroAoSalvar.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Não é possível deletar as alterações. Tente novamente e, se o problema persistir, " +
                    "consulte o administrador do sistema.";
            }
            PessoaFisicas pessoaFisicas = db.PessoaFisicas.Find(id);

            if (pessoaFisicas == null)
            {
                return HttpNotFound();
            }

            return View(pessoaFisicas);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                PessoaFisicas pessoaFisicas = db.PessoaFisicas.Find(id);
                db.PessoaFisicas.Remove(pessoaFisicas);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }


    }
}