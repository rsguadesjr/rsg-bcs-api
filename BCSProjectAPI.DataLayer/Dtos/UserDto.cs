﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProjectAPI.DataLayer.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public byte LoginAttempt { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public int? EmployeeId { get; set; }
        //public EmployeeDto Employee { get; set; }

        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}
