using System;
using System.Collections.Generic;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Commune> listcommune = new List<Commune>();

            while(true)
            {
                string choix = Menu();

                if(choix == "1")
                {
                   Commune c = ajouterCommune();
                    listcommune.Add(c);
                }
                else if(choix == "2")
                {
                    affiche(listcommune);
                }
                else if(choix == "Q" || choix == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Je n'ai pas compris"); 
                }
            }       
        }

        public static string Menu()
        {
            Console.WriteLine("Bienvenue dans l'application de gestion de communes");
            Console.WriteLine("Que voulez-vous faire");
            Console.WriteLine("1.Créer une nouvelle communes");
            Console.WriteLine("2.Afficher l'ensemble des communes");
            Console.WriteLine("Q.Quitter");
            string choix = Console.ReadLine();
            return choix;
        }

        public static Commune ajouterCommune()
        {
            Commune c = new Commune();
            c.Nom = saisieNom("Quel est le nom de votre ville ?");
            c.CodePost = saisieEntier("Quel est de code postal ?");
            c.NbHab = saisieEntier("Combie y a-t-il d'habitants ?");

            return c;
        }

        public static int saisieEntier(string message)
        {
            int valeurconvertie;
            Console.WriteLine(message);
            string entier = Console.ReadLine();

            while(!int.TryParse(entier, out valeurconvertie))
            {
                Console.WriteLine("Veuillez saisir un entier correcte");
                entier = Console.ReadLine();
            }
            return valeurconvertie;
        }
        public static string saisieNom(string message)
        {
            Console.WriteLine(message);
            string Nom = Console.ReadLine();
            while (string.IsNullOrEmpty(Prenom))
            {
                Console.WriteLine("Veuillez saisir quelque chose");
                Nom = Console.ReadLine();
            }

            return Nom;
        }

        public static void affiche(List<Commune> listcommunes)
        {
            Console.WriteLine("Liste des communes créées:");
            foreach(Commune c in listcommunes)
            {
                string message_p1 = "Nom: " + c.Nom + " Code Postal: " + c.CodePost;
                string message_p2 = "Nombre d'habitants: " + c.NbHab;
                Console.WriteLine(message_p1);
                Console.WriteLine(message_p2);
            }
        }        
    }
}
