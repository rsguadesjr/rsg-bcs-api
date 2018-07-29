using BCSProjectAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProjectAPI.DataLayer.Dtos
{
    public class EmployeeCharacteristicDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int CharacteristicId { get; set; }
        public Characteristic Characteristic { get; set; }

        public bool IsPublic { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
