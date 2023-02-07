using System;

namespace ApplicationsSimples
{
    class Program
    {

        //unsafe static void Main(string[] args)
        //{
        //    var number = 100;
        //    int* numberPtr = &number;
        //    Console.WriteLine("The value of variable: {0}", number);
        //    Console.WriteLine("The value of variable using pointer: {0}", numberPtr->ToString());
        //    Console.WriteLine("The address of variable : {0}", (int)numberPtr);
        //    Console.ReadLine();
        //}

        static void Main(string[] args)
        {
            //Sample s1 = new Sample();
            //s1.SetData(10, 5.4f);
            //s1.Display();

            Sample s = new Sample();
            s.index = 20;
            Sample.fun(1, 5);
            s.fun(1, 5);

            /*Exo1 inverse d'une suite de caractère dans un tableau par 
 permutation des deux extrêmes */

            char[] chars =  { 'a', 'b', 'c', 'd','e','f','g' };

            Console.WriteLine("Suite de charactère avant l'inverse: " + new string(chars));

            int i, j;

            char UnChar;
            for (i = 0, j = chars.Length-1; i < j; i++, j--)
            {
                UnChar = chars[i];
                chars[i] = chars[j];
                chars[j] = UnChar;            
            }

            Console.WriteLine("Suite de charactère APRES l'inverse: " + new string(chars));




            Console.WriteLine("-----------------"+ args);


            //Exo2 recherche séquentielle dans un tableau

            int[] tab = { 7, 8, 9, -8, -1,3,44 };

            int k;
            int EltCherche=-80;
            for ( k = 0; k < tab.Length - 1; k++)
                if (tab[k] == EltCherche)
                {
                    Console.WriteLine("3 se trouve au rang :" + k);
                    break;
                }

            if (k == tab.Length)
                Console.WriteLine("pas trouvé....");


        }
    }

    //class Sample
    //{
    //    int i;
    //    Single j;
    //    public void SetData(int i, Single j)
    //    {
    //        //this.i = i;
    //        //this.j = j;
    //        i = i;
    //        j = j;
    //    }
    //    public void Display()
    //    {
    //        Console.WriteLine(i + " " + j);
    //    }
    //}

    class Sample
    {
        public int index;
        public int[] arr = new int[10];

        public void fun(int i, int val)
        {
            arr[i] = val;
        }
    }

}
