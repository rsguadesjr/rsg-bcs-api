﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProjectAPI.DataLayer.Entities
{
    public class Interest
    {
        public int Id { get; set; }
        public string InterestName { get; set; }

        public int EmployeeId { get; set; }
        //public Employee Employee { get; set; } temp disable to see result from postamn
    }
}
