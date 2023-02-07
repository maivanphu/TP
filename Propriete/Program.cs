using System;

namespace Proprietes
{
    class Program
    {
        static void Main(string[] args)
        {
            classeA objA = new classeA();
            objA.nom = "Hardy";
            Console.WriteLine("nom = " + objA.nom);

            objA = new classeB();
            objA.nom = "Laurel";
            Console.WriteLine("nom = " + objA.nom);

            Console.ReadLine();
        }
    }

    class classeA
    {
        private string Fnom = "";
        public virtual string nom
        {
            get { return Fnom; }
            set
            {
                if (value != null) Fnom = value;
                else
                    throw new Exception("nom vide");
            }

        }
    }

    class classeB : classeA
    {
        public override string nom
        //{ get => base.nom; 
        //  set => base.nom = value; 
        //}
        {
            get { return base.nom + "..."; }
            set
            {
                base.nom = value + "//";
            }

        }
    }
}
