using Ex1_TP1;

class Program
{
    static void Main()
    {
        Repertoire rep = new Repertoire("MonDossier");

        rep.Ajouter(new Fichier("document1", "txt", 500));
        rep.Ajouter(new Fichier("presentation", "pdf", 1500));
        rep.Ajouter(new Fichier("rapport", "pdf", 800));

        rep.Afficher();

        Console.WriteLine("\nRechercher un fichier 'document1':");
        int index = rep.Rechercher("document1");
        Console.WriteLine(index != -1 ? $"Trouvé à l'index {index}" : "Fichier non trouvé");

        Console.WriteLine("\nSupprimer 'document1'");
        rep.Supprimer("document1");
        rep.Afficher();

        Console.WriteLine("\nRenommer 'rapport' en 'rapport_final'");
        rep.Renommer("rapport", "rapport_final");
        rep.Afficher();

        Console.WriteLine("\nModifier la taille de 'rapport_final'");
        rep.ModifierTaille("rapport_final", 1000);
        rep.Afficher();

        Console.WriteLine("\nRecherche des fichiers PDF :");
        rep.RechercherParExtension("pdf");

        Console.WriteLine($"\nTaille totale du répertoire : {rep.GetTailleEnMo()} Mo");
    }
}