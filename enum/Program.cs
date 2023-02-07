using System;


namespace Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ident = { "seul", "marie", "celibataire", "divorce", "veuf" };

            etatCivil etat;
            for (etat = etatCivil.marie; etat <= etatCivil.seul; etat++)
                Console.WriteLine(etat);

            Console.WriteLine("------------");

            for (int i = 0; i < ident.Length; i++)
            {
                etat = strToEnum(ident[i]);
                Console.WriteLine("etat : " + etat);
            }

            Console.WriteLine("------------");


            for (etat = etatCivil.marie; etat <= etatCivil.seul; etat++)
                Console.WriteLine("etat = " + enumToStr(etat));


            Console.WriteLine("------------");

            Console.WriteLine("enum de rang 4 = " + rangEnumToStr(4));

            Console.WriteLine("----------TRANSTYPAGE enum ----------------------");


            couleur salade = couleur.vert;
            int rangSalade = (int)salade;  // transtyper enum --> int


            couleur tomate;

            //tomate = couleur.rouge; // transtyper int --> enum

            //On peut obtenir la couleur de l'objet tomate  selon les 3 variantes de transtypage suivantes
            //  tomate= (couleur)5;
            //tomate = (couleur)(rangSalade + 3);

            tomate = couleur.violet;
            try
            {
                tomate = (couleur)(System.Enum.Parse(typeof(couleur), "rouge"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Ca ne passe pas; " + e.ToString());
            }
            finally
            { /*tomate = couleur.violet; */}
                      

            int rangTomate = (int)tomate;

            Console.WriteLine("couleur de la salade : " + salade);
            Console.WriteLine("rang de la salade = " + rangSalade);
            Console.WriteLine("couleur de la tomate : " + tomate);
            Console.WriteLine("rang de la tomate =  " + rangTomate);
        }

        static etatCivil strToEnum(string val)
        {// convertit un string adéquat en l'enum correspondant
            //etatCivil etat;
            //for (etat = etatCivil.marie; etat <= etatCivil.seul; etat++)
            //    if (val == etat.ToString()) return etat;
            //return etatCivil.celibataire;

            return (etatCivil)System.Enum.Parse(typeof(etatCivil), val);
        }
        static string enumToStr(etatCivil val)
        {// convertit un enum en string
            return val.ToString();
        }
        static string rangEnumToStr(int rang)
        {// donne sous forme de string le nom de l'enum de rang fixé
            //etatCivil etat;
            //for (etat = etatCivil.marie; etat <= etatCivil.seul; etat++)
            //    if (rang == (int)etat) return etat.ToString();

            //return "";

            return System.Enum.GetName(typeof(etatCivil), rang);
        }

    }

    public enum etatCivil
    { marie, celibataire, pacs, veuf, divorce, seul }


    public enum couleur
    { violet, bleu, vert, jaune, orange, rouge }
}
