using System;
using System.Collections.Generic;
using VehicleTractionCharacteristicBl.Model;
using System.Linq;

namespace VehicleTractionCharacteristicBl.Controller
{
    public class AccelerationController
    {
        double VehicleMass { get; }

        int NumberOfWheels { get; }

        double WheelRadius { get; }

        double RollingResistanceCoefficient { get; }

        double WheelMomentOfInertia { get; }

        double MotorMomentOfInertia { get; }

        double FinalDriveRatio { get; }

        double CoefOfTransEfficiency { get; }

        readonly List<Gear> Gears = new List<Gear>();

        readonly List<DynamicFactor> DynamicFactor = new List<DynamicFactor>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vehicleMass"> Vehicle mass. </param>
        /// <param name="numberOfWheels"> Number of car wheels. </param>
        /// <param name="wheelRadius"> Wheel radius. </param>
        /// <param name="rollingResistanceCoefficient"> Coefficient of rolling resistance. </param>
        /// <param name="wheelMomentOfInertia"> Wheel's moment of inertia. </param>
        /// <param name="motorMomentOfInertia"> Motor's moment of inertia. </param>
        /// <param name="finalDriveRatio"> Final drive ratio. </param>
        /// <param name="coefOfTransEfficiency"> Coefficient of transmission efficiency. </param>
        /// <param name="gears"> Vehicle gears. </param>
        /// <param name="dynamicFactor"> Vehicle dynamic factor. </param>
        public AccelerationController(double vehicleMass,
                                      int numberOfWheels,
                                      double wheelRadius,
                                      double rollingResistanceCoefficient,
                                      double wheelMomentOfInertia,
                                      double motorMomentOfInertia,
                                      double finalDriveRatio,
                                      double coefOfTransEfficiency,
                                      List<Gear> gears,
                                      List<DynamicFactor> dynamicFactor)
        {
            VehicleMass = vehicleMass;
            NumberOfWheels = numberOfWheels;
            WheelRadius = wheelRadius;
            RollingResistanceCoefficient = rollingResistanceCoefficient;
            WheelMomentOfInertia = wheelMomentOfInertia;
            MotorMomentOfInertia = motorMomentOfInertia;
            FinalDriveRatio = finalDriveRatio;
            CoefOfTransEfficiency = coefOfTransEfficiency;
            Gears = gears;
            DynamicFactor = dynamicFactor;
        }

        /// <summary>
        /// Coefficient of rolling resistance.
        /// </summary>
        /// <param name="speed"> Speed </param>
        /// <returns></returns>
        double CoefficientOfRollingResistance(double speed)
        {
            return RollingResistanceCoefficient * (1 + (0.00005 * Math.Pow(speed, 2)));
        }

        /// <summary>
        /// Сoefficient of influence of inertia of rotating masses.
        /// </summary>
        /// <param name="gearRatio"> Gear ratio in the gearbox. </param>
        /// <returns></returns>
        double CoefficientOfInertia(double gearRatio)
        {
            double motor = (MotorMomentOfInertia * Math.Pow(FinalDriveRatio, 2) * CoefOfTransEfficiency) / (Math.Pow(WheelRadius, 2) * VehicleMass);

            double wheel = (WheelMomentOfInertia * NumberOfWheels) / (Math.Pow(WheelRadius, 2) * VehicleMass);

            double coefficient = 1 + (motor * Math.Pow(gearRatio, 2) + wheel);

            return coefficient;
        }

        /// <summary>
        /// Calculate acceleration characteristic.
        /// </summary>
        /// <returns></returns>
        public List<Acceleration> Caclculate()
        {
            List<Acceleration> accelerationCharacteristic = new List<Acceleration>();

            List<DynamicFactor> dynamicFactorByGearInGearbox = new List<DynamicFactor>();

            // Get dynamic factor for gears in gearbox

            dynamicFactorByGearInGearbox = (from dynamicfactor in DynamicFactor
                                            where dynamicfactor.GearNumber > 0 && dynamicfactor.GearNumber <= Gears.Count
                                            select dynamicfactor).ToList();

            // Calculate acceleration characteristic

            for (int j = 0; j < dynamicFactorByGearInGearbox.Count; j++)
            {
                accelerationCharacteristic.Add(new Acceleration
                {
                    GearNumber = dynamicFactorByGearInGearbox[j].GearNumber,
                    Speed = dynamicFactorByGearInGearbox[j].Speed,
                    AccelerationValue = (((dynamicFactorByGearInGearbox[j].DynamicFactorValue / 100) - CoefficientOfRollingResistance(dynamicFactorByGearInGearbox[j].Speed)) / (CoefficientOfInertia(Gears[dynamicFactorByGearInGearbox[j].GearNumber - 1].GearRatio))) * 9.81,
                    ReciprocalAccelerationValue = 1 / ((((dynamicFactorByGearInGearbox[j].DynamicFactorValue / 100) - CoefficientOfRollingResistance(dynamicFactorByGearInGearbox[j].Speed)) / (CoefficientOfInertia(Gears[dynamicFactorByGearInGearbox[j].GearNumber - 1].GearRatio))) * 9.81)
                });
            }

            return accelerationCharacteristic;
        }
    }
}
