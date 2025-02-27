using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_TP1
{
     class Repertoire
    {
        private string nom;
        private int nbrFichiers;
        private Fichier[] fichiers;

        public string Nom
        {
            get => nom;
            private set => nom = value;
        }

        public int NbrFichiers
        {
            get => nbrFichiers;
            private set => nbrFichiers = value;
        }

        public Repertoire(string nom)
        {
            this.nom = nom;
            fichiers = new Fichier[30];
            nbrFichiers = 0;
        }

        public void Afficher()
        {
            Console.WriteLine($"Répertoire: {nom}");
            for (int i = 0; i < nbrFichiers; i++)
            {
                fichiers[i].Afficher();
            }
        }

        public int Rechercher(string nom)
        {
            for (int i = 0; i < nbrFichiers; i++)
            {
                if (fichiers[i].Nom == nom)
                    return i;
            }
            return -1;
        }

        public void Ajouter(Fichier fichier)
        {
            if (nbrFichiers < 30)
            {
                fichiers[nbrFichiers] = fichier;
                nbrFichiers++;
            }
            else
            {
                Console.WriteLine("Répertoire plein !");
            }
        }

        public void Supprimer(string nom)
        {
            int index = Rechercher(nom);
            if (index != -1)
            {
                for (int i = index; i < nbrFichiers - 1; i++)
                {
                    fichiers[i] = fichiers[i + 1];
                }
                fichiers[nbrFichiers - 1] = null;
                nbrFichiers--;
            }
            else
            {
                Console.WriteLine("Fichier non trouvé !");
            }
        }

        public void Renommer(string ancienNom, string nouveauNom)
        {
            int index = Rechercher(ancienNom);
            if (index != -1)
            {
                fichiers[index].Nom = nouveauNom;
            }
            else
            {
                Console.WriteLine("Fichier non trouvé !");
            }
        }

        public void ModifierTaille(string nom, float nouvelleTaille)
        {
            int index = Rechercher(nom);
            if (index != -1)
            {
                fichiers[index].Taille = nouvelleTaille;
            }
            else
            {
                Console.WriteLine("Fichier non trouvé !");
            }
        }

        public void RechercherParExtension(string extension)
        {
            var fichiersTrouves = fichiers.Take(nbrFichiers).Where(f => f.Extension == extension).ToList();

            if (fichiersTrouves.Count > 0)
            {
                Console.WriteLine($"Fichiers avec l'extension {extension} :");
                foreach (var fichier in fichiersTrouves)
                {
                    fichier.Afficher();
                }
            }
            else
            {
                Console.WriteLine($"Aucun fichier avec l'extension {extension} trouvé.");
            }
        }

        public float GetTailleEnMo()
        {
            float tailleTotaleKo = fichiers.Take(nbrFichiers).Sum(f => f.Taille);
            return tailleTotaleKo / 1024;
        }
    }
}
