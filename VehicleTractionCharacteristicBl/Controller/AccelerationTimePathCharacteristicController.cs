using Meta.Numerics.Analysis;
using System.Collections.Generic;
using System.Linq;
using VehicleTractionCharacteristicBl.Model;

namespace VehicleTractionCharacteristicBl.Controller
{
    public class AccelerationTimePathCharacteristicController
    {
        readonly List<Acceleration> Acceleration = new List<Acceleration>();

        readonly List<Gear> Gears = new List<Gear>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="acceleration"> Vehicle acceleration. </param>
        /// <param name="gears"> Vehicle gears. </param>
        public AccelerationTimePathCharacteristicController(List<Acceleration> acceleration,
                                                            List<Gear> gears)
        {
            Acceleration = acceleration;
            Gears = gears;
        }

        /// <summary>
        /// Calculate time and path characteristic according to acceleration.
        /// </summary>
        /// <returns></returns>
        public List<AccelerationTimePathCharacteristic> Calculate()
        {
            List<AccelerationTimePathCharacteristic> timePathCharacteristic = new List<AccelerationTimePathCharacteristic>();

            List<Acceleration> maxSpeedOnEachGear = new List<Acceleration>();

            List<Acceleration> accelerationOnEachGear = new List<Acceleration>();

            // Get list of maximum speed on each gear

            for (int i = 1; i <= Gears.Count; i++)
            {
                var speed = (from acceleration in Acceleration
                             where acceleration.GearNumber == i
                             orderby acceleration.Speed descending
                             select acceleration).First();

                maxSpeedOnEachGear.Add(speed);
            }

            /* Get acceleration forces on each gear which effects on the
               car in process of acceleration */

            var accelerationOnFirstGear = (from acceleration in Acceleration
                                           where acceleration.GearNumber == 1
                                           orderby acceleration.Speed
                                           select acceleration).ToList();

            accelerationOnEachGear.AddRange(accelerationOnFirstGear);

            for (int i = 1; i < maxSpeedOnEachGear.Count; i++)
            {
                var list = (from acceleartion in Acceleration
                            where acceleartion.GearNumber == i + 1
                            where acceleartion.Speed >= maxSpeedOnEachGear[i - 1].Speed
                            where acceleartion.AccelerationValue >= 0
                            orderby acceleartion.Speed
                            select acceleartion).ToList();

                accelerationOnEachGear.AddRange(list);
            }

            // Calculate time and path of acceleration

            double totalTime = 0;
            double totalPath = 0;
            for (int i = 0; i < accelerationOnEachGear.Count - 1; i++)
            {
                totalTime += FunctionMath.Integrate(x => (accelerationOnEachGear[i].ReciprocalAccelerationValue + accelerationOnEachGear[i + 1].ReciprocalAccelerationValue) / 2,
                                                    accelerationOnEachGear[i].Speed,
                                                    accelerationOnEachGear[i + 1].Speed);

                totalPath += FunctionMath.Integrate(x => (FunctionMath.Integrate(y => (accelerationOnEachGear[i].ReciprocalAccelerationValue + accelerationOnEachGear[i + 1].ReciprocalAccelerationValue) / 2,
                                                                                 accelerationOnEachGear[i].Speed,
                                                                                 accelerationOnEachGear[i + 1].Speed)),
                                                    accelerationOnEachGear[i].Speed,
                                                    accelerationOnEachGear[i + 1].Speed);

                timePathCharacteristic.Add(new AccelerationTimePathCharacteristic
                {
                    Speed = accelerationOnEachGear[i + 1].Speed,
                    Time = totalTime,
                    Path = totalPath                    
                });
            }

            return timePathCharacteristic;
        }
    }
}
