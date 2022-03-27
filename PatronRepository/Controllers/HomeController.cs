using Microsoft.AspNetCore.Mvc;
using Models.Data;
using PatronRepository.Models;
using Repository;
using System.Diagnostics;

namespace PatronRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Persona> _repository;

        public HomeController(IRepository<Persona> repository)
        { 
            _repository = repository;
        }

        public IActionResult Index()
        {
            IEnumerable<Persona> lista = _repository.GetAll();

            return View("Index", lista);
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