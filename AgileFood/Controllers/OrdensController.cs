using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AgileFood.Models;
using AgileFood.Classes;

namespace AgileFood.Controllers
{
    public class OrdensController : Controller
    {
        private AgileFoodContext db = new AgileFoodContext();

        //Adiciona Produtos GET
        public ActionResult AddProduto()
        {
            var ordens = db.Ordens.Include(o => o.Fornecedor);
            //ViewBag.ProdutosId = new SelectList(ComboHelpers.GetProdutos());
            ViewBag.ProdutosId = new SelectList(db.Produto, "ProdutosId", "Descricao");
            return View();
        }


        //Adiciona Produtos POST
        [HttpPost]
        public ActionResult AddProduto(AddProdutoView view)
        {
            if(ModelState.IsValid)
            {
                var produto = db.Produto.Find(view.ProdutosId);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            var ordens = db.Ordens.Include(o => o.Fornecedor);
            ViewBag.ProdutosId = new SelectList(ComboHelpers.GetProdutos());
            return View();
        }





        // GET: Ordens
        public ActionResult Index()
        {
            var ordens = db.Ordens.Include(o => o.Fornecedor);
            return View(ordens.ToList());
        }

        // GET: Ordens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordens ordens = db.Ordens.Find(id);
            if (ordens == null)
            {
                return HttpNotFound();
            }
            return View(ordens);
        }

        // GET: Ordens/Create
        public ActionResult Create()
        {
            ViewBag.FornecedoresId = new SelectList(db.Fornecedores, "FornecedoresId", "FornecedoresId");
            return View();
        }

        // POST: Ordens/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdensId,FornecedoresId,Data,Anotacao")] Ordens ordens)
        {
            if (ModelState.IsValid)
            {
                db.Ordens.Add(ordens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedoresId = new SelectList(db.Fornecedores, "FornecedoresId", "FornecedoresId", ordens.FornecedoresId);
            return View(ordens);
        }

        // GET: Ordens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordens ordens = db.Ordens.Find(id);
            if (ordens == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedoresId = new SelectList(db.Fornecedores, "FornecedoresId", "FornecedoresId", ordens.FornecedoresId);
            return View(ordens);
        }

        // POST: Ordens/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrdensId,FornecedoresId,Data,Anotacao")] Ordens ordens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedoresId = new SelectList(db.Fornecedores, "FornecedoresId", "FornecedoresId", ordens.FornecedoresId);
            return View(ordens);
        }

        // GET: Ordens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordens ordens = db.Ordens.Find(id);
            if (ordens == null)
            {
                return HttpNotFound();
            }
            return View(ordens);
        }

        // POST: Ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordens ordens = db.Ordens.Find(id);
            db.Ordens.Remove(ordens);
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
