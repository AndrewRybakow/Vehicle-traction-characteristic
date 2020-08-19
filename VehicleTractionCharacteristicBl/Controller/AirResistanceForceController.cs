using System;
using System.Collections.Generic;
using System.Linq;
using VehicleTractionCharacteristicBl.Model;

namespace VehicleTractionCharacteristicBl.Controller
{
    public class AirResistanceForceController
    {
        double DragCoefficient { get; }

        double AirDensity { get; }

        double ProjectionArea { get; }

        readonly List<Speed> Speed = new List<Speed>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dragCoefficient"> Vehicle drag coefficient. </param>
        /// <param name="airDensity"> Air density. </param>
        /// <param name="projectionHeight"> Projection height. </param>
        /// <param name="projectionWidth"> Projection width. </param>
        /// <param name="fillingCoefficient"> Projection filling coefficient. </param>
        /// <param name="speed"> Vehicle speed. </param>
        public AirResistanceForceController(double dragCoefficient,
                                            double airDensity,
                                            double projectionHeight,
                                            double projectionWidth,
                                            double fillingCoefficient,
                                            List<Speed> speed)
        {
            DragCoefficient = dragCoefficient;
            AirDensity = airDensity;
            ProjectionArea = projectionHeight * projectionWidth * fillingCoefficient;
            Speed = speed;
        }

        /// <summary>
        /// Calculate air resistance force.
        /// </summary>
        /// <returns></returns>
        public List<AirResistanceForce> Calculate()
        {
            List<AirResistanceForce> airResistanceForce = new List<AirResistanceForce>();

            int maxSpeed = (int)Math.Ceiling(Speed.Max(Speed => Speed.SpeedValue));

            for (int i = 0; i < maxSpeed; i++)
            {
                airResistanceForce.Add(new AirResistanceForce
                {
                    Speed = i,
                    AirResistanceForceValue = 0.5 * DragCoefficient * AirDensity * ProjectionArea * (Math.Pow((i / 3.6), 2))
                });
            }

            return airResistanceForce;
        }
    }
}
