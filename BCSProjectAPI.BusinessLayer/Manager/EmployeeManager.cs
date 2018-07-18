using BCSProjectAPI.DataLayer;
using BCSProjectAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BCSProjectAPI.BusinessLayer.Manager
{
    public class EmployeeManager
    {
        public Employee GetEmployee(int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    return db.Employees.SingleOrDefault(x => x.Id == id);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<Employee> GetEmployees(int skip, int take)
        {
            using (var db = new DataContext())
            {
                return db.Employees.Skip(skip).Take(take).ToList();
            }
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                using (var db = new DataContext())
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return true;
                }
            }
            catch(Exception)
            {

            }
            return false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var existingEmployee = GetEmployee(employee.Id);
                    if(existingEmployee != null)
                    {
                        //map
                        db.Entry(existingEmployee).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception)
            {

            }
            return false;
        }
        
    }
}
