using System;

namespace EventInTableau
{
    //1-- classe d'informations personnalisées sur l'événement :
    public class ChangerEventArgs : EventArgs
    {
        public int infoRang;
        public string oldValue, newValue;
        public ChangerEventArgs(int rang, string oldStr, string newStr)
        {
            infoRang = rang;
            oldValue = oldStr;
            newValue = newStr;
        }
    }
    //2-- déclaration du type délégation normalisé :
    public delegate void ChangerEventHandler(object sender, ChangerEventArgs e);

    public class TableEvent
    {
        private string[] table =
        {
            "aa","bb","cc","dd","ee"
        };
        public virtual string this[int index]
        {
            get
            {
                return table[index];
            }
            set
            {
                OnChanger(index, table[index], value);
                table[index] = value;
            }
        }
        //3-- déclaration d'une référence event de type délégué :
        public event ChangerEventHandler Changer;

        //4.2-- méthode publique qui lance l'événement :
        public void OnChanger(int rang, string oldStr, string newStr)
        {
            ChangerEventArgs evt = new ChangerEventArgs(rang, oldStr, newStr);
            OnChange(this, evt);
        }

        //4.1 méthode protégée qui déclenche l'événement :
        protected virtual void OnChange(object sender, ChangerEventArgs e)
        {
            if (Changer != null) Changer(sender, e);
        }
    }

    class Exercice
    {
        static public void Changer_liste(object sender, ChangerEventArgs e)
        {
            //5-- gestionnaire d'événement Changer: méthode de classe
            System.Console.WriteLine("\nmodification dans la liste au rang : " + e.infoRang);
            System.Console.WriteLine("ancienne valeur =  " + e.oldValue + ", changée en : " + e.newValue);
        }

        public static void Main()
        {
            TableEvent liste = new TableEvent();
            //-- abonnement au gestionnaire :
            liste.Changer += new ChangerEventHandler(Changer_liste);
            liste[0] = "xxxx";
            liste[4] = "yyy";
            Console.ReadLine();
        }
    }

}
