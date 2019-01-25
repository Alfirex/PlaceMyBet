using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {

        // Constructor:
        public Mercado(int id, double constante, double couta_over, double couta_under, double dinero_under, double dinero_over)
        {
            this.id = id;
            this.constante = constante;
            this.cuota_over = cuota_over;
            this.cuota_under = cuota_under;
            this.dinero_under = dinero_under;
            this.dinero_over = dinero_over;
        }

        public double uProbabilidad()
        {
            double up = cuota_under / (cuota_under + cuota_over);
            Debug.WriteLine(up);
            return up;
        }

        public double oProbabilidad()
        {
            double op = cuota_over / (cuota_under + cuota_over);
            Debug.WriteLine(op);
            return op;
        }

        public double cOver()
        {
            double op = oProbabilidad();
            Debug.WriteLine(op);
            cuota_over = Math.Round(1 / op * 0.95, 2);
            Debug.WriteLine(cuota_over);
            return cuota_over;
        }
        public double cUnder()
        {
            double up = uProbabilidad();
            Debug.WriteLine(up);
            cuota_under = Math.Round(1 / up * 0.95, 2);
            Debug.WriteLine(cuota_under);
            return cuota_under;
        }

        // Métodos consultores y modificadores:
        public int id { get; set; }
        public double constante { get; set; }
        public double cuota_over { get; set; }
        public double cuota_under { get; set; }
        public double dinero_under { get; set; }
        public double dinero_over { get; set; }


    }
}