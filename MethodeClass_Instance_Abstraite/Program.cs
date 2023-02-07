using System;

namespace MethodeClass_Instance_Abstraite
{
    class Program
    {
        public static string nom = "Exercice";
        public static void methClasse()
        {
            Console.WriteLine("méthode de la  classe : " + nom);
        }


        /// <summary>
        /// methode d'instance
        /// </summary>
        public string nomi = "Exercicei";
        public void methClassei()
        {
            Console.WriteLine("méthode de la classe : " + nomi);
        }
        public void methodeInstance()
        {
            //.......appeler methClasse et afficher le membre nom de classeA
            Console.WriteLine(classeA.nom);
            classeA.methClasse();

            //.......appeler de 2 façons methClasse et afficher le membre nom de Exercice
            Console.WriteLine(this.nomi);
            this.methClassei();
        }


        static void Main(string[] args)
        {
            classeA obj = new classeA();
            Console.WriteLine(classeA.nom);
            classeA.methClasse();

            Console.WriteLine(nom);
            methClasse();

            Console.WriteLine(Program.nom);
            Program.methClasse();
        
            Console.WriteLine("\n--------------methode d'instance---------------");

            Program pr = new Program();
            pr.methodeInstance();


            Console.WriteLine("\n--------------methode abstraite---------------");
            classeB obj1 = new classeB();
            obj1.methInstance1();
            obj1.methInstance2();

        }
    }

    class classeA
    {
        public static string nom="ClasseA";
        public static void methClasse()
        {
            Console.WriteLine("méthode de la  classe : " + nom);
        }

    }



    abstract class classeA1
    {
        public abstract void methInstance1();
    }

    interface InterfA
    {
        void methInstance2();
    }

    class classeB : classeA1, InterfA
    {
        public override void methInstance1()
        {
            Console.WriteLine("méthode d'instance1");
        }
        public void methInstance2() // ou virtuel ou new
        {
            Console.WriteLine("méthode d'instance2");
        }
    }



}
