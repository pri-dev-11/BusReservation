using System;
using System.Collections.Generic;

#nullable disable

namespace BusResrvation.Models
{
    public partial class Wallet
    {
        public Wallet()
        {
            UserTables = new HashSet<UserTable>();
        }

        public int WalletId { get; set; }
        public double? Amount { get; set; }

        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
