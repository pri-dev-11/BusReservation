using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BusResrvation.Models
{
    public partial class BusReservationContext : DbContext
    {
        public BusReservationContext()
        {
        }

        public BusReservationContext(DbContextOptions<BusReservationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminTable> AdminTables { get; set; }
        public virtual DbSet<BusTable> BusTables { get; set; }
        public virtual DbSet<DriverTable> DriverTables { get; set; }
        public virtual DbSet<PaymentTable> PaymentTables { get; set; }
        public virtual DbSet<ReservationTable> ReservationTables { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=BusReservation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminTable>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("pk_adminId");

                entity.ToTable("AdminTable");

                entity.HasIndex(e => e.AdminContactNo, "UQ__AdminTab__4D7201055D5E36E5")
                    .IsUnique();

                entity.HasIndex(e => e.AdminEmail, "UQ__AdminTab__9A3ED53F181AF931")
                    .IsUnique();

                entity.Property(e => e.AdminId).HasColumnName("adminId");

                entity.Property(e => e.AdminContactNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("adminContactNo");

                entity.Property(e => e.AdminEmail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("adminEmail");

                entity.Property(e => e.AdminFirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("adminFirstName");

                entity.Property(e => e.AdminLastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("adminLastName");

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("adminPassword");
            });

            modelBuilder.Entity<BusTable>(entity =>
            {
                entity.HasKey(e => e.BusId)
                    .HasName("pk_busId");

                entity.ToTable("BusTable");

                entity.HasIndex(e => e.BusName, "UQ__BusTable__CB6ADE2B3CB467B6")
                    .IsUnique();

                entity.Property(e => e.BusId).HasColumnName("busId");

                entity.Property(e => e.BusArrivalTime).HasColumnName("busArrivalTime");

                entity.Property(e => e.BusDateOfJourney)
                    .HasColumnType("date")
                    .HasColumnName("busDateOfJourney");

                entity.Property(e => e.BusDepartureTime).HasColumnName("busDepartureTime");

                entity.Property(e => e.BusDestination)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("busDestination");

                entity.Property(e => e.BusName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("busName");

                entity.Property(e => e.BusSeatPrice)
                    .HasColumnName("busSeatPrice")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.BusSource)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("busSource");

                entity.Property(e => e.BusTotalSeats)
                    .HasColumnName("busTotalSeats")
                    .HasDefaultValueSql("((24))");

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.BusTables)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("fk_driverId");
            });

            modelBuilder.Entity<DriverTable>(entity =>
            {
                entity.HasKey(e => e.DriverId)
                    .HasName("pk_driverId");

                entity.ToTable("DriverTable");

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.DriverName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("driverName");
            });

            modelBuilder.Entity<PaymentTable>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("pk_transactionId");

                entity.ToTable("PaymentTable");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.Property(e => e.DateOfTransaction)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfTransaction")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModeOfPayment)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("modeOfPayment");

                entity.Property(e => e.TicketId).HasColumnName("ticketID");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.PaymentTables)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("fk_ticketId");
            });

            modelBuilder.Entity<ReservationTable>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("pk_ticketId");

                entity.ToTable("ReservationTable");

                entity.HasIndex(e => e.ContactNo, "UQ__Reservat__7126D0BEA31F9B04")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Reservat__AB6E6164925BBCA4")
                    .IsUnique();

                entity.Property(e => e.TicketId).HasColumnName("ticketID");

                entity.Property(e => e.AmountPaid).HasColumnName("amountPaid");

                entity.Property(e => e.BookingStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bookingStatus");

                entity.Property(e => e.BusId).HasColumnName("busId");

                entity.Property(e => e.ContactNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contactNo");

                entity.Property(e => e.DateOfBooking)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfBooking")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.JourneyType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("journeyType")
                    .HasDefaultValueSql("('one-way')");

                entity.Property(e => e.NoOfSeats).HasColumnName("noOfSeats");

                entity.Property(e => e.SeatNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("seatNo");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.ReservationTables)
                    .HasForeignKey(d => d.BusId)
                    .HasConstraintName("fk_busId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReservationTables)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_userId");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_userId");

                entity.ToTable("UserTable");

                entity.HasIndex(e => e.UserContactNo, "UQ__UserTabl__89357E1D48F9F341")
                    .IsUnique();

                entity.HasIndex(e => e.UserEmail, "UQ__UserTabl__D54ADF55EF47B684")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserContactNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("userContactNo");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userFirstName");

                entity.Property(e => e.UserLastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userLastName");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("userPassword");

                entity.Property(e => e.WalletId).HasColumnName("walletId");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.WalletId)
                    .HasConstraintName("fk_walletId");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("Wallet");

                entity.Property(e => e.WalletId).HasColumnName("walletId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
