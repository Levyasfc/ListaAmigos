using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ListaAmigos.Modelos
{
    public class Amigo
    {
        public string Nombre { get; set; }
        public string Alias { get; set; }
        public bool EsActivo { get; set; }

    }
}