using System;

namespace TestQCM_POO
{
    class Program
    {
        static void Main(string[] args)
        {

            new Derive().Fun(); //output 9 13 

            Index1 i = new Index1(); //While constructing an object referred to by i firstly constructor of index class will be called followed by constructor of index1 class.
            i.Increment();

            Console.WriteLine("Hello World!");




            Console.WriteLine("---------------------------------------!");


            ClasseMere M;
            ClasseFille F;

            M = new ClasseMere();
            F = new ClasseFille();
            Console.WriteLine(M.x);
            Console.WriteLine(F.x);
            //M.meth1(10);
            //M.meth1(10, 5);

            F.meth1(10);
            //F.meth1(10, 5);
           // F.meth1(10, 5,2);

            ClasseMere M1 = new ClasseFille();
            M1.meth1(10);
            // Lors de la compilation de l'instruction M1.meth(10), c'est le code de la méthode 
            //  meth(int a) de la classe ClasseMere qui est lié, car la référence M a été déclarée de
            //type ClasseMere et peu importe dans quelle classe elle a été instanciée(avec comme
            //paramètre par valeur 10; ce qui donnera la valeur 11 au champ x de l'objet M). 


            Console.WriteLine("---------------------------------------!");

            Derived2 d2= new Derived2();
            d2.fun(); //Méthode de la classe mère est appelée car Méthode de la classe fille n'est pas accessible (private par défaut).

        }
    }


     class Baseclass
    {
        public void fun()
        {
            Console.Write("Base class" + " ");
        }
    }
     class Derived1 : Baseclass
    {
         new void fun()
        {
            Console.Write("Derived1 class" + " ");
        }
    }
     class Derived2 : Baseclass
    {
        new void fun()
        {
            Console.Write("Derived2 class" + " ");
        }
    }


    public class ClasseMere
    {
        public int x = 1;
        public void meth1(int a) { x += a; Console.WriteLine("appel Mere meth1(int a):" + x); }
        public void meth1(int a, int b) { x += a * b; Console.WriteLine("appel Mere: meth1(int a, int b)" + x); }
    }
    public class ClasseFille : ClasseMere
    {
        public new void meth1(int a) { x += a * 100; Console.WriteLine("appel Fille meth1(int a):" + x); }
        public void meth1(int a, int b, int c) { x += a * b * c; Console.WriteLine("appel Fille meth1(int a, int b, int c):" + x); } // on peut ajouter new aussi, mais vu que la signature est différent, c'est déjà clair pour le masquage
    }


    class BaseClass
    {
        protected int i = 13;
        public void fun()
        {
            Console.Write("Welcome");
        }
    }

    class Derive : BaseClass
    {
        int i = 9;
        public void Fun()
        {
            Console.WriteLine(i + " " + base.i);

            // [*** Add statement here ***]
            base.fun();
            Console.WriteLine(" to IndiaBIX.com!");
        }


    }


    class Index
    {
        protected int count;
        public Index()
        {
            count = 0;
        }
    }

    class Index1 : Index
    {
        public void Increment()
        {
            base.count = count + 1;
            Console.WriteLine("count=" + count);
        }

    }



}
