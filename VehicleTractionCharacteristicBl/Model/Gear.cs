using System.Collections.Generic;

namespace VehicleTractionCharacteristicBl.Model
{
    class Gear
    {
        public int GearId { get; set; }

        public int Number { get; set; }


        public virtual ICollection<Speed> Speeds { get; set; }

        public virtual ICollection<Characteristic> Characteristics { get; set; }
    }
}
