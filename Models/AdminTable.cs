using System;
using System.Collections.Generic;

#nullable disable

namespace BusResrvation.Models
{
    public partial class AdminTable
    {
        public int AdminId { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public string AdminContactNo { get; set; }
    }
}
