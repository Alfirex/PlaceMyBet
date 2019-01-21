using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Partido
    {
        // Declaracion de Variables Y metodos Consultor y Modificador
        public int id { get; set; }
        public string  equipo { get; set; }
        public bool local { get; set; }
        public string marcador { get; set; }

        // Constructor Futbol
        public Partido(int id, string equipo, bool local, string marcador)
        {
            this.id = id;
            this.equipo = equipo;
            this.local = local;
            this.marcador = marcador;
        }
    }
}