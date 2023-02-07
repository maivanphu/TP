using System;

namespace TP_Agregation_Heritage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    abstract class Vehicule
    {
        protected int Acier_Kg;
        public Moteur leMoteur;
        public Rivet leRivet;
        public Roue lesRoues;
        public Soudure lesSoudures;
        public string nomSerie;
        public int NumeroSerie;
        const double prixAcier_Kg=2.87;
        public double prixRevient;
        public double prixVenteHT;

        //const double prixAcier_Kg = 2.87; // le prix du Kg d'acier en euros

        //double prixRevient; // vaut : le cout des Rivets + le cout des Soudure + le (prix Acier  x masse d'Acier utilisée)
        //double prixVenteHT; // vaut : le prix de revient majoré de 50%   


        protected abstract void calculPrix();
        protected abstract double coutRivets();
        protected abstract double coutSoudure();

        // calcule le prix de revient et le prix de vente Hors taxe et renvoie le prix de vente TTC calculé par majoration de 33% du prix de vente Hors Taxe.
        public double coutTotal()
        {
           // prixRevient = coutRivets + coutSoudure + prixAcier_Kg * Acier_Kg;
            prixVenteHT = 1.5 * prixRevient;
            return 0.33 * prixVenteHT;
        }

        public Vehicule(string nom, string unMoteur)
        { 
        }

    }

    class Voiture : Vehicule
    {

        public Voiture(string nom, string unMoteur): base(nom,unMoteur)
        { 
        }

        void afficherInfoVehicule()
        {
            Console.WriteLine("Marque de la voiture : " + base.nomSerie);
        }



        protected override void calculPrix()
        {

        }

        protected override double coutRivets()
        { 
            return 1; 
        }

        protected override double coutSoudure()
        { 
            return 1; 
        }


    }


        class Roue
    {
        public string typeRoues;
        public Roue(string categorie)
        {
            typeRoues = categorie;
        }
    }

    class Moteur
    {
        public string typeMoteur;
        public Moteur(string nom)
        {
            typeMoteur = nom;
        }

    }

    class Rivet
    {
        public int NbrRivets;
        public double prixUnit;
        public  Rivet (int nbr)
        {
             NbrRivets=nbr;
        }
    }
    class Soudure
    {
        public int NbrSoudures;
        public double prixUnit;
        public Soudure(int nbr)
        {
            this.NbrSoudures = nbr;
        }
    }
    class NumSerie
    {
        public int numero;
    }
}
