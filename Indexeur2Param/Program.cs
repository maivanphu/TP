using System;

class classeArticles
{
    private string[] article = new string[10];
    private int[] codeArticle = new int[10];// { 110, 111, 112, 113, 114, 115, 116, 117, 118, 119 };

    public string this[int numArt, int numCode]
    {
        get
        {
            if (article[numArt] != null)
            {
                int numero = Math.Abs(article[numArt].GetHashCode() % 10);
                if (numero == numCode)
                    return article[numArt] + " , code : " + codeArticle[numCode].ToString();
                else
                    return "***L'article " + article[numArt] + " est rangé au numéro : " + numero.ToString();
            }
            else
                return "*** cet article n'existe pas.";
        }
    }
    public string this[int numArt]
    {
        get
        {
            if (article[numArt] != null)
                return article[numArt];
            else
                return "*** cet article n'existe pas.";
        }
        set
        {
            Random alea = new Random();
            article[numArt] = value;
            codeArticle[Math.Abs(value.GetHashCode() % 10)] = alea.Next(100);
        }
    }
}

class Application
{
    static void Main(string[] args)
    {
        classeArticles Obj = new classeArticles();
        Obj[0] = "montre";
        Obj[1] = "chien";
        Obj[2] = "chat";
        Obj[3] = "pijeon";
        Obj[4] = "elephant";
        Obj[5] = "poisson";
        Obj[6] = "animal";
        Obj[7] = "oiseau";

        for (int i = 0; i < 7; i++)
            Console.WriteLine(Obj[i,4]);

        Console.WriteLine(Obj[2]);
        Console.WriteLine(Obj[2, 4]);
        //Obj[2] = "montre";
        Console.WriteLine(Obj[2]);
        Console.WriteLine(Obj[2, 4]);
        Console.WriteLine(Obj[2, Math.Abs(Obj[2].GetHashCode() % 10)]);
        Console.WriteLine(Obj[2, 7]);
        Console.Read();
    }
}
