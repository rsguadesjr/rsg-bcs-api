using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSProjectAPI.DataLayer.Entities
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string ColumnName { get; set; }
        public string ColumnText { get; set; }
    }
}
