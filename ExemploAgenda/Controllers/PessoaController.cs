﻿using System;
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
    public class PessoaController : Controller
    {
        private readonly IPessoaService _service;
        public PessoaController(IPessoaService service)
        {
            _service = service;
        }
        // GET: Pessoas
        public ActionResult Index()
        {
            return View(_service.ObterTodos());
        }

        // GET: Pessoas/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Pessoa pessoa = await db.Pessoas.Include(x => x.Telefones).Include(p => p.Enderecos).Where(x => x.IdPessoa == id).FirstOrDefaultAsync();

        //    if (pessoa == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pessoa);
        //}

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _service.Adicionar(pessoa);
            }

            return RedirectToAction("Index");
        }

        //// GET: Pessoas/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Pessoa pessoa = await db.Pessoas.Include(x => x.Telefones).Where(x => x.IdPessoa == id).FirstOrDefaultAsync();
        //    if (pessoa == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pessoa);
        //}

        //// POST: Pessoas/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "IdPessoa,Nome,SobreNome,DataNascimento,Status")] Pessoa pessoa)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(pessoa).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(pessoa);
        //}

        //// GET: Pessoas/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Pessoa pessoa = await db.Pessoas.FindAsync(id);
        //    if (pessoa == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pessoa);
        //}

        //// POST: Pessoas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Pessoa pessoa = await db.Pessoas.FindAsync(id);
        //    db.Pessoas.Remove(pessoa);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}


    }
}
