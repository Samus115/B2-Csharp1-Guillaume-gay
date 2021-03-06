﻿using System;
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

            while (true)
            {
                string choix = Menu();

                if(choix == "1")
                {
                   Commune c = _communeService.ajouterCommune(_deptServices.listdept);
                }
                else if(choix == "2")
                {
                    _communeService.affiche(_communeService.listcommunes);
                }
                else if(choix == "3")
                {
                    _communeService.calculNbtotalHabs(_communeService.listcommunes);
                }
                else if(choix == "4")
                {
                    Departement d = _deptServices.ajouterDepartement(_communeService.listcommunes);
                }
                else if(choix == "5")
                {
                    _deptServices.afficheDept();
                }
                else if(choix == "6")
                {
                    _deptServices.CalculNbHabDept();
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
            Console.WriteLine("6.Calculer le nombre d'habitante d'un departement");
            Console.WriteLine("Q.Quitter");
            string choix = Console.ReadLine();
            return choix;
        }
    }
}
