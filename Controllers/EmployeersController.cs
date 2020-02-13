using ASP.NET_Shipov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP.NET_Shipov.Controllers
{
    public class EmployeersController : ApiController
    {
        EmpSettings emp = new EmpSettings();

        [Route("getlist")]
        public List<Employeers> Get()
        {
            return emp.GetList();
        }

        [Route("getlist/{id}")]
        public Employeers GetPeople(int id)
        {
            return emp.GetEmpById(id);
        }

        [Route("addpeople")]
        public HttpResponseMessage Post([FromBody]Employeers value)
        {
            if (emp.AddEmployeers(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
