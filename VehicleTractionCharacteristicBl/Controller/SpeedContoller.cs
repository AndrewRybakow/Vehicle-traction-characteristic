using System.Collections.Generic;
using VehicleTractionCharacteristicBl.Model;

namespace VehicleTractionCharacteristicBl.Controller
{
    public class SpeedContoller
    {
        double WheelRadius { get; }

        double TransferBoxGearRatio { get;}

        double FinalDriveRatio { get; }

        readonly List<Engine> Engine = new List<Engine>();

        readonly List<Gear> Gears = new List<Gear>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wheelRadius"> Wheel radius. </param>
        /// <param name="transferBoxGearRatio"> Transfer box gear ratio. </param>
        /// <param name="finalDriveRatio"> Final drive ratio </param>
        /// <param name="engine"> Vehicle engine. </param>
        /// <param name="gears"> Vehicle gears. </param>
        public SpeedContoller(double wheelRadius,
                              double transferBoxGearRatio,
                              double finalDriveRatio,
                              List<Engine> engine,
                              List<Gear> gears)
        {
            WheelRadius = wheelRadius;
            TransferBoxGearRatio = transferBoxGearRatio;
            FinalDriveRatio = finalDriveRatio;
            Engine = engine;
            Gears = gears;
        }

        /// <summary>
        /// Calculate vehicle speed characteristic.
        /// </summary>
        /// <returns></returns>
        public List<Speed> Calculate()
        {
            List<Speed> speed = new List<Speed>();

            for (int i = 0; i < Gears.Count; i++)
            {
                for (int j = 0; j < Engine.Count; j++)
                {
                    speed.Add(new Speed
                    {
                        EngineFrequency = Engine[j].Frequency,
                        GearNumber = Gears[i].GearNumber,
                        SpeedValue = 0.377 * ((Engine[j].Frequency * WheelRadius)/(Gears[i].GearRatio * TransferBoxGearRatio * FinalDriveRatio))
                    });
                }
            }

            return speed;
        }
    }
}
