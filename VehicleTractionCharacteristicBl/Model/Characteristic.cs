namespace VehicleTractionCharacteristicBl.Model
{
    class Characteristic
    {
        public int CharacteristicId { get; set; }


        public int GearNumber { get; set; }

        public virtual Gear Gear { get; set; }


        public double SpeedValue { get; set; }

        public virtual Speed Speed { get; set; }


        public double TractionForce { get; set; }

        public double DynamicFactor { get; set; }

        public double PowerBalance { get; set; }

        public double Acceleration { get; set; }
    }
}
