using MyApp.Models;
using System;
using System.Collections.Generic;
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
    }
}
