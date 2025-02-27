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
    internal class Utilisateur
    {
        public string Login { get; set; }
        public string MotDePasse { get; set; }
        public string Role { get; set; } // "Admin" ou "Client"

        public static List<Utilisateur> ChargerUtilisateurs()
        {
            string fichier = "users.json";
            if (!File.Exists(fichier)) return new List<Utilisateur>();

            string contenu = File.ReadAllText(fichier);
            return JsonConvert.DeserializeObject<List<Utilisateur>>(contenu) ?? new List<Utilisateur>();
        }


        public static bool Authentifier(string login, string motDePasse, out Utilisateur utilisateur)
        {
            var utilisateurs = ChargerUtilisateurs();
            utilisateur = utilisateurs.Find(u => u.Login == login && u.MotDePasse == motDePasse);
            return utilisateur != null;
        }

        public static void AjouterUtilisateur(Utilisateur utilisateur)
        {
            var utilisateurs = ChargerUtilisateurs();
            utilisateurs.Add(utilisateur);
            File.WriteAllText("utilisateurs.json", JsonConvert.SerializeObject(utilisateurs, Formatting.Indented));
        }

    }
}
