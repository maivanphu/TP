using System;
using System.Collections;

namespace CollectionArrayListe
{
    /* Construire une classe MaListe héritant de la classe ArrayList permettant :
 1°)d'ajouter immédiatement dans la liste dès sa création un tableau linéaire de n'importe quel type(int, double, string, object,...)
 2°) et permettant de sortir immédiatement dans un tableau d'Object les n premiers éléments de la liste.*/
    //commentaire: cette classe permet de manipuler un tableau (passé en argument) dynamiquement (en bénéficiant des méthode Add, Remove... de ArrayList)
    class MaListe : ArrayList//,IComparable, IComparer
    {
        public MaListe(Array list)
        {
            // list = new int[5];
            for (int i = 0; i < list.Length; i++)
                this.Add(list.GetValue(i));
        }

        //public int CompareTo(object obj)
        //{

        //    Car c = (Car)obj;
        //    return String.Compare(this.make, c.make);

        //    throw new NotImplementedException();
        //}

        //int IComparer.Compare(object a, object b)
        //{
        //    Car c1 = (Car)a;
        //    Car c2 = (Car)b;
        //    return String.Compare(c2.make, c1.make);
        //}

        public virtual object[] ToArray(int nbrElt)
        {
           
            object[] T = new object[nbrElt];
            for (int i = 0; i < nbrElt; i++)
                T[i] = this[i];
            return T;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {

            // Array arr = new Array(); // pas possible car classe Abstraite n'est pas instanciable

            string[] T2 = new string[] { "veau", "vache", "cochon", "couvee", "pot", "lait" };

            MaListe list = new MaListe(T2);
            list.Add("NEW humain");
            list.Sort();
            list.RemoveAt(list.Count - 1);

            Console.WriteLine("----- string -----");
            foreach (string s in list) Console.WriteLine(s);

            Console.WriteLine("----- 3 premier elements string à sortir avec ToArray -----");
            object[] T0 = list.ToArray(3);
            foreach (object elt in T0)
                Console.WriteLine((string)elt);




            int[] T1 = { 2, 8, 76, 23, 100, 45, 21 };
            System.Console.WriteLine("----- int -----");
            list = new MaListe(T1);
            foreach (int s in list) Console.WriteLine(s);

            Console.WriteLine("----- 5 premier elements Int à sortir avec ToArray -----");
            T0 = list.ToArray(5);
            foreach (object elt in T0)
                Console.WriteLine(elt.ToString());



            double[] T3 = { 2.3, 8.45, 0.6, 23.9, 10.02 };

            list = new MaListe(T3);
            list.Sort();
            System.Console.WriteLine("----- double -----");
            foreach (double s in list) Console.WriteLine(s);



            DictionaryEntry[] T4 = new DictionaryEntry[] { new DictionaryEntry(2, "OK"), new DictionaryEntry(1, "doctor"),new DictionaryEntry( 4, 30 ),
new DictionaryEntry( 1, 40 ),new DictionaryEntry( 0, 50 ) };
            System.Console.WriteLine("----- DictionaryEntry -----");
            list = new MaListe(T4);
            //list.Sort();
            foreach (DictionaryEntry d in list)
                Console.WriteLine("key: " + d.Key.ToString() + " -- value: " + d.Value.ToString());

            Console.WriteLine("---------un exemple simple de vecteur de chaînes utilisant quelques unes des méthodes------");
            VecteurInitialise();





            Console.WriteLine("\n---------- Exo 2------ ");

            /*
            1°) Ajouter à la fin de liste1 tous les éléments de liste2.
2°) Stocker dans un tableau de 5 string les 5 éléments consécutifs de liste1 à partir du troisième.
3°) Ecrire la méthode afficher( ... ) qui reçoit un paramètre soit de type ArrayList, soit de type tableau de string et qui afficher le contenu de tous les éléments de la structure
            */

            ArrayList liste1 = new ArrayList();
            ArrayList liste2 = new ArrayList();
            for (int i = 1; i < 6; i++)
                liste1.Add("nbr-" + Convert.ToString(i));
            for (int i = 6; i < 11; i++)
                liste2.Add("nbr-" + Convert.ToString(i));
            // ajouter à la liste1 tous les éléments de la liste2

            //foreach (var obj in liste2)
            //    liste1.Add(obj);

            liste1.AddRange(liste2);

            Console.WriteLine("La liste après ajout :");
            //afficher((string[])liste1.ToArray(typeof(string)));
            afficher(liste1);

            // stocker dans un tableau de string cinq éléments extraits de liste1
            string[] table = new string[5];

            //for (int i = 0; i < 5; i++)
            //    table[i] = liste1[i + 2].ToString();

            table = (string[]) liste1.GetRange(2, 5).ToArray(typeof(string));


            Console.WriteLine("\nLe tableau de string extrait :");
            afficher(table);




            Console.ReadLine();
        }

        //public static void afficher(string[] tab)
        //{
        //    for (int i = 0; i < tab.Length; i++)
        //        Console.WriteLine(tab[i]);
        //}

        public static void afficher(IEnumerable tab)
        { 
            foreach (string s in tab)
                Console.WriteLine(s);
        }



        static void AfficherVecteur(ArrayList tab)
        {
            Console.WriteLine("Taille du vecteur: " + tab.Count);

            foreach (object elt in tab)
                //Console.WriteLine(elt.ToString());
                Console.WriteLine((string)elt);

            for (int i = 0; i < tab.Count; i++)
            {
                Console.WriteLine("tab[" + i.ToString() + "] = " + (string)tab[i]);
            }

        }
        static void VecteurInitialise()
        {
            ArrayList list = new ArrayList();

            string str = "val ";
            for (int i = 0; i < 10; i++)
            {
                list.Add(str + i.ToString());
            }

            AfficherVecteur(list);

        }
    }
}
