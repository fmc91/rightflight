using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RightFlightEntityModel
{
    public partial class FlightReservationContext : DbContext
    {
        public FlightReservationContext()
        {
        }

        public FlightReservationContext(DbContextOptions<FlightReservationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aircraft> Aircraft { get; set; }
        public virtual DbSet<AircraftRoute> AircraftRoute { get; set; }
        public virtual DbSet<Airline> Airline { get; set; }
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<TravelClass> TravelClass { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=flight_reservation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>(entity =>
            {
                entity.HasKey(e => e.IcaoTypeCode)
                    .HasName("PK__aircraft__5A1DF9D279722BCB");

                entity.ToTable("aircraft");

                entity.Property(e => e.IcaoTypeCode)
                    .HasColumnName("icao_type_code")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AircraftRoute>(entity =>
            {
                entity.ToTable("aircraft_route");

                entity.Property(e => e.AircraftRouteId).HasColumnName("aircraft_route_id");

                entity.Property(e => e.IcaoTypeCode)
                    .IsRequired()
                    .HasColumnName("icao_type_code")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.HasOne(d => d.IcaoTypeCodeNavigation)
                    .WithMany(p => p.AircraftRoute)
                    .HasForeignKey(d => d.IcaoTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aircraft___icao___7B5B524B");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.AircraftRoute)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aircraft___route__7C4F7684");
            });

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.HasKey(e => e.IataAirlineCode)
                    .HasName("PK__airline__19E924EE4621405D");

                entity.ToTable("airline");

                entity.Property(e => e.IataAirlineCode)
                    .HasColumnName("iata_airline_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LogoPath)
                    .HasColumnName("logo_path")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.IataAirportCode)
                    .HasName("PK__airport__57E8CB97F986E363");

                entity.ToTable("airport");

                entity.Property(e => e.IataAirportCode)
                    .HasColumnName("iata_airport_code")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CityCode)
                    .HasColumnName("city_code")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CityCodeNavigation)
                    .WithMany(p => p.Airport)
                    .HasForeignKey(d => d.CityCode)
                    .HasConstraintName("FK__airport__city_co__73BA3083");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");

                entity.HasIndex(e => e.BookingReference)
                    .HasName("UQ__booking__BADA455981F6467E")
                    .IsUnique();

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.BookingReference)
                    .IsRequired()
                    .HasColumnName("booking_reference")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.TimeOfBooking)
                    .HasColumnName("time_of_booking")
                    .HasColumnType("datetime");

                entity.Property(e => e.TravelClassCode)
                    .IsRequired()
                    .HasColumnName("travel_class_code")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__booking__flight___02FC7413");

                entity.HasOne(d => d.TravelClassCodeNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.TravelClassCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__booking__travel___03F0984C");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IataCityCode)
                    .HasName("PK__city__B3E7D24A10397E40");

                entity.ToTable("city");

                entity.Property(e => e.IataCityCode)
                    .HasColumnName("iata_city_code")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("country_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeZone)
                    .IsRequired()
                    .HasColumnName("time_zone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__city__country_co__6FE99F9F");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IsoCountryCode)
                    .HasName("PK__country__5276C2FD23F04861");

                entity.ToTable("country");

                entity.Property(e => e.IsoCountryCode)
                    .HasColumnName("iso_country_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flight");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.AircraftRouteId).HasColumnName("aircraft_route_id");

                entity.Property(e => e.EstimatedDuration).HasColumnName("estimated_duration");

                entity.Property(e => e.FlightNumber)
                    .IsRequired()
                    .HasColumnName("flight_number")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduledDeparture)
                    .HasColumnName("scheduled_departure")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AircraftRoute)
                    .WithMany(p => p.Flight)
                    .HasForeignKey(d => d.AircraftRouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__flight__aircraft__7F2BE32F");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("nationality");

                entity.Property(e => e.NationalityId).HasColumnName("nationality_id");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("country_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.ToTable("passenger");

                entity.Property(e => e.PassengerId).HasColumnName("passenger_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NationalityId).HasColumnName("nationality_id");

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasColumnName("postcode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Passenger)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__passenger__booki__07C12930");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.Passenger)
                    .HasForeignKey(d => d.NationalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__passenger__natio__08B54D69");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("route");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.AirlineCode)
                    .IsRequired()
                    .HasColumnName("airline_code")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DestinationAirport)
                    .IsRequired()
                    .HasColumnName("destination_airport")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OriginAirport)
                    .IsRequired()
                    .HasColumnName("origin_airport")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PricingScheme)
                    .IsRequired()
                    .HasColumnName("pricing_scheme")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.AirlineCodeNavigation)
                    .WithMany(p => p.Route)
                    .HasForeignKey(d => d.AirlineCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__route__airline_c__76969D2E");

                entity.HasOne(d => d.DestinationAirportNavigation)
                    .WithMany(p => p.RouteDestinationAirportNavigation)
                    .HasForeignKey(d => d.DestinationAirport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__route__destinati__787EE5A0");

                entity.HasOne(d => d.OriginAirportNavigation)
                    .WithMany(p => p.RouteOriginAirportNavigation)
                    .HasForeignKey(d => d.OriginAirport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__route__origin_ai__778AC167");
            });

            modelBuilder.Entity<TravelClass>(entity =>
            {
                entity.HasKey(e => e.TravelClassCode)
                    .HasName("PK__travel_c__A6F0509721AD15FC");

                entity.ToTable("travel_class");

                entity.Property(e => e.TravelClassCode)
                    .HasColumnName("travel_class_code")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
