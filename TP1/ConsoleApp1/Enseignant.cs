using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Enseignant : Personnel
    {
        public string Grade { get; set; }
        public int VolumeHoraire { get; set; }
        public int NbHeuresSup { get; set; }
        public double PrimesDeplacement { get; set; }
        private Dictionary<string, List<Etudiant>> Groupes { get; set; }

        public Enseignant(int code, string nom, string prenom, string bureau, double salaire, string grade, int volumeHoraire, int nbHeuresSup, double primes)
            : base(code, nom, prenom, bureau, salaire)
        {
            Grade = grade;
            VolumeHoraire = volumeHoraire;
            NbHeuresSup = nbHeuresSup;
            PrimesDeplacement = primes;
            Groupes = new Dictionary<string, List<Etudiant>>();
        }

        public void AjouterGroupe(string nomGroupe)
        {
            if (!Groupes.ContainsKey(nomGroupe))
                Groupes[nomGroupe] = new List<Etudiant>();
        }

        public void AjouterEtudiant(string nomGroupe, Etudiant etudiant)
        {
            if (Groupes.ContainsKey(nomGroupe))
                Groupes[nomGroupe].Add(etudiant);
        }

        public override void CalculerSalaire()
        {
            int tarifHoraire = Grade switch
            {
                "PA" => 300,
                "PH" => 350,
                "PES" => 400,
                _ => 0
            };
            Salaire = (VolumeHoraire + NbHeuresSup )  * tarifHoraire + PrimesDeplacement ;
        }
    }
}
