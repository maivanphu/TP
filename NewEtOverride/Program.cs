using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace NewEtOverride
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(4 / 3);
            Console.WriteLine(2 / 3);

            // Use StringBuilder for concatenation in tight loops.
            var sb = new System.Text.StringBuilder();
            for (int ik = 0; ik < 20; ik++)
            {
                sb.AppendLine(ik.ToString());
            }
            System.Console.WriteLine("--------------StringBuilder() :" + sb.ToString());



            //un objet string de C# est immuable (son contenu ne change pas) 
            String s1 = "String";
            String s2;
            s2 = String.Copy(s1);
            Console.WriteLine(s2);


            string str = "Hello World!";
            Console.WriteLine(String.Compare(str, "Hello World?").GetType());


            Console.WriteLine("------------------------------------");


            Single f = 9.8f;
            String s, s11;
            s = Convert.ToString(f);
            s11 = f.ToString();

            Console.WriteLine(s);
            Console.WriteLine(s11);





            //ClasseÀHériter càh = new ClasseÀHériter();
            //string scàh = càh.Résultat();

            //ClasseHéritante ch = new ClasseHéritante();

            //string schr = ch.Résultat();
            //string scàhar = ch.AutreRésultat();


            // C# utilise le mot clé override pour signifier que la méthode dans la classe dérivée surcharge la méthode héritée. 
            //Le mot clé new définit la méthode comme une nouvelle méthode indépendante de celle de la classe de base

            Animal animal = new Animal();
            animal.SeDeplace(); // affiche se deplace

            Animal chien = new Chien();
            chien.SeDeplace(); // affiche marche

            Animal serpent = new Serpent();
            serpent.SeDeplace(); // affiche rampe





            Animal grenouille = new Grenouille();
            grenouille.SeDeplace(); // affiche se deplace //Car la classe Animal n’a aucune connaissance de l’existence de la méthode créée avec New.

            //Par contre si On crée un objet Grenouille, la classe Grenouille appellera sa propre méthode.
            Grenouille grenouille2 = new Grenouille();
            grenouille2.SeDeplace(); // affiche saute

            Pigeon pigeon = new Pigeon();
            pigeon.SeDeplace(); // affiche vole


            Console.WriteLine("--------------------------------------------!");


            Entity human = new Human();

            human.Execute(); // => Je suis dans Human

            human.Execute2(); // => Je suis dans Entity



            //Human human = new Human();
            //Entity entity = human;

            //entity.Execute(); // => Je suis dans Human 
            //human.Execute();  // => Je suis dans Human 

            //entity.Execute2(); // => Je suis dans Entity
            //human.Execute2(); // => Je suis dans Human




            color c;
            c = color.red;
            Console.WriteLine(c); // ca donne red

            Console.Write((int)color1.red + ", ");
            Console.Write((int)color1.green + ", ");
            Console.WriteLine((int)color1.blue);

            //color1.green = 5; // an enum element cannot be assigned a value outside the enum declaration.

            Console.Write((int)color2.green + ", ");
            Console.WriteLine((int)color2.yellow); // output: 1, 11


            color c1 = color.red;
            Type t;
            t = c1.GetType();
            string[] str1;
            str1 = Enum.GetNames(t);
            Console.WriteLine(str1[0]);


            Console.WriteLine("------------------");

            char ch = Convert.ToChar('a' | 'b' | 'c');
            switch (ch)
            {
                case 'A':
                case 'a':
                    Console.WriteLine("case A | case a");
                    break;

                case 'B':
                case 'b':
                    Console.WriteLine("case B | case b");
                    break;

                case 'C':
                case 'c':
                case 'D':
                case 'd':
                    Console.WriteLine("case D | case d");
                    break;
            }



            Console.WriteLine("------------------");

            //int a12;
            //String res;
            //if (a12 % 2 == 0)
            //    res = "Even";
            //else
            //    res = "Odd";

            Console.WriteLine("--------Quel est output---------");

            int i;
            for (i = 0; i <= 10; i++)
            {

                // Console.Write(i + " ");


                if (i == 4)
                {
                    Console.Write(i + " "); continue;
                }
                else if (i != 4)
                    Console.Write(i + " ");
                else
                    break;
            } //0 1 2 3 4 5 6 7 8 9 10


            Console.WriteLine("--------Which of the following loop correctly prints the elements of the array----------");

            char[] arr = new char[] { 'k', 'i', 'C', 'i', 't' };

            foreach (int i5 in arr)
            {
                Console.WriteLine((char)i5);
            }


            //The compiler will report case i and case j as errors since variables cannot be used in cases.
            //int i9, j9, id = 0; switch (id)
            //{
            //    case i9:
            //        Console.WriteLine("I am in Case i");
            //        break;

            //    case j9:
            //        Console.WriteLine("I am in Case j");
            //        break;
            //}




            static int meth102(char x)
            {
                System.Console.WriteLine("\n Exécution de meth102('" + x + "')");
                return x + 102;
            }

            // meth102('c'); //97 dans l'Assii
            System.Console.WriteLine("valeur du champ : " + meth102('c'));



            int[] numbers = { 1, -28, 88, 200, 7 };
            Console.WriteLine("-------------------returne le plus grand nombre  " + FinLagest(numbers));

            Console.WriteLine("Méthodes d'extension dans LINQ: ");

            Console.WriteLine(numbers.Last());
            Console.WriteLine(numbers.First());
            Console.WriteLine(numbers.Average());
            Console.WriteLine(numbers.Sum());


            var list = new List<int>(2);
            list.Add(1);
            list.Add(1);
            list.Add(1);

            Console.WriteLine("-------------------list.Count " + list.Count);



            //When overloading a non-virtual method with another signature, the keyword new may be used. 
            //The used method will be chosen by the type of the variable instead of the actual type of the object.

            var operation = new NewOperation();
            // Will call "double Do()" in NewOperation
            string d = operation.Do();
            Console.WriteLine("-------------------d " + d);

            Operation operation_ = operation;

            // Will call "int Do()" in Operation
            int i6 = operation_.Do();
            Console.WriteLine("-------------------i6 " + i6);


        }

        public static int FinLagest(int[] numbers) // returne le plus grand nombre
        {
            //int m = 0;
            //foreach (int k in numbers)
            //    if (k > m)
            //        m = k;
            //return m;

            //int largest = numbers[0];
            //for (int big = 1; big < numbers.Length; big++)
            //{
            //    if (largest < numbers[big])
            //    {
            //        largest = numbers[big];
            //    }
            //}

            //return largest;
            return numbers.Max(); // Ca marche avec LINQ
        }

    }


    // Methods marked virtual provide an implementation, but they can be overridden by the inheritors by using the override keyword.
    //The implementation is chosen by the actual type of the object and not the type of the variable.

    //class Operation
    //{
    //    public virtual int Do()
    //    {
    //        return 0;
    //    }
    //}

    //class NewOperation : Operation
    //{
    //    public override int Do()
    //    {
    //        return 1;
    //    }
    //}


    class Operation
    {
        public int Do()
        {
            return 0;
        }
    }

    class NewOperation : Operation
    {
        public new string Do()
        {
            return "4.0";
        }
    }

    enum color
    {
        red,
        green,
        blue
    }

    enum color1 : int
    {
        red = -3,
        green,
        blue
    }

    enum color2 : int
    {
        red,
        green,
        blue = 5,
        cyan,
        magenta = 10,
        yellow
    }


    //Since 500, 1000, 1500 exceed the valid range of byte compiler will report an error.
    enum color3 : byte // mex=256 
    {
        //red = 500,
        //green = 1000,
        //blue = 1500

        red = 50,
        green = 100,
        blue = 150
    }

    // Variables cannot be assigned to enum elements. (meme quand c'est possible de mettre bloc enum dans une classe

    //    int a = 10;
    //    int b = 20;
    //    int c = 30;
    //enum color : byte
    //{
    //    red = a,
    //    green = b,
    //    blue = c
    //}


    public class Exemple // exemple pratique
    {

        private enum jour { lundi, mardi, mercredi, jeudi, vendredi, samedi, dimanche }
        public enum weekEnd { vendredi, samedi, dimanche }


        public static void Excepn()
        {
            Entity MyEntity = null;

            string SelectComboBoxtext = "";

            switch (SelectComboBoxtext)
            {
                case "Human": MyEntity = new Human(); break;
                    //   case "Animal": MyEntity = new Animal(); break;

            }
            // MyEntity.Draw();


            int i = 0, j = 0;

        label1:
            i++;
            j += i;
            if (i < 10)
            {
                Console.Write(i + " ");
                goto label1;
            }


        }


    }

    public interface B
    {

    }
    public interface C
    { }

    public interface A : B, C
    {

    }



    public class Animal
    {
        private string A5; // tester la visibilité depuis Chien
        public virtual void SeDeplace()
        {
            Console.WriteLine("se deplace");
        }
    }

    public class Chien : Animal
    {

        public override void SeDeplace()
        {
            Console.WriteLine("marche");
            // A5 = "5"; // Pas visible
        }
    }

    public class Serpent : Animal
    {
        public override void SeDeplace()
        {
            Console.WriteLine("rampe");
        }
    }




    public class Grenouille : Animal
    {
        public new void SeDeplace()
        {
            Console.WriteLine("saute");
        }
    }

    public class Pigeon : Animal
    {
        public void SeDeplace()  //Mettre new revient presque qu’à ne mettre ni new, ni override, à la différence près qu’une warning s’affichera. 
        {
            Console.WriteLine("vole");
        }
    }



    public class Entity
    {
        public virtual void Execute()
        {
            Console.WriteLine("salut, je suis dans entity");
        }

        public void Execute2()
        {
            Console.WriteLine("salut, je suis dans entity Execute2");
        }
    }

    public class Human : Entity
    {
        public override void Execute()
        {
            Console.WriteLine("salut, je suis dans Human");
        }

        public new void Execute2()
        {
            Console.WriteLine("salut, je suis dans Human Execute2");
        }
    }


    public class ClasseÀHériter
    {
        public string FonctionNormale()
        {
            return "FonctionNormale dans la classe de base";
        }
        public virtual string FonctionExplicitementRemplaçable()
        {
            return "FonctionExplicitementRemplaçable dans la classe de base ";
        }
        public string Résultat()
        {
            return
                this.FonctionNormale()  // Appelle toujours la fonction définie dans cette classe.
                + "\n"
                + this.FonctionExplicitementRemplaçable(); // La fonction appelée a pu être remplacée dans une classe héritante.
        }
    }

    public class ClasseHéritante : ClasseÀHériter
    {
        public new string FonctionNormale()
        {
            return "FonctionNormale dans la classe dérivée";
        }
        public override string FonctionExplicitementRemplaçable()
        {
            return "FonctionExplicitementRemplaçable dans la classe dérivée";
        }
        public string AutreRésultat()
        {
            return
                this.FonctionNormale()
                + "\n"
                + this.FonctionExplicitementRemplaçable();
        }
    }


}
