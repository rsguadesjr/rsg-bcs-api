using BCSProjectAPI.BusinessLayer.Manager;
using BCSProjectAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCSProjectAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly EmployeeManager _employeeManager;
        public EmployeesController()
        {
            _employeeManager = new EmployeeManager();
        }

        public IEnumerable<Employee> Get()
        {
            return _employeeManager.GetEmployees(0, 5);
        }

        public Employee Get(int id)
        {
            return _employeeManager.GetEmployee(id);
        }
    }
}
