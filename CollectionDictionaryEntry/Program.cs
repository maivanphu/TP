using System;
using System.Collections;

class ListeTable : ArrayList
{
    //Construire une classe ListeTable héritant de ArrayList et contenant une méthode renvoyant un tableau de DictionaryEntry sur chaque objet de la liste
    //(la clef sera le hashcode de l'objet).

    public DictionaryEntry[] getTable()
    {
        DictionaryEntry[] dic = new DictionaryEntry[this.Count];
        for (int i = 0; i < this.Count; i++)
        {
           // dic[i] = new DictionaryEntry(); // pas nécessaire pour une structure
            dic[i].Key = this[i].GetHashCode();
            dic[i].Value = this[i];
        }
        return dic;          
    }
}

class ApplicationTest
{
    static void Main(string[] args)
    {
        ListeTable listeAnimaux = new ListeTable();
        listeAnimaux.Add("rat");
        listeAnimaux.Add("chat");
        listeAnimaux.Add("vache");
        listeAnimaux.Add("chien");
        listeAnimaux.Add("loup");
        listeAnimaux.Add("ours");
        // code d'appel de getTable( ) et d'affichage
        // à écrire .... 

        DictionaryEntry[] tab = listeAnimaux.getTable();

        foreach (DictionaryEntry s in tab)
            Console.WriteLine("key ={0}, value= {1}", s.Key, s.Value);

        System.Console.ReadLine();
    }
}



