using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MyApp.Services
{
    public class DepartementServices
    {
        private DemandeALutilisateur _demandeALutilisateur;
        public List<Departement> listdept = new List<Departement>();
        public DepartementServices(DemandeALutilisateur demandealutilisateur)
        {
            this._demandeALutilisateur = demandealutilisateur;
        }
        public Departement ajouterDepartement(List<Commune> listcommunes)
        {
            Departement d = new Departement();
            d.nom = _demandeALutilisateur.saisieNom("Saisissez le nom de votre departement");
            d.code = _demandeALutilisateur.saisieEntier("Saisissez le code du departement");
            d.Communes = new List<Commune>();
            foreach(Commune c in listcommunes)
            {
                if(c.CodePost == d.code)
                {
                    c.NomDept = d.nom;
                    d.Communes.Add(c);
                }
            }
            listdept.Add(d);
            return d;
        }

        public void afficheDept()
        {
            Console.WriteLine("Departements:");
            foreach (Departement d in listdept)
            {
                string message = "Nom: " + d.nom + ", code: " + d.code;
                Console.WriteLine(message);
                Console.WriteLine("Communes dans ce departement: ");
                foreach(Commune c in d.Communes)
                {
                    Console.WriteLine(c.Nom);
                }
            }
        }
        public int demandeDept()
        {
            int count = 0;
            foreach (Departement d in listdept)
            {
                Console.WriteLine(d.code);
            }
            int codeDep = _demandeALutilisateur.saisieEntier("De quel departement voulez vous calculer le nombre total d'habitants ?");
            while (true)
            {
                foreach (Departement d in listdept)
                {
                    if (codeDep == d.code)
                    {
                        count++;
                    }
                }
                if (count == 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ce departement n'est pas enregistré");
                    codeDep = _demandeALutilisateur.saisieEntier("De quel departement voulez vous calculer le nombre total d'habitants ?");
                }
            }
            return codeDep;
        }

        public void CalculNbHabDept ()
        {
            int nb = 0;

            int codeDep = demandeDept();
            foreach(Departement d in listdept)
            {
                if(codeDep == d.code)
                {
                    foreach(Commune c in d.Communes)
                    {
                        nb = nb + c.NbHab;
                    }
                }
            }
            string message = "Nomdre d'habitants dans le departement: " + nb;
            Console.WriteLine(message);
        }
    }
}
