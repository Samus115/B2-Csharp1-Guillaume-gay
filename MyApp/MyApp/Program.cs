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
                else if(choix == "3")
                {
                    calculNbtotalHabs(listcommune);
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
            Console.WriteLine("3.Afficher le nombre total d'habitants");
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
            bool ok = false;
            int valeurconvertie;
            
            while(ok == false)
            {
                if (string.IsNullOrEmpty(Nom))
                {
                    Console.WriteLine("Saisie incorrecte: veuillez saisir quelque chose");
                    Nom = Console.ReadLine();
                }
                else if (int.TryParse(Nom, out valeurconvertie))
                {
                    Console.WriteLine("Saisie incorrecte: le nom de votre ville ne peut pas être un nombre");
                    Nom = Console.ReadLine();
                }
                else if ( Nom[0] < 65 || Nom[0] > 90)
                {
                    Console.WriteLine("Saisie incorrecte: veuillez commencer le nom de votre commune par une majuscule");
                    Nom = Console.ReadLine();
                }
                else
                {
                    ok = true;
                }
            }
            return Nom;
        }

        public static void affiche(List<Commune> listcommunes)
        {
            Console.WriteLine("Liste des communes créées:");
            foreach(Commune c in listcommunes)
            {
                string nb = string.Format("{0:#,0}", c.NbHab);
                string message_p1 = "Nom: " + c.Nom + " Code Postal: " + c.CodePost;
                string message_p2 = "Nombre d'habitants: " + nb;
                Console.WriteLine(message_p1);
                Console.WriteLine(message_p2);
            }
        }
        
        public static void calculNbtotalHabs(List<Commune> listcommunes)
        {
            int Nbtot = 0;
            foreach(Commune c in listcommunes)
            {
                Nbtot = Nbtot + c.NbHab;
            }
            string nb = string.Format("{0:0,0}", Nbtot);
            string message = "Nombre total d'habitants: " + nb;        
            Console.WriteLine(message);
        }
    }
}
