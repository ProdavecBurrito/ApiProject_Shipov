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
        Employeers[] employeers = new Employeers[]
        {
            new Employeers { ID = 1, Name = "Петр", Salary = 40000, DepName = "Тех" },
            new Employeers { ID = 2, Name = "Михаил", Salary = 30000, DepName = "Мед"  },
            new Employeers { ID = 3, Name = "Александр", Salary = 50000, DepName = "Авто"},
            new Employeers { ID = 4, Name = "Николай", Salary = 45000, DepName = "Тех" },
            new Employeers { ID = 5, Name = "Анастасия", Salary = 38000, DepName = "Мед" },
            new Employeers { ID = 6, Name = "Елена", Salary = 43000, DepName = "Авто" },
        };
        public IEnumerable<Employeers> GetAllProducts()
        {
            return employeers;
        }
        public IHttpActionResult GetProduct(int id)
        {
            var employee = employeers.FirstOrDefault((emp) => emp.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

    }
}
