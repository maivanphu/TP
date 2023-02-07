using System;

namespace PolymorphieLiaisonStatique
{
    class Program
    {
        static void Main(string[] args)
        {
            ClasseMere M;
            M = new ClasseMere();
            M.Methode(100);

            Console.WriteLine("Classe mère; a="+M.a);

            ClasseFille F;
            F = new ClasseFille();
            F.Methode(100);
            Console.WriteLine("Classe Fille; a=" + F.a);

            Console.WriteLine("Hello World!");
        }
    }


    public class ClasseMere
    {
        public int a = 1;
        public void Methode(int b)
        {
            a += b;
        }
    }

    public class ClasseFille: ClasseMere
    {
        public void Methode(int b)
        {
            a += b*10;
        }
    }
}
