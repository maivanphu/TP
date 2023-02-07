using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace TypeImpliciteVarAnonyme_Lamda_MethodeEx_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Initialiseurs d'objets
            Client personne = new Client { Nom = "Mai", Prenom = "Van phu" }; //Appel implicite de constructeur sans paramètre
            Console.WriteLine(personne.Id);

            Client personne1 = new Client() { Nom = "Mai", Prenom = "Melody" }; //Appel implicite de constructeur sans paramètre
            Console.WriteLine(personne1.Id);

            //2.Initialiseurs de collections
            List<int> ints = new List<int> { 12, 544, -9, 6,2 , -7 , 9, 58, 64, 100, 57, 14, 36, 11, 8 };

            List<Client> Clients = new List<Client>() { personne, personne1, new Client { Nom = "Vu", Prenom = "Thi Ngoc" } };

            //3.  Un type anonyme est une classe comportant uniquement uniquement des propriétés publiques en des propriétés publiques en 
            //lecture seulement(pas de méthodes, ni de champs, ni d’événement)

            var enfant = new { Nom = "VU", Prenom = "Melody", Age = 5 }; //Les variables à type implicite peuvent être affectée par des initialiseurs de type anonyme
            Console.WriteLine("Une propriété d'Un type anonyme :" + enfant.Nom);


            //4. Une λ-expression expression est une fonction anonyme :
            //Une λ-expression  comporte une partie paramètres d’entrée et une partie instructions: 
            //< liste paramètres >  => { < Bloc instructions > }

            // (int a, string k, char c) => k[0] == c ? a + 1 : a * 10

            //(int a, string k, char c) =>
            //{
            //    if (k[0] == c)
            //        return a + 1;
            //    else return a * 10;
            //}


            //Une Lamda Expression peut être assignée à une délégué

            del MyDel = (int a, string k, char c) => {
                if (k[0] == c)
                    return a + 1;
                else return a * 10;
            };

            Console.WriteLine("-----Lamda Expression peut être assignée à une délégué:  " + MyDel(1, "akara", 'a'));
            Console.WriteLine("-----Lamda Expression peut être assignée à une délégué:  " + MyDel(1, "lakara", 'a'));

            //5.Une méthode d’extension  d’un type, est une méthode static spéciale, qui est appelée 
            //dans le code client comme si elle faisait partie des méthodes initiales du type.

            string kk = "alors quoi";
            Console.WriteLine("Utilisation de la méthode d'extention dans la classe String: " + kk.nbrMot());

            //6. LINQ sur une List générique

            IEnumerable<int> paire = from int tt in ints
                                     where tt%2==0
                                     select tt;
            int[] tab = paire.ToArray();
            foreach (var k in tab) Console.WriteLine("Element paire de int[] "+k);

            //LINQ sur un tableau

            int[] tabInt = new int[] { 12, 544, -9, 6, 2, -7, 9, 58, 64, 100 };
            var impaire = from int tt in ints
                    where tt % 2 != 0
                    select tt;
            foreach (var k in impaire.ToList()) Console.WriteLine("Element Impaire de int[] " + k);

            //LINQ des méthodes d'extension

            Console.WriteLine(paire.Max());
            Console.WriteLine(paire.Average());
            Console.WriteLine(paire.Average(n=>2*n));

            var intsSuperieur6 = ints.TakeWhile(x => x > 6);

            foreach (int k in intsSuperieur6) Console.WriteLine("Element jusqu'à >6 : " + k);

            var intsSuperieur6All = from int k in ints  //ints.Select(x => x > 6);
                                    where k > 6
                                    select k;

            foreach (int k in intsSuperieur6All) Console.WriteLine("Element all >6 : " + k);

            var result = 2 / 3;
            Console.WriteLine("var result = 2 / 3 = "+result);

            delString result1 = (int i1, int i2) => (i1 + i2).ToString();
            Console.WriteLine(result1(2,8));
        }
    }

    static class MethodeExt
    {
        //Le mot clef this devant le premier paramètre indique la classe que l’on veut étendre 
        //Nous rajoutons dans la class string une nouvelle méthode
        public static int nbrMot(this string str)
        {
            return str.Length;
        }
    }


    delegate string delString(int x, int y);

    delegate int del(int a, string k, char c);

    class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Id { get; private set; }
        public Client()
        {
            Console.WriteLine("Appel implicite de constructeur");
            //Id ++;
            Id = 9999;
        }
    }
}
