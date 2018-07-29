using BCSProjectAPI.DataLayer;
using BCSProjectAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProjectAPI.BusinessLayer.Manager
{
    public class DepartmentManager
    {
        public List<Department> GetDepartments()
        {
            using (var db = new DataContext())
            {
                return db.Departments.ToList();
            }
        }
    }
}
