﻿using PSTodos.Mvc.Extensions;
using PSTodos.Mvc.Notifications;
using PSTodos.Mvc.RESTServices;
using PSTodos.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PSTodos.Mvc.Controllers
{
    public class PerfisController : Controller
    {
        private PerfilRESTService service = new PerfilRESTService();
        // GET: Perfis
        public async Task<ActionResult> Index()
        {
            var vm = await service.ObterPerfisAsync();
            return View(vm.Result);
        }

        public ActionResult Create()
        {
            var vm = new PerfilViewModel();

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PerfilViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("Erro", "Falha ao cadastrar Perfil", ToastType.Error);
                return View("Create", vm);
            }

            var result = await service.CadastrarPerfilAsync(vm);

            if (result.Success)
            {
                this.AddToastMessage("Sucesso", "Perfil cadastrado com sucesso", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("Erro", "Falha ao cadastrar Perfil", ToastType.Error);
                return View("Create", vm);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var vm = await service.ObterPerfil(id);

            return View("Edit", vm.Result);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(int id, PerfilViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("Erro", "Falha ao alterar Perfil", ToastType.Error);
                return View("Edit", vm);
            }

            var result = await service.EditarPerfilAsync(id, vm);

            if (result.Success)
            {
                this.AddToastMessage("Sucesso", "Perfil alterado com sucesso", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("Erro", "Falha ao Alterar Perfil", ToastType.Error);
                return View("Edit", vm);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await service.RemoverPerfilAsync(id);

            this.AddToastMessage("Sucesso", "Perfil removido com sucesso", ToastType.Success);
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult ListarPerfis()
        {
            var vm =  Task.Run(service.ObterPerfisAsync).Result;
            
            return PartialView("_ListarPerfisPartial", vm.Result);
        }
    }
}