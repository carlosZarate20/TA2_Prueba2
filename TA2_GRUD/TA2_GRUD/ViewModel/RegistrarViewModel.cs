using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TA2_GRUD.Models;

namespace TA2_GRUD.ViewModel
{
    public class RegistrarViewModel
    {
        public Int32? PersonaId { get; set; }
        public String Nombre { get; set;}
        public String Apellido { get; set; }
        public Int32 Edad { get; set; }
        public String DNI { get; set; }

        public RegistrarViewModel()
        {
        }
        public RegistrarViewModel(Int32? PersonaId)
        {
            this.PersonaId = PersonaId;
        }
    }
}