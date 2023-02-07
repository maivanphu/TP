using System;
using System.Collections;

//namespace CollectionBase
//{
class Program
{
    static void Main(string[] args)
    {

        object[] T0 = null;
        int[] T1 =
        {
2, 8, 76, 23, 100, 45, 21
};
        MaCollection  ma= new MaCollection(T1);

        foreach (int k in ma)
            Console.WriteLine(k);
        Console.WriteLine("Enlever 3 éléments ");
        ma.Remove(3);

        foreach (int k in ma)
            Console.WriteLine(k);


        DictionaryEntry[] T4 =
{
new DictionaryEntry( 2, 10 ),
new DictionaryEntry( 3, 20 ),
new DictionaryEntry( 4, 30 ),
new DictionaryEntry( 1, 40 ),
new DictionaryEntry( 0, 50 )
};

        Console.WriteLine("Entrée est un tableau des dictionnaryEntry");        

        ma = new MaCollection(T4);
        foreach (DictionaryEntry d in ma)
            Console.WriteLine("Key= {0}; value={1}", d.Key, d.Value);



        Console.ReadKey();
    }
}

//Construire une classe MaCollection héritant de la classe CollectionBase permettant :
//1°)d'ajouter immédiatement dans la collection dès sa création un tableau linéaire de n'importe quel type(int, double, string, object,...)
//2°) et permettant de sortir immédiatement dans un tableau d'Object les n premiers éléments de la collection et de les effacer.

class MaCollection : CollectionBase
{
    public MaCollection(Array tableau)
    {
        for (int i = 0; i < tableau.Length; i++)
            this.List.Add(tableau.GetValue(i));
    }

    public virtual object[] Remove(int n)
    {
        object[] T = new object[n];
        for (int i = 0; i < n; i++)
            T[i] = this.List[i];
        for (int i = 0; i < n; i++)
            RemoveAt(0);

            return T;
    }
}



//}
