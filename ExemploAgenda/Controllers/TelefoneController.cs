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

namespace ExemploAgenda.Controllers
{
    public class TelefoneController : Controller
    {
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

        //// GET: Telefone/Create
        //public ActionResult Create(int Id)
        //{
        //    ViewBag.Id = Id;
        //    return View();
        //}

        //// POST: Telefone/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(FormCollection telefone)
        //{
        //    var novotelefone = new Telefone();
        //    int idpessoa = Convert.ToInt32(telefone["IdPessoa.IdPessoa"].ToString());
        //    novotelefone.IdPessoa = db.Pessoas.First(x => x.IdPessoa == idpessoa);
        //    novotelefone.Numero = telefone["Numero"];
        //    novotelefone.Tipo = telefone["Tipo"];
        //    if (ModelState.IsValid)
        //    {
        //        db.Telefones.Add(novotelefone);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(telefone);
        //}

        //// GET: Telefone/Edit/5
        //public async Task<ActionResult> Edit(int? id)
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

        //// POST: Telefone/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "IdTelefone,Tipo,Numero")] Telefone telefone)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(telefone).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(telefone);
        //}

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
