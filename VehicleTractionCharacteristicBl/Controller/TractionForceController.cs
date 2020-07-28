using System.Collections.Generic;
using VehicleTractionCharacteristicBl.Model;

namespace VehicleTractionCharacteristicBl.Controller
{
    public class TractionForceController
    {
        double TransferBoxGearRatio { get; }

        double FinalDriveRatio { get; }

        double CoefficientOfTransmissionEfficiency { get; }

        double WheelRadius { get; }

        readonly List<Engine> Engine = new List<Engine>();

        readonly List<Speed> Speed = new List<Speed>();

        readonly List<Gear> Gears = new List<Gear>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transferBoxGearRatio"> Transfer box gear ratio. </param>
        /// <param name="finalDriveRatio"> Final drive ratio. </param>
        /// <param name="coefficientOfTransmissionEfficiency"> Coefficient of transmission efficiency. </param>
        /// <param name="wheelRadius"> Wheel radius. </param>
        /// <param name="engine"> Vehicle engine. </param>
        /// <param name="gears"> Vehicle gears. </param>
        /// <param name="speed"> Vehicle speed characteristic. </param>
        public TractionForceController(double transferBoxGearRatio,
                                       double finalDriveRatio,
                                       double coefficientOfTransmissionEfficiency,
                                       double wheelRadius,
                                       List<Engine> engine,
                                       List<Gear> gears,
                                       List<Speed> speed)
        {
            TransferBoxGearRatio = transferBoxGearRatio;
            FinalDriveRatio = finalDriveRatio;
            CoefficientOfTransmissionEfficiency = coefficientOfTransmissionEfficiency;
            WheelRadius = wheelRadius;
            Engine = engine;
            Gears = gears;
            Speed = speed;
        }

        /// <summary>
        /// Calculate vehicle traction force characteristic.
        /// </summary>
        /// <returns></returns>
        public List<TractionForce> Calulate()
        {
            List<TractionForce> tractionForceCharacteristic = new List<TractionForce>();

            for (int i = 0; i < Gears.Count; i++)
            {
                for (int j = 0; j < Engine.Count; j++)
                {
                    tractionForceCharacteristic.Add(new TractionForce
                    {
                        GearNumber = Gears[i].GearNumber,
                        TractionForceValue = ((Engine[j].Torque * Gears[i].GearRatio * TransferBoxGearRatio * FinalDriveRatio * CoefficientOfTransmissionEfficiency)/(WheelRadius))
                    });
                }
            }

            for (int i = 0; i < tractionForceCharacteristic.Count; i++)
            {
                tractionForceCharacteristic[i].Speed = Speed[i].SpeedValue;
            }

            return tractionForceCharacteristic;
        }
    }
}
