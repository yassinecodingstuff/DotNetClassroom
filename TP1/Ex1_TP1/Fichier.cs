using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_TP1
{
    class Fichier
    {
        private string nom;
        private string extension;
        private float taille; 

        public string Nom
        {
            get => nom;
            set => nom = value;
        }

        public string Extension
        {
            get => extension;
            set => extension = value;
        }

        public float Taille
        {
            get => taille;
            set => taille = value;
        }

        public Fichier(string nom, string extension, float taille)
        {
            this.nom = nom;
            this.extension = extension;
            this.taille = taille;
        }

        public void Afficher()
        {
            Console.WriteLine($"Fichier: {nom}.{extension}, Taille: {taille} Ko");
        }
    }
}
