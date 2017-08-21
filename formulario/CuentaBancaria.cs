using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario
{
    public class CuentaBancaria
    {
        public long Id { get; set; }
        public long Numero { get; set; }
        public string Propietario { get; set; }
        public double Saldo { get; set; }
    }
}