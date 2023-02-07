using System;

namespace GC_Finaliseur

{
    class Program
    {
        static void Main(string[] args)
        {

            classeB x = new classeB();
            classeC y = new classeC();

            x = null;
            y = null;
            GC.Collect();
            Console.WriteLine("Hello World!");


           
            int[] ints = { -9,14,37,102, };
            Console.WriteLine(Answer.Exists(ints, 102));
            Console.WriteLine(Answer.Exists(ints, 36));

        }
    }

    public class Answer
    {
        public static bool Exists(int[] ints, int k)
        {

            foreach (int m in ints)
                if (m == k) return true;

            return false;

        }
    }

    class classeA
    {
        public string info;
        public classeA()
        {
            info = "Objet de classe A";
            Console.WriteLine("constructeur : " + info);
        }

        ~classeA()
        {
            Console.WriteLine("finalizeur de classeA pour " + info);
        }
    }

    class classeB : classeA
    {
        public classeB()
        {
            info = "Objet de classe B";
            Console.WriteLine("constructeur : " + info);
        }

        ~classeB()
        {
            Console.WriteLine("finalizeur de classeB pour " + info);
        }

    }

    class classeC : classeA
    {
        public classeC()
        {
            info = "objet de classe C";
            Console.WriteLine("constructeur : " + info);
        }
    }

}

