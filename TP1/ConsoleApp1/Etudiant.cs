using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Etudiant : Personne
    {
        public string Niveau { get; set; }
        public double MoyenneAnnuelle { get; set; }

        public Etudiant(int code, string nom, string prenom, string niveau, double moyenne)
            : base(code, nom, prenom)
        {
            Niveau = niveau;
            MoyenneAnnuelle = moyenne;
        }
    }
}
