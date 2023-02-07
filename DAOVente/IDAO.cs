using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOVente
{
    public interface IDAO
    {
        List<EMPLOYE> getEmploye();
        void AddEmploye(EMPLOYE employe);
        void DelEmploye(int id);

        //object GetUser();
       //void AddUser(PERSONNE personne);
        //void DelUser(int id);

        //object GetVideo();
        //void AddVideo(VIDEO video);
        //void DelVideo(int id);
    }
}
