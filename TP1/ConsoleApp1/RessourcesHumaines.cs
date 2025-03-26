using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RessourcesHumaines : IRessourcesHumaines
    {
        private List<Personnel> GRH;

        public RessourcesHumaines()
        {
            GRH = new List<Personnel>();
        }

        public void AjouterPersonnel(Personnel p)
        {
            GRH.Add(p);
        }

        public void AfficherEnseignants()
        {
            foreach (var personne in GRH)
            {
                if (personne is Enseignant ens)
                {
                    Console.WriteLine($"Enseignant : {ens.Nom} {ens.Prenom} - Grade: {ens.Grade}");
                }
            }
        }

        public int RechercherEns(int code)
        {
            for (int i = 0; i < GRH.Count; i++)
            {
                if (GRH[i] is Enseignant && GRH[i].Code == code)
                    return i;
            }
            return -1;
        }
    }
}
