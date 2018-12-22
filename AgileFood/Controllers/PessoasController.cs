using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AgileFood.Models;

namespace AgileFood.Controllers
{
    public class PessoasController : Controller
    {
        private AgileFoodContext db = new AgileFoodContext();

        // GET: Pessoas
        public ActionResult Index()
        {
            var pessoas = db.Pessoas.Include(p => p.PessoaTipo);
            return View(pessoas.ToList());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            ViewBag.PessoaTiposId = new SelectList(db.PessoaTipos, "PessoaTiposId", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoasId,Ativo,Nomes,Email,Telefone,Endereco,PessoaTiposId")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PessoaTiposId = new SelectList(db.PessoaTipos, "PessoaTiposId", "Descricao", pessoas.PessoaTiposId);
            return View(pessoas);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaTiposId = new SelectList(db.PessoaTipos, "PessoaTiposId", "Descricao", pessoas.PessoaTiposId);
            return View(pessoas);
        }

        // POST: Pessoas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoasId,Ativo,Email,Telefone,Endereco,PessoaTiposId")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaTiposId = new SelectList(db.PessoaTipos, "PessoaTiposId", "Descricao", pessoas.PessoaTiposId);
            return View(pessoas);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoas pessoas = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoas);
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
