using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace Ex3_TP1
{
    class GestionComptes
    {
        private List<CompteBancaire> comptes;
        private const string FICHIER_COMPTES = "comptes.json";

        public GestionComptes()
        {
            comptes = ChargerComptes();
        }

        public void AjouterCompte(CompteBancaire compte)
        {
            comptes.Add(compte);
            SauvegarderComptes();
        }

        public CompteBancaire RechercherCompte(int numero)
        {
            return comptes.Find(c => c.Numero == numero);
        }

        public void SupprimerCompte(int numero)
        {
            comptes.RemoveAll(c => c.Numero == numero);
            SauvegarderComptes();
        }

        public void AfficherTousLesComptes()
        {
            foreach (var compte in comptes)
                Console.WriteLine($"{compte.Numero} - {compte.NomClient} {compte.PrenomClient} - {compte.Solde} Dhs");
        }

        private List<CompteBancaire> ChargerComptes()
        {
            if (!File.Exists(FICHIER_COMPTES)) return new List<CompteBancaire>();
            string contenu = File.ReadAllText(FICHIER_COMPTES);
            var comptes = JsonConvert.DeserializeObject<List<CompteBancaire>>(contenu) ?? new List<CompteBancaire>();

            // Vérifier si les soldes sont bien chargés
            foreach (var c in comptes)
            {
                Console.WriteLine($"Chargement du compte {c.Numero}, solde : {c.Solde} Dhs");
            }

            return comptes;
        }


        private void SauvegarderComptes()
        {
            File.WriteAllText(FICHIER_COMPTES, JsonConvert.SerializeObject(comptes, Formatting.Indented));
        }
    }
}
