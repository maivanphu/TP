using System;

namespace MethodeSurcharge_Liaison
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rappelons que le type et le nombre de paramètres sont les seuls éléments qui définissent une surcharge différente d'une autre surcharge, 
                //le type de retour du résultat ne participe pas à la différentiation des surcharges.
            classeB obj = new classeB();
            obj.methode1();
            obj.methode1('a');
            classeB.methode1(45);
      
                      
            
            Console.WriteLine("\n----------------------Liaision tardive-----------------");

            //Le polymorphisme de méthode d'instance déclarée avec la même signature dans une hiérarchie de classes, est le fait que lors de l'exécution, 
            //deux objets de classes différentes dans la hiérarchie invoquent le code différent(celui de leur classe) pour l'appel de la même méthode, 
            //ceci se dénomme la liaison retardée. 

            classeB2 objB = new classeB2();
            objB.methode1(); //methode1- classeB

            Console.WriteLine("-----------------");

            classeA2 objA = new classeA2();
            objA.methode1(); //methode1- classeA
            objA = new classeB2();
            objA.methode1(); //methode1- classeB


            Console.WriteLine("\n----------------------Passage des paramètres-----------------");

            int a = 10, b = a, c = b;
            classeA obj1 = new classeA();

            Console.WriteLine("avant appel : a  = " + a + ", b = " + b + ", c = " + c); //10 10 10
            obj1.methode1(a, out b, ref c); // erreurs signalées ici
            Console.WriteLine("après appel : a  = " + a + ", b = " + b + ", c = " + c); //10 100 100

            Console.ReadLine();
        }
    }

    class classeA
    {
        public virtual void methode1()
        {
            Console.WriteLine("methode1- virtual  - classeA");
        }

        public void methode1(int x, out int y, ref int z)
        {
            x = 100;
            y = 100;
            z = 100;
            Console.WriteLine("dans methode1 : a  = " + x + ", b = " + y + ", c = " + z);
        }

    }
    class classeB : classeA
    {
        public virtual void methode1(char x) //new marche aussi, mais override n'est pas possible car pas meme signature
        {
            Console.WriteLine("methode1- virtual  - classeB  ");
        }
        public static void methode1(int x)
        {
            Console.WriteLine("methode1- static  - classeB ");
        }
    }



    //deux objets de classes différentes dans la hiérarchie invoquent le code différent.
    class classeA2
    {
        public virtual void methode1() //déclaration de méthode à liaison dynamique
        {
            Console.WriteLine("methode1- classeA");
        }
    }
    class classeB2 : classeA2
    {
        public override void methode1() //redéfinition de méthode à liaison dynamique
        {
            Console.WriteLine("methode1- classeB ");
        }
    }

}
