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

        public IHttpActionResult GetEmployees()
        {
            var result = _employeeManager.GetEmployees(0, 5);

            return Ok(result);
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var result = _employeeManager.GetEmployee(id);

            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult CreateEmployee(Employee employee)
        {
            var saved = _employeeManager.AddEmployee(employee);
            if (!saved)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return Created(new Uri(Request.RequestUri + "/" + employee.Id), employee);
        }

        [HttpPost]
        public IHttpActionResult UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = _employeeManager.GetEmployee(id);
            if (existingEmployee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var updated = _employeeManager.UpdateEmployee(employee);
            if (!updated)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            return Ok();
        }
    }
}
