using System;
using System.Collections;

namespace NotesEtDictionnaryEntry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            EtudMasterCCI unEtudiant = new EtudMasterCCI();
            unEtudiant.loadNotes();

            Console.WriteLine("-------");

            foreach (DictionaryEntry k in unEtudiant.Notes)
                Console.WriteLine(k.Value);

            unEtudiant["EU3"] = 16.5f;

            Console.WriteLine("-------");


            for (int k= 0; k< unEtudiant.LengthDic;k++)
                Console.WriteLine(unEtudiant[k]);

            Console.WriteLine("-------");

            Console.WriteLine(unEtudiant["EU2"]);

            PromoEtudMasterCCI promo = new PromoEtudMasterCCI();
            promo.Add(unEtudiant);

            Console.ReadLine();
        }
    }

    class EtudMasterCCI
    {
        //  private DictionaryEntry[] notes = new DictionaryEntry[8];
        public DictionaryEntry[] Notes { get; set; }
        public string Nom {get;set;}
        public int Identifiant { get; set; }


        private Random alea = new Random();

        public int LengthDic
        { 
            get{ return Notes.Length; }
        }

        public float this[int index]
        {
            //get { return float( Notes[index].Value); }
            get { return (float)Notes[index].Value; }

        }

        public float this[string UV]
        {
            get {

                foreach (DictionaryEntry note in Notes)
                    if (UV == (string)note.Key)
                        return (float)note.Value;
                //else
                //        return -1.00f;

                return -1.00f;
            }

            set {
                //foreach (DictionaryEntry note in Notes)
                //    if (UV == (string)note.Key)
                //        note.Value=value;

                for (int k = 0; k < Notes.Length; k++)
                    if (UV == (string)Notes[k].Key)
                        Notes[k].Value = value;

            }      
        
        }

        public EtudMasterCCI()
        {
             loadNotes();
        }

        public EtudMasterCCI(string nom, int identifiant)
        {
           // loadNotes();
        }

        public void loadNotes()
        {

           Notes= new DictionaryEntry[5];
            Notes[0] = new DictionaryEntry("EU1", (float) Math.Round(alea.NextDouble() * 10,2)) ;
            Notes[1] = new DictionaryEntry("EU2", (float)Math.Round(alea.NextDouble() * 10,2));
            Notes[2] = new DictionaryEntry("EU3", (float)Math.Round(alea.NextDouble() * 10,2));
            Notes[3] = new DictionaryEntry("EU4", (float)Math.Round(alea.NextDouble() * 10,2));
            Notes[4] = new DictionaryEntry("EU5", (float)Math.Round(alea.NextDouble() * 10,2));
        }
    }

    class PromoEtudMasterCCI: ArrayList
    {
        //public ArrayList list = new ArrayList();

        public EtudMasterCCI this[string nom]
        {
            get {
                foreach (EtudMasterCCI etu in this)
                    if (etu.Nom == nom)
                    {                        
                        return etu;
                        break;
                    }

                return null;
            }
        }

        public void saisieNote(string nom, string UV, float note)
        {
            EtudMasterCCI unEtudiant = new EtudMasterCCI();

            EtudMasterCCI etud = this[nom];
        }
    }

    class PromoEtudMasterCCISeul// : ArrayList
    {

        public PromoEtudMasterCCISeul()
        { 
        
        }

        public ArrayList list { get;set; }

        public EtudMasterCCI this[string nom]
        {
            get
            {
                foreach (EtudMasterCCI etu in this)
                    if (etu.Nom == nom)
                    {
                        return etu;
                        break;
                    }

                return null;
            }
        }

        public void saisieNote(string nom, string UV, float note)
        {
            EtudMasterCCI unEtudiant = new EtudMasterCCI();

            EtudMasterCCI etud = this[nom];
        }
    }
}
