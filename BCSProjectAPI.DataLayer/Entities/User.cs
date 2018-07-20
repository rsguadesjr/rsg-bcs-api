using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProjectAPI.DataLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
