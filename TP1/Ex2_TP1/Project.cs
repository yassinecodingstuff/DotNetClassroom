using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2_Ex2
{
    class Project
    {
        public string Code { get; private set; }
        public string Sujet { get; private set; }
        public int Duree { get; private set; }
        public List<Programmer> Programmeurs { get; private set; }
        public List<ConsommationCafe> Consommations { get; private set; }

        public Project(string code, string sujet, int duree)
        {
            Code = code;
            Sujet = sujet;
            Duree = duree;
            Programmeurs = new List<Programmer>();
            Consommations = new List<ConsommationCafe>();
        }

        public void AjouterProgrammeur(Programmer p)
        {
            Programmeurs.Add(p);
        }

        public Programmer RechercherProgrammeur(int id)
        {
            return Programmeurs.FirstOrDefault(p => p.ID == id);
        }

        public void SupprimerProgrammeur(int id)
        {
            var prog = RechercherProgrammeur(id);
            if (prog != null)
            {
                Programmeurs.Remove(prog);
                Consommations.RemoveAll(c => c.Programmeur.ID == id);
            }
        }

        public void AjouterConsommation(int semaine, int idProgrammeur, int nbTasses)
        {
            var prog = RechercherProgrammeur(idProgrammeur);
            if (prog != null)
            {
                Consommations.Add(new ConsommationCafe(semaine, prog, nbTasses));
            }
        }

        public void ModifierBureau(int idProgrammeur, int nouveauBureau)
        {
            var prog = RechercherProgrammeur(idProgrammeur);
            if (prog != null)
            {
                prog.Bureau = nouveauBureau;
            }
        }

        public int GetTotalTassesParSemaine(int semaine)
        {
            return Consommations.Where(c => c.Semaine == semaine).Sum(c => c.NbTasses);
        }

        public void AfficherProgrammeurs()
        {
            foreach (var p in Programmeurs)
            {
                p.Afficher();
            }
        }

        public void AfficherTotalCafeParSemaine(int semaine)
        {
            Console.WriteLine($"Total tasses de café en semaine {semaine}: {GetTotalTassesParSemaine(semaine)}");
        }
    }
}
