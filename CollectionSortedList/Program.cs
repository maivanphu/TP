using System;

using System.Collections;

namespace CollectionSortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cette classe représente une collection de paires valeur - clé
            // triées par les clés toutes différentes et accessibles par clé et par index
            SortedList Liste = new SortedList();
            try
            {
                Liste.Add(55, "tata");
                Liste.Add(45, "Murielle");
                Liste.Add(201, "Claudie");
                Liste.Add(35, "José");
                Liste.Add(28, "Luc");
                Liste.Add(28, "Delta"); // lève une exception car clé doublon
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }



            Console.WriteLine("----> Balayage complet de la collection des clefs : ");
            foreach (var l in Liste.Keys)
                Console.WriteLine(l.ToString());

            Console.WriteLine("----> Balayage complet de la collection des valeurs : ");
            foreach (var l in Liste.Values)
                Console.WriteLine(l.ToString());

            Console.WriteLine("----> Balayage complet de la collection par Index : ");
            for (int i = 0; i < Liste.Count; i++)
                Console.WriteLine(Liste.GetByIndex(i));

            Console.WriteLine("Accès par clé Liste[201] :" + Liste[201].ToString());


            Console.WriteLine("----> Balayage complet de la collection par Clés : ");
            foreach (var l in Liste.Keys)
                Console.WriteLine(Liste[l]);

            Console.WriteLine("----> Balayage complet de l'objet IList retourné : ");
            for (int i = 0; i < Liste.GetValueList().Count; i++)
                System.Console.WriteLine(Liste.GetValueList()[i]);



            Console.WriteLine("\n Exo-------------------------------");

            SortedList liste = new SortedList();
            int[] clefs =
            {
4, 2, 87, 23, 45, 98, 26, 7, 10, 5
};
            // remplissage :
            for (int i = 0; i < clefs.Length; i++)
                liste.Add(clefs[i], "nbr-" + Convert.ToString(i));
            Console.WriteLine("\nAffichage foreach:");
            afficher1(liste);
            Console.WriteLine("\nAffichage par clef:");
            afficher2(liste);
            Console.WriteLine("\nAffichage par index:");
            afficher3(liste);


            Console.WriteLine("\n Exo 2 -------------------------------");

            MaSortListe Maliste = new MaSortListe(clefs);

            object[] T=Maliste.ToArray();

            foreach (object i in T)
                Console.WriteLine(i.ToString());


            Console.WriteLine("\n  5 premiers éléments de la liste dans un tableau d'Object  et de les effacer.");
            object[] T11 = Maliste.Remove(5);
            foreach (object i in T11)
                Console.WriteLine(i.ToString());

            Console.WriteLine("\n  Restant Maliste (attention: T contient toujours 10 éléments ititials):");
            //foreach (object i in Maliste.ToArray()) // attention: T contient toujours 10 éléments ititials
            //    Console.WriteLine(i.ToString());
            foreach (object i in Maliste.Values)  // attention: T contient toujours 10 éléments ititials
                Console.WriteLine(i.ToString());

            Console.WriteLine("\n  T contient toujours 10 éléments ititials):");
            foreach (object i in T)  // attention: T contient toujours 10 éléments ititials
                Console.WriteLine(i.ToString());




            object[] T0 = null;

            int[] T1 =
{
2, 8, 76, 23, 100, 45, 21
};
            string[] T2 =
{
"veau", "vache", "cochon", "couvee", "pot", "lait"
};
            double[] T3 =
            {
2.3, 8.45, 0.6, 23.9, 10.02
};

            System.Console.WriteLine("----- string -----");
            MaSortListe liste2 = new MaSortListe(T2);
            foreach (DictionaryEntry s in liste)
                System.Console.WriteLine(s.Value);
            System.Console.WriteLine("----- int -----");
            liste2 = new MaSortListe(T1);
            T0 = liste2.ToArray();
            T0 = liste2.Remove(3);
            T0 = liste2.ToArray();

            foreach (DictionaryEntry s in liste2)
                System.Console.WriteLine(s.Value);



            Console.ReadLine();
        

        }
        public static void afficher1(SortedList liste)
        { // parcours par élément  :
          //foreach (var s in liste)
            foreach (DictionaryEntry s in liste)
                Console.WriteLine("clef : " + s.Key + " , valeur = " + s.Value);
        }
        public static void afficher2(SortedList liste)
        { // parcours par clef :
            for (int i = 0; i < liste.Count; i++)
                Console.WriteLine("clef : " + i + " = " + liste[i]);
        }
        public static void afficher3(SortedList liste)
        { // parcours par rang :
            for (int i = 0; i < liste.Count; i++)
                Console.WriteLine("valeur = " + liste.GetByIndex(i) + " au rang : " + i);

        }
    }


    //    Construire une classe MaSortListe héritant de la classe SortedList permettant :
    //1°) d'ajouter directement dans la liste dès sa création un tableau linéaire de n'importe quel type(int, double, string, object,...)
    //2°) de renvoyer directement dans un tableau d'Object tout le contenu des éléments de la liste.
    //3°) de renvoyer les n premiers éléments de la liste dans un tableau d'Object  et de les effacer.
    class MaSortListe : SortedList
    {
        /// <summary>
        /// ajouter directement dans la liste dès sa création un tableau linéaire
        /// </summary>
        /// <param name="tableau"></param>
        public MaSortListe(Array tableau)
        {
            for (int i = 0; i < tableau.Length; i++)
                this.Add(tableau.GetValue(i).GetHashCode(),tableau.GetValue(i));
        }

        public virtual object[] ToArray()
        {
            object[] tab = new object[this.Count];

            for (int i = 0; i < this.Count; i++)
                //tab[i] = this.GetKey(i);
                tab[i] = this.GetKey(i)+ "-"+this.GetByIndex(i);

            return tab;
        }

        public virtual object[] Remove(int nbr)
        {
            object[] tab = new object[nbr];
            for (int i = 0; i < nbr; i++)
                tab[i] = this.GetByIndex(i);// this[i];
            for (int i = 0; i < nbr; i++)
                RemoveAt(0);
            //this.RemoveAt(0);
            return tab;

        }

    }

       

  

}
