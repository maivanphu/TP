using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ListeSimpe uneListeInt = new ListeSimpe();
            uneListeInt.ajouter(10);
            uneListeInt.ajouter(-12);
            //1.Version non générique: Aucune erreur n'est signalée à la compilation alors qu'il y a incompatibilité entre les types, si on appelle uneListeInt sans tester le type

//            Il revient donc au développeur dans cette classe à prêter une attention de tous les instants sur les types
//dynamiques des objets lors de l'exécution et éventuellement de gérer les incompatibilités par des 
//gestionnaires d'exception try…catch. 
            uneListeInt.ajouter("blabla");
            uneListeInt.ajouter(100);

            int entitem;//= uneListeInt.afficherInt(2);

            //Console.WriteLine(entitem);
            for (int i = 0; i < uneListeInt.list.Count; i++)
            {
                if (uneListeInt.list[i] is int) // il faut tester le type si on utilise pas le type générique
                {
                    entitem = uneListeInt.afficherInt(i);
                    Console.WriteLine("Afficher l'élément " + entitem);
                }
                else
                {
                    Console.WriteLine("Afficher l'élément " + uneListeInt.afficherString(i));
                }
            }


            Console.WriteLine("------version générique:");

            //2. Version générique:
            ListeGenerique<int> listeGeneriqueInt = new ListeGenerique<int>();
            //Le compilateur refusera le mélange des types :
         
            listeGeneriqueInt.ajouter(10);
            listeGeneriqueInt.ajouter(-88);
            //listeGeneriqueInt.ajouter("11"); // pas possible
            listeGeneriqueInt.ajouter(55);


            int x;
            for (var i = 0; i < listeGeneriqueInt.listGenerique.Count; i++)
            {
                x=listeGeneriqueInt.afficher(i);
                Console.WriteLine(x);
            }

            //On peut instancier à partir de la même classe ListeGenerique un autre objet listeGenricStr d'éléments de type string par exemple:

            ListeGenerique<string> listeGeneriqueString = new ListeGenerique<string>();

            Console.ReadLine();
        }
    }

    public class ListeSimpe
        {

        public ArrayList list = new ArrayList();

        public void ajouter(object ob)
        {
            list.Add(ob);
        }

        public int afficherInt(int rang)
        {
            return (int)list[rang];
        }


//        Si nous compilons cette classe, le compilateur n'y verra aucune erreur, car le type string hérite du type 
//object tout comme le type int. Mais alors, si par malheur nous oublions lors de l'écriture du code 
//d'utilisation de la classe, de ne ranger que des éléments du même type (soit uniquement des int, soit 
//uniquement des string) alors l'un des transtypage produira une erreur. 
        public string afficherString(int rang)
        {
            return (string) list[rang];
        }
    }



    //    une classe de type T générique agrégeant une liste d'éléments de type T générique. Dans 
    //ce contexte il n'est plus nécessaire de transtyper, ni de construire autant de méthodes que de types différents à stocker.

    public class ListeGenerique<T>
    {
        public List<T> listGenerique = new List<T>();
        // public ArrayList<T> listGenerique1 = new ArrayList<T>();

        public void ajouter(T elm)
        {
            listGenerique.Add(elm);
        }

        public T afficher(int rang)
        {
            return listGenerique[rang];

        }
    }
}
