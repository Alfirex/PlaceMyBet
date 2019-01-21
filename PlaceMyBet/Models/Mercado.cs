using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        static class Constants
        {
            public const double cuota_1 = 1.5;
            public const double cuota_2 = 2.5;
            public const double cuota_3 = 3.5;
        }
        public int id { get; set; }
        public double cuota_over { get; set; }
        public double cuota_under { get; set; }

        public int dinero_under { get; set; }
        public int dinero_over { get; set; }

        public Mercado(int id, double couta_over, double couta_under, int dinero_under, int dinero_over)
        {
            this.id = id;
            this.cuota_over = couta_over;
            this.cuota_under = couta_under;
            this.dinero_under = dinero_under;
            this.dinero_over = dinero_over;
        }
    }
}