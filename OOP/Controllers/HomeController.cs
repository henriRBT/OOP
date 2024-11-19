using Microsoft.AspNetCore.Mvc;
using OOP.Models;
using OOP.Repository.Interface;
using System.Diagnostics;

namespace OOP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repo;
     
        public HomeController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_repo.GetClients());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Nama, telepon, email, negara, tanggal")] Clients client)
        {
            if (ModelState.IsValid){
                _repo.TambahClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }
        [HttpGet]
        public IActionResult Update(int?id)
        {
            var client = _repo.GetClient(id.GetValueOrDefault());
            if(client == null)
            {
                return NotFound();
            }
            return View(client);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id, Nama, telepon, email, negara, tanggal")] Clients client)
        {
            if(id != client.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _repo.UpdateClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _repo.DeleteClient(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
