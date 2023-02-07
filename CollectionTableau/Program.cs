using System;

class classeA
{
    public string[] table1 =
    {
"aa","bb","cc","dd","ee"
};
    public string[] table2 =
    {
"11","22","33","44","55"
};

    public void afficher()
    {
        Console.Write("table1 = ");
        foreach (string s in table1)
            Console.Write(s + ", ");
        Console.Write("\ntable2 = ");
        foreach (string s in table2)
            Console.Write(s + ", ");
        Console.WriteLine();
    }

    public void modifier0(string[] T)
    {
        T[2] = "yyy"; 
    }

    public void modifier1(string[] T)
    {
        T = table2; // le paramètre formel pointe vers table2, mais le passage est par valeur
        T[2] = "xxx"; // l'objet string de table2 est changé 
    }
    public void modifier2(ref string[] T)
    {
        T = table2;// le paramètre formel pointe vers table2, et le passage est par référence
        T[2] = "xxx"; // l'objet string de table2 est changé 
    }
}

class Exercice
{
    public static void Main()
    {
        classeA objA = new classeA();
        Console.WriteLine("Avant toute modifications : ");
        objA.afficher();

        //Console.WriteLine("\nobjA.modifier0(objA.table1) : ");
        //objA.modifier0(objA.table1);
        //objA.afficher();


        Console.WriteLine("\nobjA.modifier1(objA.table1) : ");
        objA.modifier1(objA.table1);
        objA.afficher();

        //Console.WriteLine("\nobjA.modifier2(ref objA.table1) : ");
        //objA.modifier2(ref objA.table1);
        //objA.afficher();


        Console.ReadLine();
    }
}