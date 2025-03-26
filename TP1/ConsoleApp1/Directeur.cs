using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Directeur : Personnel
    {
        private static Directeur _instance;
        public double PrimesDeplacement { get; set; }

        private Directeur(int code, string nom, string prenom, string bureau, double salaire, double primes)
            : base(code, nom, prenom, bureau, salaire)
        {
            PrimesDeplacement = primes;
        }

        public static Directeur GetInstance(int code, string nom, string prenom, string bureau, double salaire, double primes)
        {
            if (_instance == null)
            {
                _instance = new Directeur(code, nom, prenom, bureau, salaire, primes);
            }
            else
            {
                throw new Exception("Le directeur existe déjà !");
            }
            return _instance;
        }

        public override void CalculerSalaire()
        {
            Salaire = base.Salaire + PrimesDeplacement; // Exemple de calcul
        }
    }
}
