using System;

namespace DelegateOuInterface
{

    //C#2008, page 213

    /* Les types delegate et interface sont interchangeables 
 • si l'interface n'a qu'une méthode. En effet, le type delegate est une enveloppe pour une unique méthode alors que l'interface
 peut, elle, définir plusieurs méthodes.
 • si l'aspect multicast du delegate n'est pas utilisé.Cette notion de multicast n'existe en effet pas dans l'interface.

         Note: Events are a prime example for the usage of MulticastDelegates: Abonnement de plusieur gestionnaire d'evenememnt.
    */

    class Program
    {
        static void Main(string[] args)
        {
            int[,] a;
            a = new int[2, 3] ;

            Console.WriteLine("Exécution du délégué Ajouter "+ Delegue.Executer(Delegue.Ajouter, 4, 5));
            Console.WriteLine("Exécution du délégué Soustraire " + Delegue.Executer(Delegue.Soustraire, 4, 5));
                

            // exécution d'un délégué multicast
            Operation op = Delegue.Ajouter;
            op += Delegue.Soustraire;

            Console.WriteLine("Exécution du délégué Multicast " + Delegue.Executer(op, 4, 5));
            op -= Delegue.Soustraire;

            Console.WriteLine("Exécution du délégué Multicast Après avoir retiré une fonction Soustraire" + Delegue.Executer(op, 4, 5));




            Console.WriteLine("--------------------Comparaison avec l'interface!-----------");

            Console.WriteLine("Exécution de méthode de l'interface: Ajouter: " + TestInterface.Executer(new Ajouter(),4,5) );
            Console.WriteLine("Exécution de méthode de l'interface: Soustraire: " + TestInterface.Executer(new Soustraire(), 4, 5));
        }
    }

    // définition d'une prototype de fonction
    public delegate int Operation(int x, int y);

    class Delegue
    {
        Single s;
        float f = new float();//new Single();



        public static int Ajouter (int x, int y)
        {
            return x + y;
        }

        public static int Soustraire(int x, int y)
        {
            return x - y;
        }

        //Execution d'un délégué
        //permet de passer à la méthode Execute, différentes méthodes. Cette propriété de polymorphisme peut être obtenue avec l'interface
        public static int Executer(Operation op, int x, int y)
        {
            return op(x, y);
        }

    }

    public interface IOperation
    {
        int Operation(int x, int y);
    }

    class Ajouter : IOperation
    {
       public  int Operation(int x, int y)
        {
            Console.WriteLine("Méthode Operation de classe Ajouter(" + x + "," + y + ")");
            return x + y;
        }
    }


    class Soustraire: IOperation
    {
        public int Operation(int x, int y)
        {
            Console.WriteLine("Méthode Operation de classe Soustraire(" + x + "," + y + ")");
            return x - y;
        }
    }

    class TestInterface
    {
        public static int Executer(IOperation op, int x, int y)
        {
            return op.Operation(x, y);
        }
            
      }


}
