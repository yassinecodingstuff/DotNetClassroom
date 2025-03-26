using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Groupe
    {
        public string Nom { get; set; }
        public List<Etudiant> Etudiants { get; set; }

        public Groupe(string nom)
        {
            Nom = nom;
            Etudiants = new List<Etudiant>();
        }
        public void AjouterEtudiant(Etudiant etudiant)
        {
            Etudiants.Add(etudiant);
        }

        public void AfficherEtudiants()
        {
            Console.WriteLine($"Groupe {Nom} :");
            foreach (var etudiant in Etudiants)
            {
                Console.WriteLine($" - {etudiant}");
            }
        }
    }
}
