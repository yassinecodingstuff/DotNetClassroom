using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2_Ex2
{
    class ConsommationCafe
    {
        public int Semaine { get; private set; }
        public Programmer Programmeur { get; private set; }
        public int NbTasses { get; private set; }

        public ConsommationCafe(int semaine, Programmer programmeur, int nbTasses)
        {
            Semaine = semaine;
            Programmeur = programmeur;
            NbTasses = nbTasses;
        }

        public void Afficher()
        {
            Console.WriteLine($"Semaine {Semaine}, Programmeur: {Programmeur.Nom} {Programmeur.Prenom}, Tasses: {NbTasses}");
        }
    }
}
