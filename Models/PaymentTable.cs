using System;
using System.Collections.Generic;

#nullable disable

namespace BusResrvation.Models
{
    public partial class PaymentTable
    {
        public int TransactionId { get; set; }
        public int? TicketId { get; set; }
        public string ModeOfPayment { get; set; }
        public DateTime? DateOfTransaction { get; set; }

        public virtual ReservationTable Ticket { get; set; }
    }
}
