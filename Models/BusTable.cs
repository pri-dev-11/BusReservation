using System;
using System.Collections.Generic;

#nullable disable

namespace BusResrvation.Models
{
    public partial class BusTable
    {
        public BusTable()
        {
            ReservationTables = new HashSet<ReservationTable>();
        }

        public int BusId { get; set; }
        public string BusName { get; set; }
        public int? DriverId { get; set; }
        public int? BusTotalSeats { get; set; }
        public int? BusSeatPrice { get; set; }
        public string BusSource { get; set; }
        public string BusDestination { get; set; }
        public TimeSpan BusDepartureTime { get; set; }
        public TimeSpan BusArrivalTime { get; set; }
        public DateTime BusDateOfJourney { get; set; }

        public virtual DriverTable Driver { get; set; }
        public virtual ICollection<ReservationTable> ReservationTables { get; set; }
    }
}
