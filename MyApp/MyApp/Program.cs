using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string choix = Menu();

        }

        public static string Menu()
        {
            Console.WriteLine("Bienvenue dans l'application de gestion de communes");
            Console.WriteLine("Que voulez-vous faire");
            Console.WriteLine("1.Créer une nouvelle communes");
            Console.WriteLine("2. Afficher l'ensemble des communes");
            string choix = Console.ReadLine();
            return choix;
        }
    }
}
