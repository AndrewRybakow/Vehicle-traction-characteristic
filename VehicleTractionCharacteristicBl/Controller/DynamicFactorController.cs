using System;
using System.Collections.Generic;
using VehicleTractionCharacteristicBl.Model;

namespace VehicleTractionCharacteristicBl.Controller
{
    public class DynamicFactorController
    {
        const double airDensity = 1.25;

        double WeightOnDriveWheels { get; }

        double DragCoefficient { get; }

        double ProjectionArea { get; }

        readonly List<TractionForce> TractionForce = new List<TractionForce>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="weightOnDriveWheels"> Weight on drive wheels. </param>
        /// <param name="dragCoefficient"> Drag coefficient. </param>
        /// <param name="projectionHeight"> Projection height. </param>
        /// <param name="projectionWidth"> Projection widtch. </param>
        /// <param name="fillingCoefficient"> Filling coefficient. </param>
        /// <param name="tractionForce"> Vehicle traction force. </param>
        public DynamicFactorController(double weightOnDriveWheels,
                                       double dragCoefficient,
                                       double projectionHeight,
                                       double projectionWidth,
                                       double fillingCoefficient,
                                       List<TractionForce> tractionForce)
        {
            WeightOnDriveWheels = weightOnDriveWheels;
            DragCoefficient = dragCoefficient;
            ProjectionArea = projectionHeight * projectionWidth * fillingCoefficient;
            TractionForce = tractionForce;
        }

        /// <summary>
        /// Calculate dynamic factor characteristic.
        /// </summary>
        /// <returns></returns>
        public List<DynamicFactor> Calculate()
        {
            List<DynamicFactor> dynamicFactorCharacteristic = new List<DynamicFactor>();

            for (int i = 0; i < TractionForce.Count; i++)
            {
                dynamicFactorCharacteristic.Add(new DynamicFactor
                {
                    GearNumber = TractionForce[i].GearNumber,
                    Speed = TractionForce[i].Speed,
                    DynamicFactorValue = ((TractionForce[i].TractionForceValue - (0.5 * DragCoefficient * airDensity * ProjectionArea * Math.Pow((TractionForce[i].Speed / 3.6), 2))) / (WeightOnDriveWheels)) * 100
                });
            }

            return dynamicFactorCharacteristic;
        }
    }
}
