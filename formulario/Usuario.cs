﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
    }
}