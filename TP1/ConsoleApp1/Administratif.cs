using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Administratif : Personnel
    {
        public Administratif(int code, string nom, string prenom, string bureau, double salaire)
    : base(code, nom, prenom, bureau, salaire) { }

        public override void CalculerSalaire()
        {
            Salaire = base.Salaire; // Exemple de salaire fixe
        }
    }
}
