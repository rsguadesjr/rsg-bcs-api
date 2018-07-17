using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProjectAPI.DataLayer.Entities
{
    public class EmployeeDepartment
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
    }
}
