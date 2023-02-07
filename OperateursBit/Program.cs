using System;

namespace OperateursBit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            System.Console.WriteLine("Imprimer les codes ASSII");

            Console.WriteLine("----------(Char)76=" + (Char)76);

            Char[] Chars = new Char[] { 'a', 'b', 'c', 'd', 'A', 'B', 'C', 'D' };

            foreach (char cc in Chars)
            {
                Console.Write(cc + " - ");
            }

            foreach (char cc in Chars)
            {
                Console.Write((int)cc + " --- ");
            }

            foreach (int cc in Chars)
            {
                Console.Write(cc + " * ");
            }

            int base16 = 0x61;
            Console.WriteLine("\n-------------------Hexadécimal de 61-----------" + base16);
            Console.WriteLine("\n-------------------Hexadécimal de 61-----------" + (Char)base16);

            Console.WriteLine(Convert.ToString(0x61,toBase:16));


            Console.WriteLine("----------------------------------Conversion binaire en décimal----------");

            uint xx = 0b_0101;

            Console.WriteLine("\n uint x = 0b_0101  : " + xx);

            Console.WriteLine("\n----------------------------------Opérateurs bit level----------");

            Console.WriteLine("-----1. Opérateur de complément de bits ~ ");


           uint a = 0b_0000_1111_0000_1111_0000_1111_0000_1100;
            Console.WriteLine("\n uint a = 0b_0000_1111_0000_1111_0000_1111_0000_1100 : " + Convert.ToString(a,toBase:2));

            uint b = ~a;
            Console.WriteLine("~a= "+Convert.ToString(b, toBase: 2));
            // Output:
            // 11110000111100001111000011110011

            Console.WriteLine("Opérateur de décalage vers la droite >>");

           uint x = 0b_1001;

            Console.WriteLine(" uint x = 0b_1001  : " + x);
            Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2),4}");

            uint y = x >> 2;
            Console.WriteLine($"After x >> 2:  {Convert.ToString(y, toBase: 2).PadLeft(4, '0'),4}");
            // Output:
            // Before:   1001
            // After:  0010

            Console.WriteLine("Opérateur de décalage gauche <<");
            uint x1 = 0b_1100_1001_0000_0000_0000_0000_0001_0001;
            Console.WriteLine($"Before: {Convert.ToString(x1, toBase: 2)}");

            uint y1 = x1 << 4;
            Console.WriteLine($"After:  {Convert.ToString(y1, toBase: 2)}");
            // Output:
            // Before: 11001001000000000000000000010001
            // After:      10010000000000000000000100010000



            //Étant donné que les opérateurs de décalage sont définis uniquement pour les types int, uint, long et ulong, 
            //le résultat d’une opération contient toujours au moins 32 bits. 
            //Si l’opérande de partie gauche est d’un autre type intégral (sbyte, byte, short, ushort ou char), sa valeur est convertie en type int,

            Console.WriteLine("Si l’opérande de partie gauche (sbyte, byte, short, ushort ou char), sa valeur est convertie en type int");

            byte a2 = 0b_1111_0001;
            var b2 = a2 << 8;         
            Console.WriteLine("0b_1111_0001 <<8  :"+Convert.ToString(b2, toBase: 2));


            uint a3 = 0b_1111_1000;
            uint b3 = 0b_1001_1101;
            uint c3 = a3 & b3;


            static void Display(uint x) => Console.WriteLine($"{Convert.ToString(x, toBase: 2),4}");
            Display(c3);

            Console.WriteLine("\n opérateur AND logique &");
            Console.WriteLine("\n 0b_1111_1000 &\n 0b_1001_1101 = "+ Convert.ToString(c3, toBase: 2));
            // Output:
            // 10011000

            Console.WriteLine("\n\n opérateur OR logique |");
            Console.WriteLine("\n 0b_1111_1000 | \n 0b_1001_1101 = " + Convert.ToString(0b_1111_1000 | 0b_1001_1101, toBase: 2));


            Console.WriteLine("\n\n opérateur OR exclusif logique ^");
            Console.WriteLine("\n 0b_1111_1000 ^ \n 0b_1001_1101 = " + Convert.ToString(0b_1111_1000 ^ 0b_1001_1101, toBase: 2));
            //l'opérateur logique XOR, ou OU exclusif, peut se définir par la phrase suivante :
            //Le résultat est VRAI si un et un seul des opérandes A et B est VRAI




            Console.WriteLine("\n\n");

             TestBitLevel();

            static void TestBitLevel()
            {
                void Display(int x) => Console.WriteLine($"{Convert.ToString(x, toBase: 2),4}");

                string ReturnDisplay(int x) => Convert.ToString(x, toBase:2);

               

                int x = 5, y = 3, z;
                // 5=00......0101 
                //3= 00......0011
                z = ~x;   // ~5=11......1010 (soit -6 en complément à deux)
                Console.WriteLine("~5  = " + z);
                Display(z);
                Console.WriteLine(ReturnDisplay(z));

                z = x & y; //00......0101 & 00......0011 = 00......001(soit 1 en complément à deux)
                Console.WriteLine("5 & 3 = " + z);
                Display(z);

                z = x | y;  //00......0101 | 00......0011 = 00......111(soit 7 en complément à deux)
                Console.WriteLine("5 | 3 = " + z);
                Display(z);

                z = x ^ y; //00......0101 ^ 00......0011 = 00......0110(soit 6 en complément à deux)
                Console.WriteLine("5 ^ 3 = " + z);
                Display(z);
            }

        }
    }
}
