using System.Collections.Generic;

namespace VehicleTractionCharacteristicBl.Model
{
    public static class Vehicle
    {
        public static List<Engine> Engine = new List<Engine>();

        public static List<Gear> Gears = new List<Gear>();

        public static List<Speed> Speed = new List<Speed>();

        public static List<TractionForce> TractionForce = new List<TractionForce>();

        public static List<DynamicFactor> DynamicFactor = new List<DynamicFactor>();

        public static List<Acceleration> Acceleration = new List<Acceleration>();

        public static List<AccelerationTimePathCharacteristic> AccelerationTimePathCharacteristic = new List<AccelerationTimePathCharacteristic>();

        public static List<RollingResistanceForce> RollingResistanceForce = new List<RollingResistanceForce>();

        public static List<AirResistanceForce> AirResistanceForce = new List<AirResistanceForce>();
    }
}
