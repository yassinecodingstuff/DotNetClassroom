using Ex3_TP1;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Connexion ===");
        Console.Write("Login: ");
        string login = Console.ReadLine();
        Console.Write("Mot de passe: ");
        string motDePasse = Console.ReadLine();

        if (!Utilisateur.Authentifier(login, motDePasse, out Utilisateur utilisateur))
        {
            Console.WriteLine("Connexion échouée !");
            return;
        }

        GestionComptes gestionComptes = new GestionComptes();
        int choix;
        do
        {
            Console.Clear();
            Console.WriteLine("=== Menu Principal ===");
            Console.WriteLine("1) Ajouter un compte");
            Console.WriteLine("2) Rechercher un compte");
            Console.WriteLine("3) Supprimer un compte");
            Console.WriteLine("4) Opération sur un compte");
            Console.WriteLine("5) Afficher tous les comptes");
            Console.WriteLine("6) Quitter");
            Console.Write("Votre choix: ");
            choix = int.Parse(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    Console.Write("Numéro du compte: ");
                    int num = int.Parse(Console.ReadLine());
                    Console.Write("Nom du client: ");
                    string nom = Console.ReadLine();
                    Console.Write("Prénom du client: ");
                    string prenom = Console.ReadLine();
                    gestionComptes.AjouterCompte(new CompteBancaire(num, nom, prenom));
                    Console.WriteLine("Compte créé !");
                    break;

                case 2:
                    Console.Write("Numéro du compte: ");
                    int numRecherche = int.Parse(Console.ReadLine());
                    var compte = gestionComptes.RechercherCompte(numRecherche);
                    if (compte != null)
                        Console.WriteLine($"{compte.Numero} - {compte.NomClient} {compte.PrenomClient} - {compte.Solde} Dhs");
                    else
                        Console.WriteLine("Compte introuvable !");
                    break;

                case 3:
                    Console.Write("Numéro du compte: ");
                    int numSuppr = int.Parse(Console.ReadLine());
                    gestionComptes.SupprimerCompte(numSuppr);
                    Console.WriteLine("Compte supprimé !");
                    break;

                case 4:
                    Console.Write("Numéro du compte: ");
                    int numCompte = int.Parse(Console.ReadLine());
                    var compteOp = gestionComptes.RechercherCompte(numCompte);
                    if (compteOp != null)
                    {
                        GérerOpérationsSurCompte(compteOp);
                    }
                    else
                    {
                        Console.WriteLine($"Le compte {numCompte} n'existe pas !!!");
                    }
                    break;

                case 5:
                    gestionComptes.AfficherTousLesComptes();
                    break;
            }

            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();

        } while (choix != 6);
    }

    static void GérerOpérationsSurCompte(CompteBancaire compte)
    {
        int choixOp;
        do
        {
            Console.Clear();
            Console.WriteLine($"=== OPÉRATIONS SUR LE COMPTE {compte.Numero} ===");
            Console.WriteLine("1) Créditer");
            Console.WriteLine("2) Débiter");
            Console.WriteLine("3) Historique");
            Console.WriteLine("4) Transfert d'argent");
            Console.WriteLine("5) Revenir au menu principal");
            Console.Write("Votre choix: ");
            choixOp = int.Parse(Console.ReadLine());

            switch (choixOp)
            {
                case 1: // Créditer un compte
                    Console.Write("Entrez le montant à verser: ");
                    double montantCredit = double.Parse(Console.ReadLine());
                    compte.Crediter(montantCredit);
                    Console.WriteLine($"Compte {compte.Numero} crédité de {montantCredit} Dhs.");
                    break;

                case 2: // Débiter un compte
                    Console.Write("Entrez le montant à retirer: ");
                    double montantDebit = double.Parse(Console.ReadLine());
                    if (compte.Debiter(montantDebit))
                        Console.WriteLine($"Compte {compte.Numero} débité de {montantDebit} Dhs.");
                    else
                        Console.WriteLine("Fonds insuffisants !");
                    break;

                case 3: // Afficher l'historique des transactions
                    compte.AfficherHistorique();
                    break;

                case 4: // Transfert d'argent
                    Console.Write("Entrez le numéro du destinataire: ");
                    int numDestinataire = int.Parse(Console.ReadLine());
                    var compteDestinataire = new GestionComptes().RechercherCompte(numDestinataire);

                    if (compteDestinataire != null)
                    {
                        Console.Write("Entrez le montant à transférer: ");
                        double montantTransfert = double.Parse(Console.ReadLine());

                        if (compte.Debiter(montantTransfert))
                        {
                            compteDestinataire.Crediter(montantTransfert);
                            Console.WriteLine($"Transfert de {montantTransfert} Dhs effectué vers le compte {numDestinataire}.");
                        }
                        else
                        {
                            Console.WriteLine("Fonds insuffisants pour effectuer le transfert !");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Le compte {numDestinataire} n'existe pas.");
                    }
                    break;
            }

            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();

        } while (choixOp != 5);
    }
}