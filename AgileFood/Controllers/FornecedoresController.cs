using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AgileFood.Models;

namespace AgileFood.Controllers
{
    public class FornecedoresController : Controller
    {
        private AgileFoodContext db = new AgileFoodContext();

        // GET: Fornecedores
        public ActionResult Index()
        {
            var fornecedores = db.Fornecedores.Include(f => f.Pessoa);
            return View(fornecedores.ToList());
        }

        // GET: Fornecedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedores fornecedores = db.Fornecedores.Find(id);
            if (fornecedores == null)
            {
                return HttpNotFound();
            }
            return View(fornecedores);
        }

        // GET: Fornecedores/Create
        public ActionResult Create()
        {
            ViewBag.PessoasId = new SelectList(db.Pessoas, "PessoasId", "Nomes");
            return View();
        }

        // POST: Fornecedores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FornecedoresId,PessoasId")] Fornecedores fornecedores)
        {

            if (ModelState.IsValid)
            {
                db.Fornecedores.Add(fornecedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PessoasId = new SelectList(db.Pessoas, "PessoasId", "PessoasId", fornecedores.PessoasId);
            return View(fornecedores);
        }

        // GET: Fornecedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedores fornecedores = db.Fornecedores.Find(id);
            if (fornecedores == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoasId = new SelectList(db.Pessoas, "PessoasId", "Email", fornecedores.PessoasId);
            return View(fornecedores);
        }

        // POST: Fornecedores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FornecedoresId,PessoasId")] Fornecedores fornecedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PessoasId = new SelectList(db.Pessoas, "PessoasId", "Email", fornecedores.PessoasId);
            return View(fornecedores);
        }

        // GET: Fornecedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedores fornecedores = db.Fornecedores.Find(id);
            if (fornecedores == null)
            {
                return HttpNotFound();
            }
            return View(fornecedores);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fornecedores fornecedores = db.Fornecedores.Find(id);
            db.Fornecedores.Remove(fornecedores);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    
        public List<Fornecedores> GetFornecedores(int pessoasId)
        {
            var sql = (from forn in db.Fornecedores
                       join pes in db.Pessoas on forn.FornecedoresId equals pes.PessoasId
                       where forn.FornecedoresId == pes.PessoasId
                       select new { forn }).ToList();

            var fornecedor = new List<Fornecedores>();

            foreach(var item in sql)
            {
                fornecedor.Add(item.forn);
            }
            fornecedor.Add(new Fornecedores
            {
                FornecedoresId = 0,
                //
            });

            return fornecedor = fornecedor.OrderBy(c => c.Pessoa.Email).ThenBy(c => c.FornecedoresId).ToList();

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
