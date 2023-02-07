using System;

namespace Struct
{

    // Les struct et les class sont différentes en C# , une class est un type reférence alors qu'un struct est un type valeur.
    //Dans le programme de gauche on propose un type valeur Individu, donnez 3 écritures différentes permettant d'initialiser les 3 objets valeur  
    //personne_1,  personne_2 et personne_3 afin d'obtenir pour chacun d'eux l'affichage de son nom et de son prénom comme suit :

    struct individu
    {
        public string nom;
        public string prenom;

        public individu(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }
    
    }



    class Program
    {
        static void Main(string[] args)
        {
            individu personne_1, personne_2, personne_3;

            personne_1 = new individu("Maivu", "Melody");

            Console.WriteLine("identité  : " + personne_1.nom + ", " + personne_1.prenom);

            personne_2 = new individu();
            personne_2.nom = "Thiery";
            personne_2.prenom = "Lazure";
            Console.WriteLine("identité  : " + personne_2.nom + ", " + personne_2.prenom);

            //Enfin et uniquement dans les struct, on peut initialiser les champs d'un objet de type struct sans avoir fait appel à un constructeur. 
            //Dans ce cas, les champs de l'objet struct ne sont pas initialisés et l'objet n'est pas utilisable sauf pour initialiser ses champs : 
            personne_3.nom = "sans";
            personne_3.prenom = "objet";
            Console.WriteLine("identité  : " + personne_3.nom + ", " + personne_3.prenom);


            Console.WriteLine("---------------------------------------------------");

            individu1 perso1 = new individu1();
            individu2 perso2 = new individu2();
            perso1.nom = "struct";
            perso2.nom = "class";

            //1°) Indiquez ce qu'affiche ce programme et expliquez pourquoi le champ nom de perso1 n'a pas changé après appel.
            Console.WriteLine("identité avant appel  : " + perso1.nom);
            Console.WriteLine("identité avant appel  : " + perso2.nom);
           // ChangerNom(perso1, perso2);
            ChangerNom(ref perso1, perso2);
            Console.WriteLine("identité après appel  : " + perso1.nom);
            Console.WriteLine("identité après appel  : " + perso2.nom);




            Console.ReadLine();


        }



        //2°) Fournissez une surcharge de la méthode changerNom qui permette de changer effectivement après appel, 
        //les champs des deux paramètres perso1 net perso2 en utilisant le passage avec ref. 
        //Expliquez comment fonctionne l'appel de cette deuxième méthode en particulier sur le paramètre de type struct. 


        //Dans ce cas lors de l'appel sur personne_1, ce n'est plus l'objet personne_1 qui est recopié dans la pile,
        //mais une référence créée dynamiquement sur cet objet personne_1 par le CLR pour cet usage et donc à travers cette référence,
        //tous les champs de l'objet personne_1 sont modifiables.


        public static void ChangerNom(ref individu1 i1, individu2 i2)
        { 
            i1.nom = "New1";
            i2.nom = "New2";
        }


        public static void ChangerNom(individu1 i1, individu2 i2)
        {
            i1.nom = "New";
            i2.nom = "New";
        }
    }


    struct individu1
    {
        public string nom;
    }
    class individu2
    {
        public string nom;
    }


}
