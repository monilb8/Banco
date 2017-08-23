using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario
{
    public class Domicilio
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public string Localidad { get; set; }
    }
}