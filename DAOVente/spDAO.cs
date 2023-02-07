using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOVente
{
    public class spDAO : IDAO
    {
        public spDAO()
        {

        }


        public void AddEmploye(EMPLOYE employe) { }
        public void DelEmploye(int id)
        { }

        public List<EMPLOYE> getEmploye()
        {
            using (var db = new VenteEntities())
            {
                var query = from e in db.EMPLOYE                        
                            select e;

                return query.ToList<EMPLOYE>();

               // return db.spEmploye;
            }

        }
    }
}
