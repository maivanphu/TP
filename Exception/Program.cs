using System;

namespace Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Debut du programme");
            Action ac = new Action();

            try
            {
                ac.methode();
            }
            catch (IndexOutOfRangeException a)
            {
                Console.WriteLine("Interception IndexOutOfRangeException " + a);
            }
            //catch (ArithmeticException E)
            //{
            //    Console.WriteLine("Interception ArithmeticException");
            //}
            catch (DivideByZeroException d)
            {
                Console.WriteLine("Interception DivideByZeroException "+d);
            }
            catch (ArithmeticException E)
            {
                Console.WriteLine("Interception ArithmeticException");
            }


            Console.WriteLine("Fin du programme");

            Console.ReadLine();
        }
    }


    class Action
    {
        public void methode()
        {
            throw new DivideByZeroException("calcul impossible");
            throw new IndexOutOfRangeException("indice hors des limites");

            //Une clause throw lève une exception, puis fonctionne comme un return en arrêtant la méthode en cours pour renvoyer cette exception
            //Donc la première instruction lève  et la seconde instruction ne peut jamais être exécutée, ce que décèle le compilateur
        }
    }
}
