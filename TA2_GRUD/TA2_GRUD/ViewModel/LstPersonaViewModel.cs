using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TA2_GRUD.Models;

namespace TA2_GRUD.ViewModel
{
    public class LstPersonaViewModel
    {
        public List<Persona> LstPersona { get; set; }

        public LstPersonaViewModel()
        {
            TA2Entities context = new TA2Entities();
            LstPersona = context.Persona.ToList();
        }
    }


}