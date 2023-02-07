using System;
using System.Collections;


//un SortedList = 2 tables  Keys et Values liées entre elles implantant un IDictionnary
//Le couple(une cellule de Keys, la cellule associée dans Values ) peut aussi être considéré comme un DictionaryEntry  = (Key , Value),
//le SortedList peut alors être considéré aussi comme une collection d'objets de type DictionaryEntry :

class Client
{//-- enregistrement du type client
    public string nom, prenom, adresse;
    public int idClient;

    //-- constructeurs :
    public Client(string nom, string prenom, int id)
    {
        this.nom = nom;
        this.prenom = prenom;
        this.idClient = id;
    }
    public Client(string nom, string prenom, string adresse, int id)
        : this(nom, prenom, id)
    {
        this.adresse = adresse;
    }

    static void Main(string[] args)
    {

        listeClient cci = new listeClient();
        cci.ajouterClient(new Client("renoir", "rené", 20));
        cci.ajouterClient(new Client("Lizt", "Franzt", "12 rote strasse 1245 Köln", 8));
        cci.ajouterClient(new Client("Thomson", "major", " 1st flowers street 00258 Maidstone", 47));
        cci.ajouterClient(new Client("Puccini", "Vittorio", 75));
        cci.ajouterClient(new Client("Strauss", "Johan", "62  Kirsh Platz 80065 Wien", 109));
        cci.afficherListeClients();


        Console.WriteLine("--------------------------------------------");

        // Console.WriteLine("Requête puccini : " + cci.requeteClientNom("Puccini"));
        Console.WriteLine("Requête idClient=1 : " + cci.requeteClientId(1));
        Console.WriteLine("Requête idClient=8 : " + cci.requeteClientId(8));

        cci.modifAdresseClient("Puccini", "5 rue Emmanuel Kant");

        Console.WriteLine(" Ajouter-------------------------------------------");

        cci.ajouterClient(new Client("Wayne", "John", 75));
        cci.ajouterClient(new Client("Wayne", "John", "Fort Alamo new Mexico", 23));

        cci.supprimerClient("Thomson");
        cci.afficherListeClients();
        Console.ReadLine();
    }


}

class listeClient : SortedList
{
    private const string mark = "***";

    //-- méthodes métier :
    public void afficherListeClients()
    {//-- liste des clients enregistrés:
        foreach (DictionaryEntry d in this)
            Console.WriteLine(((Client)d.Value).idClient + "-------" + ((Client)d.Value).nom + "--" + ((Client)d.Value).prenom + "--" + ((Client)d.Value).adresse);
    }

    //public string requeteClientNom(string nomCli)
    //{//-- requête de recherche de client par nom dans la liste
    //}

    public void modifAdresseClient(string nomCli, string newAdr)
    {//-- modification si le client est présent
        //foreach (DictionaryEntry d in this)
        //    if (((Client)d.Value).nom==nomCli)
        if (this[nomCli].idClient >= 0)
            this[nomCli].adresse = newAdr;
        else
            Console.WriteLine("-- Modif Adresse Client {0} n'est pas trouvé", nomCli);

    }

    public void ajouterClient(Client person)
    {//-- ajout uniquement si numéro non déjà présent
        if (this[person.idClient].idClient < 0)
            this.Add(person.idClient, person);
        else
            Console.WriteLine("ADD --- Client de Id={0} existe déjà", person.idClient);
    }

    public void supprimerClient(string nomCli)
    {//-- supprime uniquement si le client est présent
        if (this[nomCli].idClient >= 0)
            this.Remove(this[nomCli].idClient);
        else
            Console.WriteLine("REMOVE ---- Client de Id={0} n'existe pas", nomCli);
    }

    public string requeteClientId(int idCli)
    {//-- requête de recherche de client par identif client dans la liste
        return "requeteClientId:  " + this[idCli].idClient + " -- " + this[idCli].nom + this[idCli].prenom + " -- " + this[idCli].adresse ;
    }

    //-- indexeurs :
    public Client this[string nom]
    {//-- indexeur de requête Client par nom :Client("***","***",-1) si pas trouvé

        get
        {
            Client c = new Client("*", "*", -1);
            foreach (DictionaryEntry d in this)
            {
                if ((((Client)(d.Value)).nom == nom))
                {
                    c = (Client)d.Value;
                    break;
                }
            }

            return c;
        }
    }

    public Client this[int id]
    {//-- indexeur de requête Client par identif :Client("***","***",-2) 
     //   si pas trouvé.
        get
        {
            Client c = new Client("**", "**", -2);
            foreach (DictionaryEntry d in this)
            {
                if (((int)(d.Key) == id))
                {
                    c = (Client)d.Value;
                    break;
                }
            }

            return c;
        }
    }
}
