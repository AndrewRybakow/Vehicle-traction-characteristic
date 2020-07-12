using System.Collections.Generic;

namespace VehicleTractionCharacteristicBl.Model
{
    public class Speed
    {
        public int SpeedId { get; set; }


        public int GearNumber { get; set; }

        public virtual Gear Gear { get; set; }


        public int EngineFrequency { get; set; }
        
        public virtual Engine Engine { get; set; }


        public double Value { get; set; }

        public virtual ICollection<Characteristic> Characteristics { get; set; }
    }
}
