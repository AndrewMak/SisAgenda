using ExemploAgenda.Domain.Interface.Service;
using ExemploAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ExemploAgenda.Controllers
{
   
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _service;
        public EnderecoController(IEnderecoService service)
        {
            _service = service;
        }
        public ActionResult Index(int id)
        {
            var enderecos = _service.ObterEnderecosPorPessoa(id);
            return View(enderecos);
        }
        public ActionResult Create(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection endereco)
        {
            var novoendereco = new Endereco();
            int idpessoa = Convert.ToInt32(endereco["IdPessoa.IdPessoa"].ToString());
            novoendereco.IdPessoa = _service.ObterPorPessoa(idpessoa);
            novoendereco.Numero = endereco["Numero"];
            novoendereco.Cep = endereco["Cep"];
            novoendereco.Cidade = endereco["Cidade"];
            novoendereco.Estado = endereco["Estado"];
            novoendereco.Logradouro = endereco["Logradouro"];
            
            if (ModelState.IsValid)
            {
                _service.Adicionar(novoendereco);
                return RedirectToAction("Index", "Pessoa");
            }

            return View(endereco);
        }

        // GET: Telefone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var telefone = _service.ObterPorId(Convert.ToInt32(id));
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // POST: Telefone/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _service.Atualizar(endereco);
                return RedirectToAction("Index", "Pessoa");
            }
            return View(endereco);
        }

    }
}