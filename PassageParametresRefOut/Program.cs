using System;
using System.Text;

namespace PassageParametresRefOut
{
    public struct IntHolder
    {
        public int i;    
    }

    public class IntHolderClass
    {
        public int i;
    }


    class Program
    {
        //public static void Foo(IntHolder x) {

        //    x = new IntHolder();
        //}

        public static void Foo(ref IntHolder x)
        {
            x = new IntHolder();
        }
        public static void Foo(IntHolderClass x)
        {
            x = new IntHolderClass();
        }

        static void Foo(StringBuilder x)
        {
            x = null; // une copie de référence sera pointé vers null part
        }

        static void FooModif(StringBuilder x)
        {
            x.Append(" Tout le monde"); 
        }



        static void Main(string[] args)
        {

            //type référence:
            StringBuilder first = new StringBuilder();
            StringBuilder second = first;
            first.Append("Hello");
            Console.WriteLine(second);

            StringBuilder y2 = new StringBuilder();
            y2.Append("Hello");
            Foo(y2); //Une copie de la variable référence est affecté à null, mais la valeur de y n'est pas modifié (la référence d'origine elle-meme ne change pas)
            Console.WriteLine("y is null?" + y2 == null);

            FooModif(y2);

            Console.WriteLine("y=" + y2);


            IntHolder y0 = new IntHolder();
            y0.i = 5;
            Foo(ref y0);            
            Console.WriteLine("passer un objet valeur par ref: y.i="+y0.i);

            IntHolderClass y1 = new IntHolderClass();
            y1.i = 5;
            Foo(y1);
            Console.WriteLine("passer un objet référence par valeur: y.i=" + y1.i);

   




            int a, b, c;
            a = 10;
            b = 20;
            c = 0;

            Console.WriteLine("\n(1.Passage par Valeur. avant appel de somme1( ) ) a = " + a + " , b = " + b + " et  c = " + c);

            c = Somme1(a, b);

            Console.WriteLine("( après appel de somme1( ) ) a = " + a + " , b = " + b + " et  c = " + c);
            Console.WriteLine("(----------------------------------------------------------------------");

            a = 10;
            b = 20;
            c = 0;

            Console.WriteLine("( avant appel de somme2( ) ) a = " + a + " , b = " + b + " et  c = " + c);

            c = Somme2(a, b);

            Console.WriteLine("( après appel de somme2( ) ) a = " + a + " , b = " + b + " et  c = " + c);
            Console.WriteLine("(----------------------------------------------------------------------");


            Console.WriteLine("Hello World!");


            a = 10;
            b = 20;
            c = 0;

            Console.WriteLine("(2.Passage par Référence. avant appel de sommeRef( ) ) a = " + a + " , b = " + b + " et  c = " + c);

            c = SommeRef(a, ref b);

            Console.WriteLine("( après appel de sommeRef( ) ) a = " + a + " , b = " + b + " et  c = " + c);

            Console.WriteLine("(----------------------------------------------------------------------");


            int x = 10, y = 20, z = 0;
            Console.WriteLine("(3.Passage par résultat, avant appel de modifier( ) ) x = " + x + " , y = " + y + " et  z = " + z);
            z = modifier(x, out y);
            Console.WriteLine("( après appel de modifier( ) ) x = " + x + " , y = " + y + " et  z = " + z);
            Console.WriteLine("(----------------------------------------------------------------------");
            int u = 10, v, w = 0;
            Console.WriteLine("( avant appel de modifier( ) ) u = " + u + " , v = non assignée et  w = " + w);
            w = modifier(u, out v);
            Console.WriteLine("( après appel de modifier( ) ) u = " + u + " , v = " + v + " et  w = " + w);


            Console.WriteLine("4.Paramètre variable---------------------------------------------------------");

            x = 10;
            y = 0; // assignation inutile

            // passage de paramètres effectifs :
            Console.WriteLine(SommeVariable(x, out y, 100, 200));  // 4 paramètres effectifs
            Console.WriteLine(SommeVariable(x,  out y, -5, -10, -5, -8, -2)); // 7 paramètres effectifs
            Console.WriteLine(SommeVariable(x,out y)); // 2 paramètres effectifs (liste params vide)

            Console.WriteLine("Après Appel SommeVariable y="+y);



            Console.WriteLine("5. Utilisation d'un tableau---------------------------------------------------------");

            char[] table2 = new char[7];
            //table2[0] = '?';
            //table2[4] = 'a';
           // table2[14] = '#'; //< ---est une erreur de dépassement de la taille
            for (int i = 0; i <= table2.Length - 1; i++)
                table2[i] = (char)('a' + i);


            for (int i = 0; i <= table2.Length - 1; i++)
                Console.WriteLine(table2[i]);

            Console.ReadLine();
        }




     


        //Les paramètres formels d'une méthode jouent le rôle de variables muettes et servent à décrire le fonctionnement de la méthode.

        // Dans un passage par valeur, le paramètre formel est considéré comme une variable locale dans le corps de la méthode.
        //Sa valeur est initialisée au début de chaque exécution de la méthode avec la valeur du paramètre effectif correspondant.

        public static int Somme1(int a, int b)//1. méthode avec paramètres transmis par valeur
        {
            return a + b;
        }

        public static int Somme2(int a, int b)// méthode avec paramètres transmis par valeur
        {
            a = 5;// c'est la copie locale du paramètre x qui est modifiée !
           return a + b;
        }


        public static int SommeRef(int x, ref int y) // 2.le paramètre y est  transmis par référence
        {
            y = 5;  // la variable effective référencée par y est modifiée !
            //la variable y est modifié durablement
            return x + y;
        }


        public static int modifier(int x, out int y)//3. Dans le passage par résultat, le paramètre formel est traité comme variable local dont la valeur initiale est non définie.
            //A la fin de l'appel de la méthode, la valeur résultante est renvoyée dans la varialbe effective quelque soit sa localisation
        {
            y = 10; //// la valeur locale de y est initialisée
            return x + y;
        }

        public static int SommeVariable(int a, out int b, params int[] list)
        {

            b = 20;
            int somme = a + b;

            for (int i = 0; i < list.Length; i++)
                somme += list[i];
            return somme;
        }

    }
}
