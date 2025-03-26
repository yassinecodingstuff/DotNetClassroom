using ConsoleApp1;

class Program
{
    static void Main()
    {
        RessourcesHumaines rh = new RessourcesHumaines();

        // Création d'un enseignant
        Enseignant ens1 = new Enseignant(1, "Ali", "Bouzid", "Bureau 101", 10000,"PA", 20, 10, 3000);
        ens1.CalculerSalaire();
        rh.AjouterPersonnel(ens1);

        // Création d'un étudiant
        Etudiant etd1 = new Etudiant(101, "Karim", "Lahcen", "L2", 14.5);
        Etudiant etd2 = new Etudiant(102, "Sara", "Fadil", "L2", 15.0);

        // Création d'un groupe et affectation d'étudiants
        ens1.AjouterGroupe("Groupe A");
        ens1.AjouterEtudiant("Groupe A", etd1);
        ens1.AjouterEtudiant("Groupe A", etd2);

        // Création du directeur (Singleton)
        try
        {
            Directeur dir = Directeur.GetInstance(2, "Omar", "El Idrissi", "Bureau 001",10000, 5000);
            dir.CalculerSalaire();
            rh.AjouterPersonnel(dir);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        
        rh.AfficherEnseignants();
    }
}

