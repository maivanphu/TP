using System.Collections;
using System;

namespace CollectionDictionnaryBase
{
    class Program
    {
        static void Main(string[] args)
        {

            object[] T0 = null;

            string[] T2 =
            {
"veau", "vache", "cochon", "couvee", "pot", "lait"
};

            System.Console.WriteLine("----- string -----");
            MonDico dico = new MonDico(T2);
            foreach (DictionaryEntry s in dico)
                Console.WriteLine("Key= {0}; value={1}", s.Key, s.Value);



            int[] T1 =
{
2, 8, 76, 23, 100, 45, 21
};
            System.Console.WriteLine("----- int -----");
            dico = new MonDico(T1);
            T0 = dico.Remove(3);

            foreach (DictionaryEntry s in dico)
                Console.WriteLine("Key= {0}; value={1}", s.Key, s.Value);




            double[] T3 =
{
2.3, 8.45, 0.6, 23.9, 10.02
};
            System.Console.WriteLine("----- double -----");
            dico = new MonDico(T3);
            T0 = dico.Remove(3);
            foreach (DictionaryEntry s in dico)
                Console.WriteLine("Key= {0}; value={1}", s.Key, s.Value);

            Console.ReadKey();
        }
    }

    //    gestion d'une collection d'objets rangés sous forme de dictionnaire(paire de valeur<clef, valeur>), nommée DictionaryBase
    //    et située dans le namespace System.Collections.

    // Construire une classe MonDico héritant de la classe DictionaryBase permettant :
    //1°)d'ajouter immédiatement au dictionnaire dès sa création un tableau linéaire de n'importe quel type(int, double, string, object,...)
    //2°) et permettant de sortir les n premiers éléments du dictionnaire dans un tableau d'Object et de les effacer.

    class MonDico : DictionaryBase
    {
        public MonDico(Array tableau)
        {
            for (int i = 0; i < tableau.Length; i++)
                this.Dictionary.Add(tableau.GetValue(i).GetHashCode(), tableau.GetValue(i));

        }

        public virtual object[] Remove(int n)
        {

            object[] T = new object[n];

            //for (int i = 0; i < n; i++)
            //    T[i] = 

            int i = 0;
            foreach (DictionaryEntry d in this.Dictionary)
            {
                if (i < n)  T[i] = d.Value;
                i++;
            }

            i = 0;
            foreach (DictionaryEntry d in this.Dictionary)
            {
                //if (i<n) this.Dictionary.Remove(d.Key);
                //i++;
                this.Dictionary.Remove(d);
                if (++i >= n)
                    break;
            }

            return T;
        }
    }

}
