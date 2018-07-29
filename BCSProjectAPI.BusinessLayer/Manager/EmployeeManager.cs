using AutoMapper;
using BCSProjectAPI.DataLayer;
using BCSProjectAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
                    return db.Employees
                            .Include(x => x.Hobbies)
                            .Include(x => x.EmployeeCharacteristics)
                            .Include(x => x.Department)
                            .SingleOrDefault(x => x.Id == id);
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
                //return db.Employees.Skip(skip).Take(take).ToList();
                return db.Employees
                        .Include(x => x.Hobbies)
                        .Include(x => x.EmployeeCharacteristics)
                        .Include(x => x.Department)
                        .ToList();
            }
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var lastUserId = db.Employees.Max(x => x.Id);

                    //create employeeNo
                    employee.EmployeeNo = DateTime.Now.ToString("MMddy" + String.Format("{0:0000}", lastUserId));
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    DefaultEmployeePrivacy(employee.Id);
                    return true;
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine(err);
            }
            return false;
        }

        public bool UpdateEmployee(int id, Employee employee)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var existingEmployee = GetEmployee(id);
                    if (existingEmployee != null)
                    {
                        Mapper.Map(employee, existingEmployee);

                        db.Entry(existingEmployee).State = EntityState.Modified;
                        db.SaveChanges();
                        AddOrUpdateHobbies(employee.Id, employee.Hobbies.ToList());
                        return true;
                    }
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
            }
            return false;
        }

        public void AddOrUpdateHobbies(int employeeId, List<Hobby> hobbies)
        {
            using (var db = new DataContext())
            {

                var listOfHobbies = db.Hobbies.Where(x => x.EmployeeId == employeeId);

                if (hobbies == null)
                {
                    db.Entry(listOfHobbies).State = EntityState.Deleted;
                    db.SaveChanges();
                    return;
                }

                foreach(var item in listOfHobbies)
                {
                    var hobby = hobbies.FirstOrDefault(x => x.HobbyName == item.HobbyName);
                    if (hobby == null)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                    else
                    {
                        hobbies.Remove(hobby);
                    }
                }

                foreach(var item in hobbies)
                {
                    Hobby hobby = new Hobby();
                    hobby.HobbyName = item.HobbyName;
                    hobby.EmployeeId = employeeId;
                    db.Hobbies.Add(hobby);
                }

                db.SaveChanges();
            }
        }


        public void DefaultEmployeePrivacy(int employeeId)
        {
            using(var db = new DataContext())
            {
                var fields = db.Characteristics;
                foreach (var field in fields)
                {
                    db.EmployeeCharacteristics.Add(new EmployeeCharacteristic
                    {
                        CharacteristicId = field.Id,
                        EmployeeId = employeeId,
                        IsPublic = false,
                        DateCreated = DateTime.Now
                    });
                }
                db.SaveChanges();
            }
        }
    }

}
