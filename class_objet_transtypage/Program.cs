using System;

namespace class_objet_transtypage
{
    //this: objet constructeur dans la meme classe

    //base(): constructeur héritage de classe mère

    class Individu
    {
        public string nom;
        public string prenom;
        public int age;
        public Individu() 
        { 
            this.age = 50; 
        }
        public Individu(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
            //this.age = 0;
        }

        //public Individu(string nom, string prenom,int age)
        //{
        //    this.nom = nom;
        //    this.prenom = prenom;
        //    this.age = age;
        //}

        public Individu(string nom, string prenom, int age):this(nom,prenom)
        {
            //this.nom = nom;
            //this.prenom = prenom;
            this.age = age;
        }

        public void Afficher()
        {
            Console.WriteLine("Individu: "+ nom + " " + prenom + " age " + age);
        }

    }

    class etudiant:Individu
    {
        public string universite;
        public int annee;
        public etudiant(string nom, string prenom, int age):base(nom,prenom,age)
        { }
        public etudiant(string nom, string prenom, int age,string universite, int annee) : base(nom,prenom,age)
        {
            this.universite = universite;
            this.annee = annee;
            //base.Afficher();
        }

        public new void  Afficher()
        {
            base.Afficher();
         
            Console.WriteLine("Etudiant: "+universite + " année " + this.annee);         
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

          //  Complétez le code des 3 surcharges du constructeur de la classe Individu de telle manière que 
                //lorsque le programme de gauche s'exécute on obtienne l'affichage qui suit: (age correspondant des 3 personnes: 50,0,32)

            Individu personne_1, personne_2, personne_3;

            personne_1 = new Individu();
            personne_1.nom = "Vernes";
            personne_1.prenom = "Jules";
            Console.WriteLine("identité  : " + personne_1.nom + ", " + personne_1.prenom + ", age : " + personne_1.age);

            personne_2 = new Individu("Hugo", "Victor");
            Console.WriteLine("identité  : " + personne_2.nom + ", " + personne_2.prenom + ", age : " + personne_2.age);

            personne_3 = new Individu("Dantes", "Edmond", 32);
            Console.WriteLine("identité  : " + personne_3.nom + ", " + personne_3.prenom + ", age : " + personne_3.age);



            Console.WriteLine("--------------test classe fille avec base----------------------");

            etudiant unEtudiant = new etudiant("mai","vanphu",35,"Université de Tour",2010);
            unEtudiant.Afficher();

            // Console.WriteLine(unEtudiant.universite);



            Console.WriteLine("--------------Transtypage----------------------");

            Timbre marianne = new Timbre();
            TimbreCollection ceres = new TimbreCollection();
            Console.WriteLine("prix d'une marianne : " + marianne.prix());
            Console.WriteLine("prix d'une ceres : " + ceres.prix());

            Timbre ordinaire = new Timbre();
            Console.WriteLine("prix d'un timbre ordinaire : " + ordinaire.prix());

            marianne = ceres;
            Console.WriteLine("prix d'une marianne pointant vers un ceres : " + marianne.prix());

            try
            {
                ceres = (TimbreCollection)ordinaire; // il refuse le maquillage du timbre ordinaire en timbre ceres.        
                Console.WriteLine("prix d'un timbre oridinaire maquillé en ceres : " + ceres.prix());
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("conversion impossible!"+e.ToString());
            }

            ordinaire = new TimbreCollection();
            Console.WriteLine("prix d'un timbre oridinaire maquillé en ceres : " + ordinaire.prix());



            Console.WriteLine("--------------Interface----------------------");
            Animal poule, crotal, chat;
            poule = new Animal(categorie.oiseau);
            crotal = new Animal(categorie.serpent);
            chat = new Animal(categorie.mammifere);

            Console.WriteLine("une poule est un " + poule.ordre.ToString() + " et possède des " + poule.typePeau);
            Console.WriteLine("un crotal est un " + crotal.ordre.ToString() + " et possède des " + crotal.typePeau);
            Console.WriteLine("une chat est un " + chat.ordre.ToString() + " et possède des " + chat.typePeau);


            Console.ReadLine();
        }
    }

    class Timbre
    {
        public virtual string prix()
        { return "1 euro"; }
    }

    class TimbreCollection : Timbre
    {
        public override string prix()
        {
            return "1000 euros";
            //return base.prix();
        }
    }

    public enum genre
    { ecailles, plumes, poils }
    public enum categorie
    { mammifere, oiseau, serpent }

    public interface Icaracteres
    {
        genre typePeau { get; }
        categorie ordre { get; set; }
    }

    //        Implantez complètement la classe Animal en sachant que
    //a) la propriété ordre ne fait qu'accéder directement en lecture et en écriture au champ privé catAnimal.
    //b) la propriété typePeau renvoie le genre de peau de l'animal selon sa catégorie (selon la valeur de la propriété ordre).

    public class Animal : Icaracteres
    {
        private categorie catAnimal;
        public Animal(categorie catAnimal)
        {
            this.catAnimal = catAnimal;
        }

        public categorie ordre
        {
            get { return catAnimal; }
            set { catAnimal = value; }
        }

       // categorie Icaracteres.ordre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

         public genre typePeau
        {
            get {

                switch (catAnimal)
                {
                    case categorie.mammifere: return genre.poils;
                    case categorie.oiseau: return genre.plumes;
                    case categorie.serpent: return genre.ecailles;
                    default: return genre.ecailles;
                }
            }
        }

       // genre Icaracteres.Typepeau => throw new NotImplementedException();
    }



}
