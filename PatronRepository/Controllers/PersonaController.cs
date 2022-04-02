using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Data;
using PatronRepository_UnitOfWork.Models.ViewModels;
using Tools;

namespace PatronRepository_UnitOfWork.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonaController(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }
        

        public IActionResult Index()
        {
            IEnumerable<PersonaViewModel> personas = from x in _unitOfWork.Personas.GetAll()
                                                     select new PersonaViewModel
                                                     {
                                                         Nombre = x.Nombre,
                                                         Edad = x.Edad,
                                                     };

            return View("Index", personas);
        }

        [HttpGet]
        public IActionResult Add()
        {
            IEnumerable<Nacionalidad> nacionalidades = _unitOfWork.Nacionalidades.GetAll();
            ViewBag.Nacionalidades = new SelectList(nacionalidades, "NacionalidadId", "Descripcion");  

            return View();
        }

        [HttpPost]
        public IActionResult Add(FormPersonaViewModel personaViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<Nacionalidad> nacionalidades = _unitOfWork.Nacionalidades.GetAll();
                ViewBag.Nacionalidades = new SelectList(nacionalidades, "NacionalidadId", "Descripcion");

                return View("Add", personaViewModel);
            }

            Persona persona = new Persona()
            {
                Nombre = personaViewModel.Nombre!,
                Edad = personaViewModel.Edad,
            };

            // Es recomendable usar una transacción para evitar errores al insertar dos cosas a la vez!!
            if (personaViewModel.NacionalidadId == null)
            {
                var nacionalidad = new Nacionalidad();
                nacionalidad.Descripcion = personaViewModel.OtraNacionalidad!;

                Nacionalidad insert = _unitOfWork.Nacionalidades.Add(nacionalidad);
                _unitOfWork.Save();

                persona.NacionalidadId = insert.NacionalidadId;
            }
            else
            {
                persona.NacionalidadId = personaViewModel.NacionalidadId;
            }

            _unitOfWork.Personas.Add(persona);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
