using System;
using System.Collections.Generic;

#nullable disable

namespace BusResrvation.Models
{
    public partial class ReservationTable
    {
        public ReservationTable()
        {
            PaymentTables = new HashSet<PaymentTable>();
        }

        public int TicketId { get; set; }
        public int? UserId { get; set; }
        public int? BusId { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string SeatNo { get; set; }
        public int NoOfSeats { get; set; }
        public DateTime? DateOfBooking { get; set; }
        public string JourneyType { get; set; }
        public double AmountPaid { get; set; }
        public string BookingStatus { get; set; }

        public virtual BusTable Bus { get; set; }
        public virtual UserTable User { get; set; }
        public virtual ICollection<PaymentTable> PaymentTables { get; set; }
    }
}
