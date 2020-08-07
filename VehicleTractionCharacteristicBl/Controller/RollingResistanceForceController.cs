using System;
using System.Collections.Generic;
using System.Linq;
using VehicleTractionCharacteristicBl.Model;

namespace VehicleTractionCharacteristicBl.Controller
{
    public class RollingResistanceForceController
    {
        double RollingResistanceCoefficient { get; }

        double VehicleWeight { get; }

        readonly List<Speed> Speed = new List<Speed>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rollingResistanceCoefficient"> Rolling resistance coefficient. </param>
        /// <param name="vehicleWeight"> Vehicle weight. </param>
        /// <param name="speed"> Vehicle speed. </param>
        public RollingResistanceForceController(double rollingResistanceCoefficient,
                                                double vehicleWeight,
                                                List<Speed> speed)
        {
            RollingResistanceCoefficient = rollingResistanceCoefficient;
            VehicleWeight = vehicleWeight;
            Speed = speed;
        }

        /// <summary>
        /// Calculate vehicle rolling resistance force.
        /// </summary>
        /// <returns></returns>
        public List<RollingResistanceForce> Calculate()
        {
            List<RollingResistanceForce> rollingResistanceForce = new List<RollingResistanceForce>();

            int maxSpeed = (int)Math.Ceiling(Speed.Max(Speed => Speed.SpeedValue));

            for (int i = 0; i < maxSpeed; i++)
            {
                rollingResistanceForce.Add(new RollingResistanceForce
                {
                    Speed = i,
                    RollingResistanceForcesValue = RollingResistanceCoefficient * (1 + (0.00005 * Math.Pow(i, 2))) * VehicleWeight
                });
            }

            return rollingResistanceForce;
        }
    }
}
