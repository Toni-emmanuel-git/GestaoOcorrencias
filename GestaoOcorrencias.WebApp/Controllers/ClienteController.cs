using GestaoOcorrencias.WebApp.Models;
using GestaoOcorrencias.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoOcorrencias.WebApp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            var clientes = await clienteService.Get();
            return View(clientes);
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var cliente = await clienteService.Get(id);
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                await clienteService.Create(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var cliente = await clienteService.Get(id);
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                await clienteService.Update(id, cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await clienteService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
