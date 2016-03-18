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
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = _service.ObterPorId(Convert.ToInt32(id));
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

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

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = _service.ObterPorId(Convert.ToInt32(id));

            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _service.Atualizar(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = _service.ObterPorId(Convert.ToInt32(id));
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Desativar(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }


    }
}
