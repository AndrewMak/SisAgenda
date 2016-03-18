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
            var telefones = _service.ObterTelefonesPorPessoa(id);
            return View(telefones);
        }
        public ActionResult Create(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection telefone)
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

    }
}
