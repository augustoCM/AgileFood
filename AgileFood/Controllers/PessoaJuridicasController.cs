using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AgileFood.Models;

namespace AgileFood.Controllers
{
    public class PessoaJuridicasController : Controller
    {
        private AgileFoodContext db = new AgileFoodContext();

        
        public ActionResult Index()
        {
            return View(db.PessoaJuridicas.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PessoaJuridicas pessoaJuridicas = db.PessoaJuridicas.Find(id);
            if (pessoaJuridicas == null)
            {
                return HttpNotFound();
            }
            return View(pessoaJuridicas);
        }

        
        public ActionResult Create()
        {
            ViewBag.PessoaTiposId = new SelectList(db.PessoaTipos, "PessoaTiposId", "Descricao");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoasId,Ativo,Email,Telefone,Endereco,PessoaTiposId,NomeFantasia,RazaoSocial,CNPJ,InscricaoEstadual")] PessoaJuridicas pessoaJuridicas)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoaJuridicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PessoaTiposId = new SelectList(db.PessoaTipos, "PessoaTiposId", "Descricao", pessoaJuridicas.PessoaTiposId);
            return View(pessoaJuridicas);
        }

        // GET: PessoaJuridicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaJuridicas pessoaJuridicas = db.PessoaJuridicas.Find(id);
            if (pessoaJuridicas == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaTiposId = new SelectList(db.PessoaTipos, "PessoaTiposId", "Descricao", pessoaJuridicas.PessoaTiposId);
            return View(pessoaJuridicas);
        }

        // POST: PessoaJuridicas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoasId,Ativo,Email,Telefone,Endereco,PessoaTiposId,PessoaJuridicasId,NomeFantasia,RazaoSocial,CNPJ,InscricaoEstadual")] PessoaJuridicas pessoaJuridicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoaJuridicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaTiposId = new SelectList(db.PessoaTipos, "PessoaTiposId", "Descricao", pessoaJuridicas.PessoaTiposId);
            return View(pessoaJuridicas);
        }

        // GET: PessoaJuridicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaJuridicas pessoaJuridicas = db.PessoaJuridicas.Find(id);
            if (pessoaJuridicas == null)
            {
                return HttpNotFound();
            }
            return View(pessoaJuridicas);
        }

        // POST: PessoaJuridicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PessoaJuridicas pessoaJuridicas = db.PessoaJuridicas.Find(id);
            db.Pessoas.Remove(pessoaJuridicas);
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
