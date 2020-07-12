using System.Data.Entity;

namespace VehicleTractionCharacteristicBl.Model
{
    public class VTCContext : DbContext
    {
        public VTCContext() : base("VTCConnection") { }

        public DbSet<Engine> Engine { get; set; }

        public DbSet<Gear> Gears { get; set; }

        public DbSet<Speed> Speeds { get; set; }

        public DbSet<Characteristic> Characteristics { get; set; }
    }
}
