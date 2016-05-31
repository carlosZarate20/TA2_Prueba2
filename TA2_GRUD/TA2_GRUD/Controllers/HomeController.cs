using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TA2_GRUD.Models;
using TA2_GRUD.ViewModel;

namespace TA2_GRUD.Controllers
{
    public class HomeController : Controller
    {
        public List<Persona> ListPersona { get; set; }
        public ActionResult Index()
        {
            return View("Registrar");
        }

        public ActionResult LstPersona()
        {
            LstPersonaViewModel objViewModel = new LstPersonaViewModel();
            return View(objViewModel);
        }

        
        public ActionResult Registrar(Int32? PersonaId)
        {
            RegistrarViewModel objViewModel = new RegistrarViewModel(PersonaId);

            return View(objViewModel);
        }
        [HttpPost]
        public ActionResult Registrar(RegistrarViewModel objViewModel)
        {
            try
            {
                if (objViewModel.DNI == null || objViewModel.Nombre == null || objViewModel.Apellido == null)
                {
                    TempData["Mensaje"] = "Ingresar Campos Faltantes";
                    return View(objViewModel);
                }

                if (objViewModel.Nombre.Length < 3 || objViewModel.Nombre.Length > 25 ||
                    objViewModel.Apellido.Length < 3 || objViewModel.Apellido.Length > 25
                    || objViewModel.DNI.Length != 8)
                {
                    TempData["Mensaje"] = "Datos Incorrectos";
                    return View(objViewModel);
                }

                TA2Entities context = new TA2Entities();
                Persona objPersona = null;

                if (objViewModel.PersonaId.HasValue)
                    objPersona = context.Persona.FirstOrDefault(X => X.PersonaId == objViewModel.PersonaId.Value);
                else
                {
                    objPersona = new Persona();
                    context.Persona.Add(objPersona);
                }
                objPersona.Nombre = objViewModel.Nombre;
                objPersona.Apellido = objViewModel.Apellido;
                objPersona.DNI = objViewModel.DNI;
                context.SaveChanges();
                TempData["MensajeRespuesta"] = "Se Registro satisfactoriamente el cliente";
                return RedirectToAction("LstPersona");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "No se pudo registrar");

            }
            return View(objViewModel);
        }

        [HttpPost]
        public Persona BuscarPersonaDNI(int DNI)
        {
            TA2Entities context = new TA2Entities();
            ListPersona = context.Persona.ToList();
            Persona objPersona = new Persona();

            foreach (var Persona in ListPersona)
            {
                if (Persona.DNI == DNI.ToString())
                    objPersona = Persona;
            }
            return objPersona;
        }

        public Boolean ExisteDNI(int DNI)
        {
            TA2Entities context = new TA2Entities();
            ListPersona = context.Persona.ToList();

            foreach (var Persona in ListPersona)
            {
                if (Persona.DNI == DNI.ToString())
                    return true;
            }
            return false;
        }

        public String DevolverNombreDNI(int DNI)
        {
            TA2Entities context = new TA2Entities();
            ListPersona = context.Persona.ToList();
            // Persona objPersona = context.Persona.FirstOrDefault(X => X.DNI == DNI);
            Persona objPersona = new Persona();

            foreach (var Persona in ListPersona)
            {
                if (Persona.DNI == DNI.ToString())
                    objPersona = Persona;
            }
            return objPersona.Apellido;
        }

        public int DevolverEdadDNI(int DNI)
        {
            TA2Entities context = new TA2Entities();
            ListPersona = context.Persona.ToList();
            Persona objPersona = new Persona();
            //Persona objPersona = context.Persona.FirstOrDefault(X => X.DNI == DNI);

            foreach (var Persona in ListPersona)
            {
                if (Persona.DNI == DNI.ToString())
                    objPersona = Persona;
            }
            return Convert.ToInt32(objPersona.Edad);
        }

        public int Suma(int a, int b)
        {
            return a + b;

        }
        public int Resta(int a, int b)
        {
            return a - b;

        }

        public Boolean validarMax(int maximo)
        {
            Boolean max = false;

            for(int i=0; i< maximo; i++)
            {
                if(i == 3)
                {
                    max = true;
                    break;
                }
            }
            return max;
        }
    }
}