using System;
using System.Collections.Generic;

#nullable disable

namespace BusResrvation.Models
{
    public partial class DriverTable
    {
        public DriverTable()
        {
            BusTables = new HashSet<BusTable>();
        }

        public int DriverId { get; set; }
        public string DriverName { get; set; }

        public virtual ICollection<BusTable> BusTables { get; set; }
    }
}
