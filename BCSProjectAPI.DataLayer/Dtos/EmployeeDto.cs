using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProjectAPI.DataLayer.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PhoneNo { get; set; }
        public virtual ICollection<HobbyDto> Hobbies { get; set; }
        public virtual ICollection<InterestDto> Interests { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime? DateResigned { get; set; }
    }
}
