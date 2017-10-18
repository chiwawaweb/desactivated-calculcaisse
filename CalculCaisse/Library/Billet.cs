using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculCaisse.Library
{
    public class Billet
    {
        public double Valeur { get; set; }

        public Billet(double montant)
        {
            Valeur = montant;
        }

        public double Total(int nombre)
        {
            double result = Valeur * nombre;
            return result;
        }
    }
}
