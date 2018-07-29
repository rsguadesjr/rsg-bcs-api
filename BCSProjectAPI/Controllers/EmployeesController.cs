using AutoMapper;
using BCSProjectAPI.BusinessLayer.Manager;
using BCSProjectAPI.DataLayer.Dtos;
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

        // GET api/employees
        public IHttpActionResult GetEmployees()
        {
            var result = _employeeManager.GetEmployees(0, 5);
            return Ok(Mapper.Map<List<Employee>, List<EmployeeDto>>(result));
        }

        // GET api/employees/1
        public IHttpActionResult GetEmployee(int id)
        {
            var result = _employeeManager.GetEmployee(id);
            return Ok(Mapper.Map<Employee, EmployeeDto>(result));
        }

        // POST api/employees
        [Authorize]
        [HttpPost]
        public IHttpActionResult CreateEmployee(Employee employee)
        { 
            var saved = _employeeManager.AddEmployee(employee);
            if (!saved)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return Created(new Uri(Request.RequestUri + "/" + employee.Id), employee);
        }

        // PUT api/employees/1
        [HttpPut]
        public IHttpActionResult UpdateEmployee(int id, Employee employee)
        {
            var updated = _employeeManager.UpdateEmployee(id, employee);
            if (!updated)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return Ok();
        }
    }
}
