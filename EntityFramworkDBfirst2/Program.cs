using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAOVente;

namespace EntityFramworkDBfirst2
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new VenteEntities())
            {

                var dbE = db.spEmploye();
                foreach (var d in dbE)
                    Console.WriteLine(d.NOM + " -- " + d.EMPNO);


                // Display all Blogs from the database
                var query = from b in db.EMPLOYE
                            orderby b.NOM
                            select b;                           
                Console.WriteLine("All Employe in the database Vente:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.NOM);
                }
            }

            using (var db = new OdinCheckEntities())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new Personne: ");
                var name = Console.ReadLine();

                var pers = new PERSONNE { PersonneName = name, PersonnePass = "test", Actif = true };

                db.spAddPersonne(name, "testEF" + name, "pass1", 2);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.PERSONNE
                            orderby b.PersonneName
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.PersonneName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }
        }
    }
}
