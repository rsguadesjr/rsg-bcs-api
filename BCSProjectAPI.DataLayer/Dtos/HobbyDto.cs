﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProjectAPI.DataLayer.Dtos
{
    public class HobbyDto
    {
        public int Id { get; set; }
        public string HobbyName { get; set; }

        public int EmployeeId { get; set; }
    }
}
