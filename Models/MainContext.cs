using Microsoft.EntityFrameworkCore;

// This is the MainContext Model. 
// The DbSet class represents a collection for a given entity within 
// the model and is the gateway to database operations against an entity. 
// DbSet classes are added as properties to the DbContext and are mapped 
// by default to database tables that take the name of the DbSet property.

namespace Main.Models {
    public class MainContext : DbContext {
        public MainContext (DbContextOptions<MainContext> options) : base (options) { }
        public DbSet<AddressItems> addresses { get; set; }
        public DbSet<BatteryItems> batteries { get; set; }
        public DbSet<BuildingItems> buildings { get; set; }
        public DbSet<ColumnItems> columns { get; set; }
        public DbSet<CustomerItems> customers { get; set; }
        public DbSet<ElevatorItems> elevators { get; set; }
        public DbSet<EmployeeItems> employees { get; set; }
        public DbSet<LeadItems> leads { get; set; }
        public DbSet<QuoteItems> quotes { get; set; }
        public DbSet<UserItems> users { get; set; }
        public DbSet<InterventionItems> interventions { get; set; }

    }
}