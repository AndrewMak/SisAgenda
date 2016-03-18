using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExemploAgenda.Domain.Models;
using ExemploAgenda.Domain.Interface.Service;

namespace ExemploAgenda.Controllers
{
    public class TelefoneController : Controller
    {
        private readonly ITelefoneService _service;
        public TelefoneController(ITelefoneService service)
        {
            _service = service;
        }
        public ActionResult Index(int id)
        {
            var telefones =  _service.ObterTelefonesPorPessoa(id);
            return View(telefones);
        }
        //private ApplicationDbContext db = new ApplicationDbContext();

        //// GET: Telefone
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Telefones.ToListAsync());
        //}

        //// GET: Telefone/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Telefone telefone = await db.Telefones.FindAsync(id);
        //    if (telefone == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(telefone);
        //}

        // GET: Telefone/Create
        public ActionResult Create(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        // POST: Telefone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(FormCollection telefone)
        {
            var novotelefone = new Telefone();
            int idpessoa = Convert.ToInt32(telefone["IdPessoa.IdPessoa"].ToString());
            novotelefone.IdPessoa = _service.ObterPorPessoa(idpessoa);
            novotelefone.Numero = telefone["Numero"];
            novotelefone.Tipo = telefone["Tipo"];
            if (ModelState.IsValid)
            {
                _service.Adicionar(novotelefone);
                return RedirectToAction("Index", "Pessoa");
            }

            return View(telefone);
        }

        // GET: Telefone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = _service.ObterPorId(Convert.ToInt32(id));
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // POST: Telefone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                _service.Atualizar(telefone);
                return RedirectToAction("Index", "Pessoa");
            }
            return View(telefone);
        }

        //// GET: Telefone/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Telefone telefone = await db.Telefones.FindAsync(id);
        //    if (telefone == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(telefone);
        //}

        //// POST: Telefone/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Telefone telefone = await db.Telefones.FindAsync(id);
        //    db.Telefones.Remove(telefone);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
