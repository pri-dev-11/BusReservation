using System;
using System.Collections.Generic;

#nullable disable

namespace BusResrvation.Models
{
    public partial class UserTable
    {
        public UserTable()
        {
            ReservationTables = new HashSet<ReservationTable>();
        }

        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserContactNo { get; set; }
        public int? WalletId { get; set; }

        public virtual Wallet Wallet { get; set; }
        public virtual ICollection<ReservationTable> ReservationTables { get; set; }
    }
}
