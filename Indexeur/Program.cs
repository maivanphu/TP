using System;

namespace Indexeur
{
    class Program
    {
        static void Main(string[] args)
        {

            classeA obj = new classeA();
            Afficher(obj);

            Console.WriteLine("\n-----------Set indexeur-------------");
            obj[3] = "**";
            Afficher(obj);


            Console.WriteLine("\n-----Heritage-------------");

            obj = new classeB();
            Afficher(obj);

            Console.WriteLine("\n-----------Set indexeur-------------");
            obj[3] = "**";
            Afficher(obj);

            Console.WriteLine("\n-----------test-------------");
            int i = 5, j = 2;
            Console.WriteLine(i / j);

            Console.WriteLine("\n-----------accesseur-visibilité depuis classe mere-------------");
            //Console.WriteLine(obj.x); 
            Console.WriteLine(obj.y);
            Console.WriteLine(obj.z);
            // Console.WriteLine(obj.t);
            Console.WriteLine(obj.u);

            Console.WriteLine("\n-----------accesseur-visibilité depuis classe fille-------------");
            classeB objb = new classeB();
            //Console.WriteLine(objb.x); 
            Console.WriteLine(objb.y);
            Console.WriteLine(objb.z);
           // Console.WriteLine(objb.t);
            Console.WriteLine(objb.u);

            Console.WriteLine("\n------------------------");
            objb.TestAcces();
            


        }

        static void Afficher(classeA obj)
        {
            for (int i = 0; i < 5; i++)
            { Console.Write(obj[i]+ ", "); }
        }
    }

    class classeA
    {
        private string[] table = new string[] { "aa", "bb", "cc", "dd", "ee" };
        public virtual string this[int i]
        {
            get { return table[i]; }
            set { table[i] = value; }
        }

        //accesseur-visibilité
        private int x = 100;

        protected internal int y = 100;
        internal int z = 100;

        protected int t = 100;
        public int u = 100;

    }

    class classeB : classeA
    { 
        public override string this[int i]
        {
            get { return base[i]+"..."; }
            set { base[i] = value+"//"; }
        }

        public void TestAcces()
        {
          //  Console.WriteLine(x); pas accessible
            Console.WriteLine(y);
            Console.WriteLine(z);
            Console.WriteLine(t);
            Console.WriteLine(u);

        }
    
    }
}
