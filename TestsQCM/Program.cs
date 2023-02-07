using System;
using System.Numerics;
using System.Collections.Generic;

namespace TestsQCM
{

    class A
    {
       protected string strpro; // accessible depuis B?
       private string str;

    }
    class B : A
    {
        private string strproNew;
        //strpro = "protected"; // pas accesible
        public B()
        {
           // str = "privaite"; // pas accessible
            strpro = "protected";
        }
       
    }
    class Program
    {

        static void dispay(int val=0)
        {
            Console.WriteLine(val);
        }
        static void Main(string[] args)
        {
            var list4 = new List<int>(2);
            list4.Add(1);
            list4.Add(1);
            list4.Add(1);

            Console.WriteLine("list.count="+list4.Count);
           


            BigInteger big = 44;


            int p=5,k1;
            Console.WriteLine(k1 = p + 5);

            //int k2;
            //dispay(k2);


            ///var m = 2, n = 6,k1 = 8; plusieur décalarateur avec var n'est pas accepté

            string str1 = "C*";
            string str2 = "C*";
            Console.WriteLine(ReferenceEquals(str1, str2));

            float ff = 10.2f;
            long lg = 200L;
            Console.WriteLine(ff + lg);



            int?[] arr1 = new int?[5];// { 1, 54, 8, 9, 3 };

            Console.WriteLine(arr1[0]);


            int[] arr0 = new int[5] { 1, 54, 8, 9, 3 };

     

            try
            {
                Console.WriteLine(arr0[10]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Errer 2 " + ex.ToString());
            }
            catch (Exception ex) // il faut mettre l'exception générale à la fin
            {
                Console.WriteLine("Errer 1 " + ex.ToString());
            }
            finally
            {
                Console.WriteLine("fini");
            }
        


            byte b1 = 0xF7; //11110111
            byte b2 = 0xAB;// 10101011
            byte temp;
            Console.WriteLine(Convert.ToString(b1, toBase:2)) ;
            Console.WriteLine(Convert.ToString(b2, toBase: 2));

            Console.WriteLine(Convert.ToString(b1, toBase: 10));
            Console.WriteLine(Convert.ToString(b2, toBase: 10));
            byte resul = 0b_10100011;
            Console.WriteLine(Convert.ToString(resul, toBase: 10));
             resul = 0b_01011100;
            Console.WriteLine(Convert.ToString(resul, toBase: 10));

            temp = (byte)(b1 & b2);
            Console.Write(temp + " ");
            temp = (byte)(b1 ^ b2);
            Console.WriteLine(temp);


            Console.WriteLine("--------------------------------------");

            // post - incrémentation : k++   la valeur de k est d'abord utilisée telle quelle dans l'instruction, puis elle est augmentée de un à la fin.
            int k = 5, n;
            // n = k++;
            //n = k++ - k;
            // n = k - k++;

            //pré - incrémentation : ++k    la valeur de k est d'abord augmentée de un ensuite utilisée dans l'instruction.
            //n = ++k;
            //n = ++k - k;
            //n = k - ++k;


            //Post-décrémentation : k--   la valeur de k est d'abord utilisée telle quelle dans l'instruction, puis elle est diminuée de un à la fin.
            // n = k--;
            //n = k-- - k;
            //n = k - k--;

            //pré - décrémentation : --k    la valeur de k est d'abord diminuée de un, puis utilisée avec sa nouvelle valeur. 
            //n = --k;
            //n = --k - k;
            n = k - --k;


            Console.WriteLine("k = " + k + ", n=" + n);




            System.Console.WriteLine((35 + 4) % 7);
            System.Console.WriteLine(2 + 15 / 6 * 1 - 7 % 2);

            int[][] a = new int[2][];
            a[0] = new int[4] { 6, 1, 4, 3 };
            a[1] = new int[3] { 9, 2, 7 };
            Console.WriteLine(a[1].GetUpperBound(0)); // quel résultat?



            int i, j;
            int[,] arr = new int[2, 2];
            for (i = 0; i < 2; ++i)
            {
                for (j = 0; j < 2; ++j)
                {
                    //arr[i, j] = i * 17 + j * 17;
                    arr[i, j] = i * 17 + i * 17;
                    Console.WriteLine(arr[i, j]);
                }
            }

            //A.  0 0 34 34
            //B.  0 0 17 17
            //C.  0 0 0 0
            //D.  17 17 0 0
            //E.  34 34 0 0


            Console.WriteLine("Hello World!");



            int[] arr11 = new int[] { 1, 2, 3, 4, 5 };
            fun(ref arr11);
            //            A.  1 2 3 4 5
            //B.  6 7 8 9 10
            //C.  5 10 15 20 25 // OK
            //D.  5 25 125 625 3125
            //E.  6 12 18 24 30

            for (int i1 = 0; i1 < arr11.Length; i1++)
            {
                Console.WriteLine("\n Après appel fun(ref arr1): " + arr11[i1] + " ");
            }




            int num = 1;
            funcv(num);
            Console.Write(num + ", ");

            funcr(ref num);
            Console.Write(num + ", ");

            //            A.  1, 1, 1, 1,
            //B.  11, 1, 11, 11,  OK
            //C.  11, 11, 11, 11,
            //D.  11, 11, 21, 11,
            //E.  11, 11, 21, 21,



            int a1 = 5;
            int s = 0, c = 0;
            Proc(a1, ref s, ref c);
            Console.WriteLine("\n" + s + " et " + c);

            int i2 = 10;
            double d = 34.340;
            fun(i2);
            fun(d);



            object[] o = new object[] { "1", 4.0, "India", 'B' };
            fun(o);



            Console.WriteLine("-------------------------- ");
            int i3;
            int res = fun(out i3);
            Console.WriteLine("fun(out int i)=" + res);
            Console.WriteLine(i3);


            Console.WriteLine("-------Ref and Out----------------- ");
            int i33 = 5;
            int j3;
            fun1(ref i33);
            fun2(out j3);
            Console.WriteLine(i33 + ", " + j3);

            Emp e = new Emp();
            Emp e1;

            Student ss = new Student();
            ss[1, 2] = 5;


            int x = 1;
            float y = 1.1f;
            short z = 1;
            Console.WriteLine("Data: ");
            Console.WriteLine((float)x + y * z - (x += (short)y));


            DataType.testVariable();

        }

        static void fun1(ref int x)
        {
            x = x * x;
        }
        static void fun2(out int x)
        {
            x = 6;
            x = x * x;
        }

        //        A.  5, 6
        //B.  5, 36
        //C.  25, 36
        //D.  25, 0
        //E.  5, 0

        static int fun(out int i)
        {
            int s = 1;
            i = 7;
            for (int j = 1; j <= i; j++)
            {
                s = s * j;
            }
            return s;
        }

        //        A.  1
        //B.  7
        //C.  8
        //D.  720
        //E.  5040 //OK


        static void fun(params object[] obj)
        {

            Console.WriteLine("-------------   i < obj.Length - 1   ----------- ");
            for (int i = 0; i < obj.Length - 1; i++)
                Console.Write(obj[i] + " ");

            //Pour afficher le dernier élément aussi:
            for (int i = 0; i <= obj.Length - 1; i++)
                Console.Write(obj[i] + " ");
        }

        //        [A].	1 4.0 India B
        //[B].	1 4.0 India
        //[C].	1 4 India	//ok
        //[D].	1 India B

        static void fun(double d)
        {
            Console.WriteLine(d + " ");
        }
        //        A.  10.000000 34.340000
        //B.  10 34
        //C.  10 34.340
        //D.  10 34.34  ?


        static void Proc(int x, ref int ss, ref int cc)
        {
            ss = x * x;
            cc = x * x * x;
        }
        //        A.  0 0
        //B.  25 25
        //C.  125 125
        //D.  25 125 //OK
        //E.None of the above



        static void funcv(int num)
        {
            num = num + 10; Console.Write(num + ", ");
        }
        static void funcr(ref int num)
        {
            num = num + 10; Console.Write(num + ", ");
        }



        static void fun(ref int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = a[i] * 5;
                Console.Write(a[i] + " ");
            }
        }



    }

    struct Emp
    {
        private String name;
        private int age;
        private Single sal;
    }

    class DataType
    {
        // correct way to initialise the variables i and j to a value 10 each
        int i4 = 10, j4 = 10;
          

        public static void testVariable()
        {
            byte a = 11, b = 22, c;

            //c = (byte) a + (byte)b;
            //c = a + b;
            c = (byte)(a + b);

            Console.WriteLine("DataType Test:" + c);

        }

    }



    class Student
    {
        int[,] a = new int[5, 5];
        public int this[int i, int j]
        {
            set
            {
                a[i, j] = value;
            }
        }
    }




    class Sample
    {
        //static int i;
        //int j;
        //public void proc1()
        //{
        //    i = 11;
        //    j = 22;
        //}
        //public static void proc2()
        //{
        //    i = 1;
        //    j = 2;
        //}
        //static Sample()
        //{
        //    i = 0;
        //    j = 0;
        //}
    }
    //    [A].	i cannot be initialized in proc1().
    //[B].  proc1() can initialize i as well as j.  @ OK
    //[C].	j can be initialized in proc2().
    //[D].	The constructor can never be declared as static.
    //[E].	proc2() can initialize i as well as j.


    //Le singleton pattern appartient à la catégorie des patrons de création.Son but est d’éviter qu’une classe ne crée plus d’un objet.
    //    Pour ce faire, on crée l’objet souhaité dans une classe propre, puis on le récupère sous forme d’instance statique. 
    //    Le singleton est l’un des patrons les plus simples, mais les plus puissants dans le développement de logiciels.
    //For example a singleton instance:
    public class Foo
    {

        private Foo() { }

        private static Foo FooInstance { get; set; }

        public static Foo GetFooInstance()
        {
            if (FooInstance == null)
            {
                FooInstance = new Foo();
            }

            return FooInstance;
        }

    }
    //This allows only one instance of the class to be created.

    //Le singleton est généralement utilisé lorsque des tâches récurrentes doivent être effectuées dans le cadre d’une routine de programme.
    //    Il s’agit notamment des données à écrire dans un fichier, par exemple pour des fichiers logs ou des travaux d’impression qui 
    //    doivent être écrits de manière répétée dans une seule mémoire tampon d’imprimante.

    public class Generic<T>
    {
        public T Field;
        public void TestSub()
        {
          //  T i = Field + 1;
        }
    }
}
