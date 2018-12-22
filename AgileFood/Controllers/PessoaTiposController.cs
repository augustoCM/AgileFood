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
    public class PessoaTiposController : Controller
    {
        private AgileFoodContext db = new AgileFoodContext();

        // GET: PessoaTipos
        public ActionResult Index()
        {
            return View(db.PessoaTipos.ToList());
        }

        // GET: PessoaTipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaTipos pessoaTipos = db.PessoaTipos.Find(id);
            if (pessoaTipos == null)
            {
                return HttpNotFound();
            }
            return View(pessoaTipos);
        }

        // GET: PessoaTipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaTipos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoaTiposId,Descricao")] PessoaTipos pessoaTipos)
        {
            if (ModelState.IsValid)
            {
                db.PessoaTipos.Add(pessoaTipos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoaTipos);
        }

        // GET: PessoaTipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaTipos pessoaTipos = db.PessoaTipos.Find(id);
            if (pessoaTipos == null)
            {
                return HttpNotFound();
            }
            return View(pessoaTipos);
        }

        // POST: PessoaTipos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaTiposId,Descricao")] PessoaTipos pessoaTipos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoaTipos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoaTipos);
        }

        // GET: PessoaTipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaTipos pessoaTipos = db.PessoaTipos.Find(id);
            if (pessoaTipos == null)
            {
                return HttpNotFound();
            }
            return View(pessoaTipos);
        }

        // POST: PessoaTipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PessoaTipos pessoaTipos = db.PessoaTipos.Find(id);
            db.PessoaTipos.Remove(pessoaTipos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
