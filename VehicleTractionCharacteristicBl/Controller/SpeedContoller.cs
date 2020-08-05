using System;
using System.Collections.Generic;
using VehicleTractionCharacteristicBl.Model;

namespace VehicleTractionCharacteristicBl.Controller
{
    public class SpeedContoller
    {
        double WheelRadius { get; }

        double TransferBoxTopGearRatio { get;}

        double TransferBoxLowerGearRatio { get; }

        double FinalDriveRatio { get; }

        readonly List<Engine> Engine = new List<Engine>();

        readonly List<Gear> Gears = new List<Gear>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wheelRadius"> Wheel radius. </param>
        /// <param name="transferBoxTopGearRatio"> Transfer box top gear ratio. </param>
        /// <param name="transferBoxLowerGearRatio"> Transfer box lower gear ratio. </param>
        /// <param name="finalDriveRatio"> Final drive ratio </param>
        /// <param name="engine"> Vehicle engine. </param>
        /// <param name="gears"> Vehicle gears. </param>
        public SpeedContoller(double wheelRadius,
                              double transferBoxTopGearRatio,
                              double transferBoxLowerGearRatio,
                              double finalDriveRatio,
                              List<Engine> engine,
                              List<Gear> gears)
        {
            WheelRadius = wheelRadius;
            TransferBoxTopGearRatio = transferBoxTopGearRatio;
            TransferBoxLowerGearRatio = transferBoxLowerGearRatio;
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

            if (!(TransferBoxTopGearRatio == 1 && TransferBoxLowerGearRatio == 1))
            {
                for (int i = 0; i < Engine.Count; i++)
                {
                    speed.Add(new Speed
                    {
                        EngineFrequency = Engine[i].Frequency,
                        GearNumber = 0,
                        SpeedValue = 0.377 * ((Engine[i].Frequency * WheelRadius) / (Gears[0].GearRatio * TransferBoxLowerGearRatio * FinalDriveRatio))
                    });
                }
            }

            for (int i = 0; i < Gears.Count; i++)
            {
                for (int j = 0; j < Engine.Count; j++)
                {
                    speed.Add(new Speed
                    {
                        EngineFrequency = Engine[j].Frequency,
                        GearNumber = Gears[i].GearNumber,
                        SpeedValue = 0.377 * ((Engine[j].Frequency * WheelRadius)/(Gears[i].GearRatio * TransferBoxTopGearRatio * FinalDriveRatio))
                    });
                }
            }

            return speed;
        }
    }
}
