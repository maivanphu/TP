using System;
using System.Collections;

class Exercice
{
    public static void afficher1(Queue file)
    { // vidage :
        int count = file.Count;
        for (int i = 1; i <= count; i++)
            Console.WriteLine(file.Dequeue());
    }
    public static void afficher2(Queue file)
    { // parcours :
        foreach (string s in file)
            Console.WriteLine(s);
    }
    public static void Main()
    {

        //remplir une file fifo nommée file1 avec 5 éléments, puis recopier file1 dans une autre file fifo nommée file2.
        ////La méthode afficher1 sert à vider toute une file en affichant son contenu au fur et à mesure, 
        ///la méthode afficher2 sert à parcourir toute une file sans vider son contenu.

        Queue file1 = new Queue(); // pile FIFO
        Queue file2 = new Queue();
        // remplissage :
        for (int i = 1; i < 6; i++)
            file1.Enqueue("nbr-" + Convert.ToString(i));
        // recopie :
        file2 = (Queue)file1.Clone();
        Console.WriteLine("\nAffichage for count :");
        afficher1(file1);
        Console.WriteLine("\nAffichage foreach :");
        afficher2(file2);


        Console.WriteLine("\n\n Exo 2--------------------------------");

        string[] tableau = { "11", "22", "33", "44", "55", "66" };
        File p1 = new File(tableau);

        foreach (string s in p1)
            Console.WriteLine(s);

        Console.WriteLine("\n Extrait 3 éléments--------------------------------");

        object[] tab = p1.Dequeue(3);

        foreach (object o in tab)
            Console.WriteLine(o.ToString());


        Console.WriteLine("\n tableau key value-------------------------------");

        DictionaryEntry[] T4 =
            {
new DictionaryEntry( 2, 10 ),
new DictionaryEntry( 3, 20 ),
new DictionaryEntry( 4, 30 ),
new DictionaryEntry( 1, 40 ),
new DictionaryEntry( 0, 50 )
        };

        File p4 = new File(T4);
        foreach (DictionaryEntry d in p4)
            Console.WriteLine("key={0}, value={1}", d.Key.ToString(), d.Value.ToString());


        Console.ReadLine();
    }


    //Construire une classe File héritant de la classe Queue permettant :
    //1°)d'ajouter immédiatement dans la file dès sa création un tableau linéaire de n'importe quel type (int, double, string, object,...)
    //2°) et permettant de sortir immédiatement dans un tableau d'Object les n premiers éléments de la file.

    class File : Queue
    {
        public File(Array tab)
        {

            for (int i = 0; i < tab.Length; i++)
                this.Enqueue(tab.GetValue(i));
        }


        public virtual object[] Dequeue(int nbr)
        {
            object[] tab = new object[nbr];
            for (int i = 0; i < nbr; i++)
                tab[i] = this.Dequeue();

            return tab;
        }
    }
}
