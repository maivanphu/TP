
using System;
using System.Collections;

class Exercice
{
    public static void afficher1(Stack pile)
    { // vidage :
        // pile.Count varie en fait à chaque tour de boucle car l'instruction pile.Pop() diminue de 1 le compte du nombre d'élément
        // à chaque suppression, le vidage de la pile n'est alors que partiel.
        // Il faut donc sauver la valeur du comptage des éléments de la pile avant d'entrer dans la boucle for 
        int comptage = pile.Count;
        for (int i = 1; i <= comptage; i++)
            Console.WriteLine(pile.Pop());
    }
    public static void afficher2(Stack pile)
    { // parcours :
        foreach (string s in pile)
            Console.WriteLine(s);
    }
    public static void Main()
    {
        // remplir une pile lifo nommée pile1 avec 5 éléments,
        //puis recopier pile1 dans une autre pile nommée pile2.La méthode afficher1 sert à vider toute une pile
        //en affichant son contenu au fur et à mesure, la méthode afficher2 sert à parcourir toute une pile sans vider son contenu.
        Stack pile1 = new Stack();
        Stack pile2 = new Stack();
        // remplissage :
        for (int i = 1; i < 6; i++)
            pile1.Push("nbr-" + Convert.ToString(i));
        // recopie :
        pile2 = (Stack)pile1.Clone();// ca permet de doubliquet l'objet, pas seulement la copie de rérérence
        Console.WriteLine("\nAffichage for count :");
        afficher1(pile1);
        Console.WriteLine("\nAffichage foreach :");
        afficher2(pile2);






        Console.WriteLine("\n\n Exo 2--------------------------------");

        string[] tableau = { "11", "22", "33", "44", "55" };
        Pile p1 = new Pile(tableau);

        foreach (string s in p1)
            Console.WriteLine(s);

        Console.WriteLine("\n Extrait 3 éléments--------------------------------");

        object[] tab = p1.Pop(3);

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

        Pile p4 = new Pile(T4);
        foreach (DictionaryEntry d in p4)
            Console.WriteLine("key={0}, value={1}", d.Key.ToString(), d.Value.ToString());

        Console.ReadLine();
    }


    //    1°)d'empiler directement dans la pile dès sa création un tableau linéaire de n'importe quel type(int, double, string, object,...)
    //        rajoutez un nouveau constructeur.
    //2°) et permettant de dépiler directement dans un tableau d'Object les n premiers éléments de la pile.
    //        redéfinissez la méthode Pop(...)

    class Pile : Stack
    {
        public Pile(Array obj)
        {
            for (int i = 0; i < obj.Length; i++)
                this.Push(obj.GetValue(i));
        }

        public virtual object[] Pop(int nbr)
        {
            object[] tab = new object[nbr];

            for (int i = 0; i < nbr; i++)
                tab[i] = this.Pop();

            return tab;
        }
    }






}

