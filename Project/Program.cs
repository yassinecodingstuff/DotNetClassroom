
using Project;
using System;
using DB.LIB;
using System.Collections.Generic;

namespace TestEleve
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Test de la classe Eleve ===");

            // 1. Test d'insertion d'un élève
            Console.WriteLine("\n1. Test d'insertion d'un élève");
            Eleve eleve1 = new Eleve
            {
                Code = "E009",
                Nom = "abdo",
                Prenom = "elgarti",
                Niveau = "2ème année",
                code_Fil = "GI"
            };
            try
            {
                int rowsInserted = eleve1.insert();
                Console.WriteLine($"Nombre de lignes insérées : {rowsInserted}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'insertion : {ex.Message}");
            }

            // 2. Test de recherche par ID

            Console.WriteLine("\n2. Récupération de tous les élèves avec findAll");
            Console.WriteLine("\n=== Test de findAll() ===");
            Eleve eleveForFindAll = new Eleve();
            var eleves = eleveForFindAll.findAll();
            Console.WriteLine($"Nombre total d'élèves : {eleves.Count}");
            foreach (Eleve e in eleves)
            {
                Console.WriteLine($"Code: {e.Code}, Nom: {e.Nom}, Prénom: {e.Prenom}, Niveau: {e.Niveau}");
            }


        }
    }
}