using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {

        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {

            // La vista mostrara una lista de contactos
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Metodo solo devuelva la vista
           
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //Recibe el objeto para guardar en bd
            if(!ModelState.IsValid) 
                return View();

            var res = _ContactoDatos.Guardar(oContacto);

            if (res)
                return RedirectToAction("Listar");
            else
            return View();
        }


        public IActionResult Editar(int IdContacto)
        {
            var oContacto = _ContactoDatos.Obtener(IdContacto);
                return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();

            var res = _ContactoDatos.Editar(oContacto);

            if (res)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdContacto)
        {
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {

            var res = _ContactoDatos.Eliminar(oContacto.IdContacto);

            if (res)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
