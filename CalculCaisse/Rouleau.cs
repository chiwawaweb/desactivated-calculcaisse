using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculCaisse
{
    class Rouleau
    {
        public string Nom { get; set; }
        public double Valeur { get; set; }
        public string Monnaie { get; set; }

        public Rouleau(string nom, string monnaie, double valeur)
        {
            Nom = nom;
            Monnaie = monnaie;
            Valeur = valeur;
        }
    }
}
