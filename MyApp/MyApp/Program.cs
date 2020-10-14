using System;
using System.Collections.Generic;
using System.Globalization;
using MyApp.Models;
using MyApp.Services;

namespace MyApp
{
    class Program
    {
        private static DemandeALutilisateur _DemandeALutilisateur = new DemandeALutilisateur();
        private static CommuneService _communeService = new CommuneService(_DemandeALutilisateur);
        private static DepartementServices _deptServices = new DepartementServices(_DemandeALutilisateur);
        static void Main(string[] args)
        {
            List<Commune> listcommune = new List<Commune>();
            List<Departement> listdept = new List<Departement>();

            while (true)
            {
                string choix = Menu();

                if(choix == "1")
                {
                   Commune c = _communeService.ajouterCommune();
                    listcommune.Add(c);
                }
                else if(choix == "2")
                {
                    _communeService.affiche(listcommune);
                }
                else if(choix == "3")
                {
                    _communeService.calculNbtotalHabs(listcommune);
                }
                else if(choix == "4")
                {
                    Departement d = _deptServices.ajouterDepartement();
                    listdept.Add(d);
                }
                else if(choix == "5")
                {
                    _deptServices.afficheDept(listdept);
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
            Console.WriteLine("4.Ajouter un Departement");
            Console.WriteLine("5.Afficher les departements");
            Console.WriteLine("Q.Quitter");
            string choix = Console.ReadLine();
            return choix;
        }
    }
}
