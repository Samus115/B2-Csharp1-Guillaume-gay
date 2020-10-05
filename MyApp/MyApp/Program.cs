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

                }
                else if(choix == "q")
                {

                }
                else
                {
                    break;
                }
            }

        }

        public static string Menu()
        {
            Console.WriteLine("Bienvenue dans l'application de gestion de communes");
            Console.WriteLine("Que voulez-vous faire");
            Console.WriteLine("1.Créer une nouvelle communes");
            Console.WriteLine("2.Afficher l'ensemble des communes");
            Console.WriteLine("q.Quitter");
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
            return Nom;
        }
    }
}
