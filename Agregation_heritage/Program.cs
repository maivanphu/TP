using System;

namespace Agregation_heritage
{
    class Program
    {
        static void Main(string[] args)
        {
            CompteRemunere3 cptBank = new CompteRemunere3(100);
            //CompteRemunere2 cptBank = new CompteRemunere2(100);
            //CompteRemunere1 cptBank = new CompteRemunere1(100);
            Console.WriteLine("Ouverture d'un compte rémunéré =  " + cptBank.avoirActuel() + " $");
            cptBank.ajouter(50);
            Console.WriteLine("compte rémunéré après ajout de 50 $=  " + cptBank.avoirActuel() + " $");
            cptBank.retirer(50);
            Console.WriteLine("compte rémunéré après retrait de 50 $=  " + cptBank.avoirActuel() + " $");

            Console.ReadLine();
        }
    }


    class Compte
    {
        private double etat = 0;
       // protected double etat = 0;
        public Compte(double somme)
        {
            etat = somme;
        }
        public virtual void ajouter(double somme)
        {
            etat += somme;
        }
        public virtual void retirer(double somme)
        {
            etat -= somme;
        }
        public double avoirActuel()
        {
            return etat;
        }
    }

    class CompteRemunere3 : Compte
    {    
        public CompteRemunere3(double somme) : base(somme)
        {
        }
        public override void ajouter(double somme)
        {
            // etat += somme*1.01;
            base.ajouter(somme * 1.01);
        }

        public override void retirer(double somme)
        {
            //etat -= somme*1.02;
            base.retirer(somme * 1.02);
        }
    }
    class CompteRemunere2:Compte
    {
        public CompteRemunere2(double somme):base(somme)
        {         
        }

        public new void ajouter(double somme)
        {
            // etat += somme*1.01;
            base.ajouter(somme * 1.01);
        }

        public new void retirer(double somme)
        {
            //etat -= somme*1.02;
            base.retirer(somme * 1.02);
        }
        //public double avoirActuel()
        //{
        //    return etat;
        //}
    }

    class CompteRemunere1 // à remplacer la classe CompteRemunere contenant un Compte par la  classe CompteRemunere  héritant de Compte 
    {
        private Compte unCompte;

        public CompteRemunere1(double somme)
        {
            unCompte = new Compte(somme);
        }
        public void ajouter(double somme)
        {
            unCompte.ajouter(somme * 1.01);
        }
        public void retirer(double somme)
        {
            unCompte.retirer(somme * 1.02);
        }
        public double avoirActuel()
        {
            return unCompte.avoirActuel();
        }
    }

}
