using System;

namespace Comparaison_struct_class
{

    //Objectif : Implémenter une date (année, mois) par un type valeur Struct,
    //et comparer ses possibilités avec une implémentation de cette date par un type référence class.

    //Dans un type valeur Struct, les champs ne peuvent être protected car les types Struct ne peuvent pas être hérités. 
    //Il n'est pas possible de déclarer virtual une propriété dans un Struct car l'héritage n'existe dans les Struct,
    //il ne peut donc pas y avoir de liaison autre que précoce (ceci est aussi valable pour les méthodes d'un Struct qui sont à laison statique ou précoce). 
    //Il est impossible d'initialiser des attributs dans leur déclaration dans un Struct. 

    struct DateStruct
    {
        public string FAnnee;
        private string FMois;
        public string Annee
        {
            get { return FAnnee; }
            set { FAnnee = value; }
        }
        public string Mois
        {
            get { return FMois; }
            set { FMois = value; }
        }

        //public DateStruct()
        //{ }
        public DateStruct(string an, string mois)
        {
            this.FAnnee = an;
            this.FMois = mois;
        }

        public void Afficher()
        {
            Console.WriteLine("Afficher Année {0}, Mois {1}", FAnnee, FMois);
        }
    }

    class DateClass
    {
        protected string FAnnee = "--";
        private string FMois = "**";
        public virtual string Annee
        {
            get { return FAnnee; }
            set { FAnnee = value; }
        }
        public string Mois
        {
            get { return FMois; }
            set { FMois = value; }
        }

        public DateClass()
        { }

        public DateClass(string an, string mois)
        {
            this.FAnnee = an;
            this.FMois = mois;
        }

    }

    class UseDateClass
    {
        public UseDateClass() { }
        public UseDateClass(DateClass dat)
        {
            dat.Annee = Convert.ToString(Convert.ToInt32(dat.Annee) + 70);
        }
        public void ModifDate(DateClass dat) // utiliser directement le constructeur pour passer le paramètre ref
        {
            dat.Annee = Convert.ToString(Convert.ToInt32(dat.Annee) + 70);
        }
    }


    //On donne la classe UseDateStruct qui permet de manipuler un objet de type DateStruct :
    class UseDateStruct
    {
        public string siecle(DateStruct dat)
        {
            //dat.Annee += " = 21 ème siécle";
            if (Convert.ToInt32(dat.Annee) > 2000)
                return dat.Annee + " = 21 ème siécle";
            else
                return dat.Annee + " = 20 ème siécle";
        }
        public void modifDate_1(DateStruct dat) //ne modifie pas la valeur du champ Annee du  DateStruct .
        {
            dat.Annee = Convert.ToString(Convert.ToInt32(dat.Annee) + 10);
        }

        // Proposez alors, une autre méthode "modifDate_2" qui permettrait de modifier effectivement le DateStruct passé en paramètre et testez-la :
        public void modifDate_2(ref DateStruct dat)
        {
            dat.Annee = (Convert.ToInt32(dat.Annee) + 50).ToString();
        }

    }


    class Program
    {
        static void Main(string[] args)
        {


            //   Unlike classes, structs can be instantiated without using the New operator.
            //If the New operator is not used, the fields remain unassigned and the object cannot be used until all the fields are initialized.
            DateStruct ds0;
            ds0.FAnnee = "Old";
            // ds0.Mois = "Mars";
            //ds0.Afficher();

            DateStruct ds = new DateStruct();
            //ds.Annee = "2022";
            //ds.Mois = "Janvier";

            ds.Afficher();

            Console.WriteLine("Année {0}, Mois {1}", ds.Annee, ds.Mois);

            ds = new DateStruct("1980", "Decembre");
            Console.WriteLine("Année {0}, Mois {1}", ds.Annee, ds.Mois);

            UseDateStruct use = new UseDateStruct();
            Console.WriteLine(use.siecle(ds));
            use.modifDate_1(ds);
            ds.Afficher();

            use.modifDate_2(ref ds);
            ds.Afficher();
            Console.WriteLine(use.siecle(ds));

            Console.WriteLine("\n Test Class!");

            DateClass dc = new DateClass("2000","Juillet") ;
            Console.WriteLine("Année {0}, Mois {1}", dc.Annee, dc.Mois);

            UseDateClass useC = new UseDateClass(dc);
          //  useC.ModifDate(dc);

            Console.WriteLine("Passage parametre un class: Année {0}, Mois {1}", dc.Annee, dc.Mois);

            Console.ReadLine();
        }
    }
}
