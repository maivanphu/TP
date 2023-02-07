using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAOVente;

using Newtonsoft.Json;

namespace WebAPI.Controllers
{

    //https://localhost:44382/api/Employes/GetAllEmploye

    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        public EmployesController()
        {
            //DAOVente.get
        }

        [HttpGet]
        [Route("GetAllEmploye")]
        public string GetEmploye()
        {
            spDAO dao = new spDAO();
            return JsonConvert.SerializeObject(dao.getEmploye());

            //return (JsonResult)dao.getEmploye();
        }

    }
}
