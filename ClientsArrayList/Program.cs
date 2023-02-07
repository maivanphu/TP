using System;
using System.Collections;

namespace ClientsArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            listeClient cci = new listeClient();
            cci.ajouterClient(new Client("renoir", "rené", 20));
            cci.ajouterClient(new Client("Lizt", "Franzt", "12 rote strasse 1245 Köln", 8));
            cci.ajouterClient(new Client("Thomson", "major", " 1st flowers street 00258 Maidstone", 47));
            cci.ajouterClient(new Client("Puccini", "Vittorio", 75));
            cci.ajouterClient(new Client("Strauss", "Johan", "62  Kirsh Platz 80065 Wien", 109));

            cci.ajouterClient(new Client("renoir doublon", "rené", 20));

            cci.afficherListeClients();

            Console.WriteLine("--------------------------------------------");

            cci.modifAdresseClient("Lizt1", "145 rue de Charenton");

            cci.supprimerClient("Thomson");
            cci.supprimerClient("maiai");

            Console.WriteLine("Requête puccini : " + cci.requeteClientNom("Puccini"));
            Console.WriteLine("Requête idClient=1 : " + cci.requeteClientId(1));
            Console.WriteLine("Requête idClient=8 : " + cci.requeteClientId(8));
            cci.ajouterClient(new Client("Wayne", "John", 75));
            cci.ajouterClient(new Client("Wayne", "John", "Fort Alamo new Mexico", 23));
            cci.afficherListeClients();
            Console.ReadLine();


         
        }
    }

    /// <summary>
    /// Construire une liste de clients fondée sur un ArrayList.
    /// </summary>
    
    class Client
    {
        public string nom, prenom, adresse;
        public int idClient;
        public Client(string nom, string prenom, int idClient)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.idClient = idClient;
        }

        public Client(string nom, string prenom, string adresse, int idClient) : this(nom, prenom, idClient)
        {
            this.adresse = adresse;
        }
    }
    /// <summary>
    /// Maintient à jour la liste de tous les clients à l'aide de méthodes.
    /// </summary>
    class listeClient : ArrayList
    {
        public listeClient()
        {
            // list = new ArrayList();
        }

        // ArrayList list;


        //1°) void afficherListeClients() : affiche à la console la liste complète de tous les clients.
        public void afficherListeClients()
        {
            foreach (Client cl in this)
                Console.WriteLine("Nom={0}, Prenom={1}, Adresse={2}, Identifiant={3}", cl.nom, cl.prenom, cl.adresse, cl.idClient);
        }

        //2°) void ajouterClient(Client person) : ajoute un client à la liste dans le cas où son identifiant n'est pas déjà existant dans la liste.
        public void ajouterClient(Client person)
        {
            if (this[person.idClient].idClient == -1)
                this.Add(person);
            else
                Console.WriteLine("Client existe déjà, Id={0} est déjà distribué pour {1}", person.idClient, this[person.idClient].nom);
        }


        //3°) void modifAdresseClient(string nomCli, string newAdr) : à partir d'un nom de client "string nomCli" cette méthode modifie l'adresse actuelle de ce client dans la liste.

        public void modifAdresseClient(string nomCli, string newAdr)
        {
            if (this[nomCli].idClient >= 0)
                this[nomCli].adresse = newAdr;
            else
                Console.WriteLine("Client {0} n'est pas trouvé", nomCli);
        }


        //4°) void supprimerClient(string nomCli) : enlève de la liste, l'objet client à partir de son nom "string nomCli" s'il existe dans la liste.

        public void supprimerClient(string nomCli)
        {
            //this.Remove()
            if (this[nomCli].idClient >= 0)
                this.Remove(this[nomCli]);
            else
                Console.WriteLine("Client {0} n'est pas trouvé", nomCli);
        }

        //5°) string requeteClientId(int idCli) : renvoie sous forme d'une string toutes les informations connues
        //sur un client de la liste(nom, prenom, identifiant, adresse) à partir de son numéro d'identification de client "int idCli".
        public string requeteClientId(int idCli)
        {
            return string.Format ("Client id={0},Nom={1},prenom={2}",this[idCli].idClient,this[idCli].nom,this[idCli].prenom);
       }


        //6°) string requeteClientNom(string nomCli) : renvoie sous forme d'une string toutes les informations connues
        //sur un client de la liste(nom, prenom, identifiant, adresse) à partir de son nom de client "string nomCli".
        public string requeteClientNom(string nomCli)
        {
            return string.Format("Client id={0},Nom={1},prenom={2}", this[nomCli].idClient, this[nomCli].nom, this[nomCli].prenom);
        }


        //7°) Deux surcharges de l'indexeur de la classe listeClient, permettant de retrouver un objet Client de la liste l'un directe(this[int id] ) l'autre associative ( this[string nom] ).

        public new Client this[int index]
        {
            get
            {
                Client inconnu = new Client("*", "*", -1);
                foreach (Client c in this)
                {
                    if (c.idClient == index)
                    {
                        inconnu = c;
                        break;
                    }
                        //return c;
                }
                return inconnu;
            }
        }

        public Client this[string nom]
        {
            get 
            { Client inconnu = new Client("**", "**", -2);

                foreach (Client c in this)
                {
                    if (c.nom == nom)
                        return c;
                }
                return inconnu;
            }
        }
    }

}
