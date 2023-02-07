using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using System.Windows.Forms;

class TradExprParPostFixe
{
    private Pile unePile;
    private string Phrase, Traduc, car;
    private char CarLu;
    private int NumCar;
    private List<char> Operandes, Operateurs;
    private int[] Prior = new int[6];
    private bool FinTraduc;
    private const string sentinelle = "#";

    private int operToInt(char oper)
    {
        switch (oper)
        {
            case '+': return 0;
            case '/': return 1;
            case '*': return 2;
            case '^': return 3;
            case '!': return 4;
            default: return 0;
        }
    }

    private void CarSuivant()
    {
        NumCar++;
        CarLu = Phrase[NumCar];
    }

    private void Voir(int n)
    {
        unePile.Afficher();
    }

    public TradExprParPostFixe()
    {
        Prior[operToInt('+')] = 1;
        Prior[operToInt('-')] = 1;
        Prior[operToInt('/')] = 2;
        Prior[operToInt('*')] = 2;
        Prior[operToInt('^')] = 3;
        Prior[operToInt('!')] = 4;
        Operandes = new List<char>();
        for (char car = 'a'; car <= 'z'; car++)
            Operandes.Add(car);
        for (char car = '0'; car <= '9'; car++)
            Operandes.Add(car);
        Operateurs = new List<char>(new char[]
       {
    '+', '-', '/', '*', '^', '!'
       }
       );
        NumCar = -1;
        Traduc = "";
        FinTraduc = false;
        unePile = new Pile();
    }

    public string TraduitEnPostFixe(string Expr)
    /*opérandes possibles: a,b,...,z,0,1,...,9
    opérateurs possibles: +,-,/,*,^,!
    +,- : prior = 1   
    /,* : prior = 2   
    ^ : prior = 3   
    ! : prior = 4
    */
    {
        Phrase = Expr + sentinelle;
        CarSuivant();
        while (!FinTraduc)
        {
            if (Operandes.Contains(CarLu))
            {
                Traduc = Traduc + CarLu;
                //Console.WriteLine('Traduc1 = '+Traduc);
                //Voir(1);
                CarSuivant();
            }
            else
             if (CarLu == '(')
            {
                unePile.Empiler((Convert.ToString(CarLu)));
                //Voir(2);
                CarSuivant();
            }
            else
              if (Operateurs.Contains(CarLu))
            {
                if (unePile.premier() == "(" | unePile.Est_Vide())
                {
                    unePile.Empiler(Convert.ToString(CarLu));
                    //Voir(3);
                    CarSuivant();
                }
                else //sommet de pile est un opérateur
                 if (Prior[operToInt(CarLu)] > Prior[operToInt(unePile.premier()[0])])
                {
                    unePile.Empiler(Convert.ToString(CarLu));
                    //Voir(4);
                    CarSuivant();
                }
                else
                {
                    Traduc = Traduc + unePile.premier();
                    //Console.WriteLine('Traduc2 = '+Traduc);
                    //Voir(5);
                    unePile.Depiler(ref car);
                }
            }
            else
               if (CarLu == ')')
            {
                if (Operateurs.Contains(unePile.premier()[0]))
                {
                    Traduc = Traduc + unePile.premier();
                    //Console.WriteLine('Traduc3 = '+Traduc);
                    //Voir(6);
                    unePile.Depiler(ref car);
                }
                else //sommet de pile = '('
                {
                    unePile.Depiler(ref car);
                    //Voir(7);
                    CarSuivant();
                }
            }
            else
                if (Convert.ToString(CarLu) == sentinelle)
            {
                if (!unePile.Est_Vide())
                {
                    Traduc = Traduc + unePile.premier();
                    //Console.WriteLine('Traduc4 = '+Traduc);
                    //Voir(8);
                    unePile.Depiler(ref car);
                    //Voir(9);
                }
                else
                    FinTraduc = true;
            }
        }
        //Console.WriteLine('Traduc = '+Traduc);
        return Traduc;
    }
}

class GenererCode
{
    private StreamWriter progexe;
    private StreamWriter prog;
    private int[] tableSymbole = new int[26];
    private int numCode;
    private int adrInit; // adresse initiale de la table des symboles

    private void gener(char car, ref string code, ref int numCode)
    {
        if (Globale.ensChiffre.Contains(car))
        {
            numCode = 101;
            code = Globale.tableCode[numCode - 100] + ' ' + car;
        }
        else
         if (Globale.ensLettre.Contains(car))
        {
            numCode = 100;
            code = Globale.tableCode[numCode - 100] + ' ' + car;
        }
        else
          if (Globale.ensOperat.Contains(car))
        {
            switch (car)
            {
                case '+':
                    numCode = 102;
                    break;
                case '-':
                    numCode = 103;
                    break;
                case '*':
                    numCode = 104;
                    break;
                case '/':
                    numCode = 105;
                    break;
                case '!':
                    numCode = 106;
                    break;
                case '^':
                    numCode = 107;
                    break;
            }
            code = Globale.tableCode[numCode - 100] + ' ';
        }
    }

    private string formatNumInstr(int num)
    {
        // formate le numéro de ligne
        string strNum = Convert.ToString(num);
        if (num <= 9 & num >= 0)
            return strNum + "   : ";
        else
        if (num <= 99 & num >= 10)
            return strNum + "  : ";
        else
         if (num <= 999 & num >= 100)
            return strNum + " : ";
        else
            return strNum + ": ";
    }

    public GenererCode()
    {
        // simulation d'adressage Mémoire centrale pour les variables :
        adrInit = 1000;
        for (char car = 'a'; car <= 'z'; car++)
        {
            tableSymbole[car - 'a'] = adrInit;
            adrInit++;
        }
    }

    public void generFichiercode(string ch)
    {
        int lg = ch.Length;
        string code = "", adrMem, codeCible;
        List<char> Ensvar = new List<char>();
        progexe = new StreamWriter(Globale.fichierExec);
        prog = new StreamWriter(Globale.fichierCode);
        prog.WriteLine("======== ligne source ========");
        prog.WriteLine("");
        prog.WriteLine(ch);
        prog.WriteLine("");
        prog.WriteLine("======== Machine MAP ========");
        prog.WriteLine("");
        for (int i = 0; i < lg; i++)
        {
            gener(ch[i], ref code, ref numCode);
            adrMem = "";
            codeCible = "";
            if (Globale.ensLettre.Contains(ch[i]) | Globale.ensChiffre.Contains(ch[i]))
            {
                if (Globale.ensLettre.Contains(ch[i]))
                {
                    adrMem = " [$" + Convert.ToString(tableSymbole[ch[i] - 'a']) + "]";
                    Ensvar.Add(ch[i]);
                    codeCible = "@" + Convert.ToString(tableSymbole[ch[i] - 'a']);
                }
                if (Globale.ensChiffre.Contains(ch[i]))
                    codeCible = "@" + ch[i];
            }
            prog.WriteLine(formatNumInstr(i) + code + adrMem);
            progexe.WriteLine(Convert.ToString(numCode) + codeCible);
        }
        prog.WriteLine("");
        prog.WriteLine("===== Table des symboles =====");
        prog.WriteLine("");
        prog.WriteLine("var   adresse");
        for (char k = 'a'; k <= 'z'; k++)
        {
            if (Ensvar.Contains(k))
            {
                prog.WriteLine(" " + k + "  |  " + tableSymbole[k - 'a']);
                progexe.WriteLine(k + "@" + tableSymbole[k - 'a']);
            }
        }
        prog.Close();
        progexe.Close();
    }
}

class Desassembler
{
    private StreamReader progexe;
    private StreamWriter progDASM;
    private int[] tableSymbole = new int[26];
    private string ligneInstrDASM(string Ligne)
    {
        int adresse;
        char varChar;
        string strVal;
        int numCode = Convert.ToInt32(Ligne.Substring(0, 3));//code de 100 à 107
        string strDASM = Globale.tableCode[numCode - 100];
        if (Ligne.Length > 3)
            if (numCode == 100)// PUSH 10xx     
            {
                adresse = Convert.ToInt32(Ligne.Substring(4, Ligne.Length - 4));
                varChar = tabSymCross(adresse);
                strDASM = strDASM + ' ' + varChar;
            }
            else // code = 101 => PUSH #val     
            {
                strVal = Ligne.Substring(4, Ligne.Length - 4);
                strDASM = strDASM + ' ' + strVal;
            }
        return strDASM;
    }

    private void chargerTabSymDASM()
    {
        progexe = new StreamReader(Globale.fichierExec);
        string ligne;
        while ((ligne = progexe.ReadLine()) != null)
        {
            if (Globale.ensLettre.Contains(ligne[0]))
                tableSymbole[ligne[0] - 'a'] = Convert.ToInt32(ligne.Substring(2, ligne.Length - 2));
        }
        progexe.Close();
    }

    public void codeDASM()
    {
        progexe = new StreamReader(Globale.fichierExec);
        progDASM = new StreamWriter(Globale.fichierDASM);
        string ligne;
        while ((ligne = progexe.ReadLine()) != null)
        {
            if (Globale.ensChiffre.Contains(ligne[0]))
                progDASM.WriteLine(ligneInstrDASM(ligne));
            else
                if (Globale.ensLettre.Contains(ligne[0]))
                break;
            else
                Console.WriteLine("code exécutable corrompu desassemblage interrompu!");
        }
        progexe.Close();
        progDASM.Close();
    }

    public char tabSymCross(int adr)
    {
        for (char car = 'a'; car <= 'z'; car++)
            if (tableSymbole[car - 'a'] == adr)
                return car;
        return '#';
    }

    public Desassembler()
    {
        chargerTabSymDASM();
    }
}

class MachineMAP
{
    private StreamReader progexe;
    private int[] tableSymbole = new int[26];// adresses des variables
    private int[] tableVal = new int[26];// valeurs effectives des variables
    private Pile MAPpile = new Pile();

    private void chargerTabSym()
    {
        progexe = new StreamReader(Globale.fichierExec);
        string ligne;
        while ((ligne = progexe.ReadLine()) != null)
        {
            if (Globale.ensLettre.Contains(ligne[0]))
            {
                Console.Write("valeur de la variable '" + ligne[0] + "' = ");
                tableSymbole[ligne[0] - 'a'] = Convert.ToInt32(ligne.Substring(2, ligne.Length - 2));
                int valEntree = Convert.ToInt32(Console.ReadLine());
                tableVal[ligne[0] - 'a'] = valEntree;
            }
        }
        progexe.Close();
    }

    private int puiss(int x, int n)
    {
        int power = 1;
        for (int i = 1; i <= n; i++)
            power *= x;
        return power;
    }

    private int reste(int a, int b)
    {
        return a % b;
    }

    private char tabSymCross(int adr)
    {
        for (char car = 'a'; car <= 'z'; car++)
            if (tableSymbole[car - 'a'] == adr)
                return car;
        return '#';
    }

    public void execute(ref int valeurExpr)
    {
        string Ligne, car1 = "", car2 = "";
        int numCode, adresse;
        int val1, val2;
        char varChar;
        chargerTabSym();
        progexe = new StreamReader(Globale.fichierExec);
        while ((Ligne = progexe.ReadLine()) != null)
        {
            if (Globale.ensLettre.Contains(Ligne[0]))
                break;
            numCode = Convert.ToInt32(Ligne.Substring(0, 3));
            if (Ligne.Length > 3)
            {
                if (numCode == 100)//PUSH 10xx
                {
                    adresse = Convert.ToInt32(Ligne.Substring(4, Ligne.Length - 4));
                    varChar = tabSymCross(adresse);
                    MAPpile.Empiler(Convert.ToString((char)(tableVal[varChar - 'a'] + '0')));
                }
                else// code = 101 => PUSH #val      
                {
                    varChar = Ligne.Substring(4, Ligne.Length - 4)[0];
                    MAPpile.Empiler(Convert.ToString(varChar));
                }
            }
            else
                switch (numCode)
                {
                    case 102:

                        MAPpile.Depiler(ref car1);
                        MAPpile.Depiler(ref car2);
                        val1 = Convert.ToInt32(car1);
                        val2 = Convert.ToInt32(car2);
                        MAPpile.Empiler(Convert.ToString(val1 + val2));
                        break;

                    case 103:

                        MAPpile.Depiler(ref car1);
                        MAPpile.Depiler(ref car2);
                        val1 = Convert.ToInt32(car1);
                        val2 = Convert.ToInt32(car2);
                        MAPpile.Empiler(Convert.ToString(val2 - val1));
                        break;

                    case 104:

                        MAPpile.Depiler(ref car1);
                        MAPpile.Depiler(ref car2);
                        val1 = Convert.ToInt32(car1);
                        val2 = Convert.ToInt32(car2);
                        MAPpile.Empiler(Convert.ToString(val1 * val2));
                        break;

                    case 105:

                        MAPpile.Depiler(ref car1);
                        MAPpile.Depiler(ref car2);
                        val1 = Convert.ToInt32(car1);
                        val2 = Convert.ToInt32(car2);
                        MAPpile.Empiler(Convert.ToString(val2 / val1));
                        break;

                    case 106:

                        MAPpile.Depiler(ref car1);
                        MAPpile.Depiler(ref car2);
                        val1 = Convert.ToInt32(car1);
                        val2 = Convert.ToInt32(car2);
                        MAPpile.Empiler(Convert.ToString(reste(val2, val1)));
                        break;

                    case 107:

                        MAPpile.Depiler(ref car1);
                        MAPpile.Depiler(ref car2);
                        val1 = Convert.ToInt32(car1);
                        val2 = Convert.ToInt32(car2);
                        MAPpile.Empiler(Convert.ToString(puiss(val2, val1)));
                        break;

                    default:
                        Console.WriteLine("erreur num de code incorrect");
                        break;

                }
        }
        progexe.Close();
        MAPpile.Depiler(ref car1);
        valeurExpr = Convert.ToInt32(car1);
    }
}

public static class Globale
{
    public static string fichierCode = "codegenere.txt";
    public static string fichierExec = "codegenere.exec";
    public static string fichierDASM = "codeDASM.txt";
    public static string[] tableCode = new string[8] { "PUSH", "PUSH #", "ADC", "SBC", "MUL", "DIV", "MOD", "PUISS" };
    //de 100 à 107
    public static List<char> ensChiffre;
    public static List<char> ensLettre;// = ['a'..'z'];
    public static List<char> ensOperat;//

    static Globale()
    {// Les constructeurs statiques
        ensChiffre = new List<char>(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        ensOperat = new List<char>(new char[] { '+', '-', '*', '/', '!', '^' });// ['0'..'9'];['+','-','*','/','!','^'];
        ensLettre = new List<char>();
        for (char car = 'a'; car <= 'z'; car++)
            ensLettre.Add(car);
    }
}

class Pile : Stack<string>
{
    public bool Est_Vide()
    {
        return this.Count == 0;
    }
    public void Empiler(string elt)
    {
        this.Push(elt);
    }
    public void Depiler(ref string elt)
    {
        if (!Est_Vide())
            elt = this.Pop();
    }
    public string premier()
    {
        if (!Est_Vide())
            return this.Peek();
        else
            return "@";
    }
    public void Afficher()
    {
        string strLoc = "";
        if (!Est_Vide())
        {
            string[] t = this.ToArray();
            for (int i = 0; i < t.Length; i++)
                strLoc += t[i] + '.';
        }
        else
            strLoc = "Pile vide";
        Console.WriteLine(strLoc);
    }
}

class Program
{
    static void afficheCodeGen(string nomFich)
    {
        using (StreamReader fluxRead = new StreamReader(nomFich))
        {
            string ligne;
            while ((ligne = fluxRead.ReadLine()) != null)
                Console.WriteLine(ligne);
        }
    }

    static void Main(string[] args)
    {
        //string expression="a+5-b*d!c" ;
        //string expression = "2*a^3-(b-c!d)/(x-1)";
        string expression = "a^b";
        //GenererExpr generUneExpr = new GenererExpr();
        //expression=generUneExpr.ExpressArithm();// expression auto-générée par grammaire
        expression = "a+b*(c-5)";
        Console.WriteLine("Expression = " + expression);
        GenererCode generateur = new GenererCode();
        TradExprParPostFixe Traducteur = new TradExprParPostFixe();
        string exprPostFixe = Traducteur.TraduitEnPostFixe(expression);
        Console.WriteLine("\r\nExpression postfixée = " + exprPostFixe);
        generateur.generFichiercode(exprPostFixe);
        Console.WriteLine("\r\nfin de compilation");
        Console.WriteLine();
        Console.WriteLine("****************************************");
        Console.WriteLine("* code et table des symboles generes   *");
        Console.WriteLine("****************************************");
        Console.WriteLine();
        afficheCodeGen(Globale.fichierCode);
        MachineMAP machine = new MachineMAP();
        Desassembler DASM = new Desassembler();
        DASM.codeDASM();
        int valeurExpr = 0;
        machine.execute(ref valeurExpr);
        Console.WriteLine("valeur de l''expression = " + valeurExpr);
        Console.ReadLine();
    }
}
