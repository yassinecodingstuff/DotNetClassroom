using Tp2_Ex2;

class Program
{
    static void Main()
    {
        // Création d'un projet
        Project projet = new Project("GINF2", "CSHARP", 10);

        // Ajout des programmeurs
        projet.AjouterProgrammeur(new Programmer(1, "EL AIDI IDRISSI", "Achraf", 205));
        projet.AjouterProgrammeur(new Programmer(2, "ARIB", "Aymane", 566));
        projet.AjouterProgrammeur(new Programmer(3, "EL HARRAK", "Mehdi", 123));

        Console.WriteLine("Liste des programmeurs :");
        projet.AfficherProgrammeurs();

        // Ajouter consommation café
        projet.AjouterConsommation(1, 1, 4);
        projet.AjouterConsommation(1, 2, 3);
        projet.AjouterConsommation(1, 3, 6);

        // Affichage total café en semaine 1
        projet.AfficherTotalCafeParSemaine(1);

        // Modifier bureau programmeur
        Console.WriteLine("\nModification du bureau de ARIB AYMANE");
        projet.ModifierBureau(2, 888);
        projet.AfficherProgrammeurs();

        // Supprimer programmeur
        Console.WriteLine("\nSuppression de EL HARRAK MEHDI");
        projet.SupprimerProgrammeur(3);
        projet.AfficherProgrammeurs();
    }
}
