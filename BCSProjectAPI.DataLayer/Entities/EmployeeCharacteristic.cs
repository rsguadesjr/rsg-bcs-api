using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProjectAPI.DataLayer.Entities
{
    public class EmployeeCharacteristic
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int CharacteristicId { get; set; }
        public virtual Characteristic Characteristic { get; set; }

        public bool IsPublic { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
