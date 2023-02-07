using System;

namespace Finaliseur_GC
{
    class Program
    {
        static void Main(string[] args)
        {

            //classeA x = new classeA();
            //classeB y = new classeB();
            Console.WriteLine("Hello World!");
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

        //~classeA()
        //{
        //    Console.WriteLine("finalizeur de classeA pour " + info);
        //}
    }

    class classeB : classeA
    {
        public classeB()
        {
            info = "Objet de classe B";
            Console.WriteLine("constructeur : " + info);
        }

        //~classeB()
        //{
        //    Console.WriteLine("finalizeur de classeB pour " + info);
        //}

    }

    class classeC : classeA
    {
        public classeC()
        {
            info = "objet de classeC";
            Console.WriteLine("constructeur : " + info);
        }
    }

}
