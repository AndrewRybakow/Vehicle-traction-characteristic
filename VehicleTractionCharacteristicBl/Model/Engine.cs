using System.Collections.Generic;

namespace VehicleTractionCharacteristicBl.Model
{
    public class Engine
    {
        public int EngineId { get; set; }

        public int Frequency { get; set; }

        public double Power { get; set; }

        public double Torque { get; set; }

        public double Consumption { get; set; }

        public virtual ICollection<Speed> Speeds { get; set; }
    }
}