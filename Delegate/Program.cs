using System;

namespace Delegate
{

    public delegate void TypeDelegue0();
    public delegate void TypeDelegue1(int para);
    class Program
    {
        static void Main(string[] args)
        {

            useDelegate use = new useDelegate();
            use.rappelDelegate(100, methode1, methode0);

            Console.WriteLine("Hello World!");
        }

        public static void methode0()
        {
            Console.WriteLine("Méthode0 exécutée pas de paramètre");
        }
        public static void methode1(int a)

        {
            Console.WriteLine("Méthode1 exécutée - paramètre = " + a);
        }
    }

    class useDelegate
    {
        public void rappelDelegate(int x,TypeDelegue1 methA,TypeDelegue0 methB)
        {
            methA(x);
            methB();
        }
    }
}
