using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     public abstract class Personnel : Personne
    {
        public string Bureau { get; set; }
        public double Salaire { get;  set; }
       

        public Personnel(int code, string nom, string prenom, string bureau, double salaire)
            : base(code, nom, prenom)
        {
            Bureau = bureau;
            Salaire = salaire;
            
        }

        public abstract void CalculerSalaire();
    }
}
