using System;
using System.Collections.Generic;
using VehicleTractionCharacteristicBl.Model;

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

        readonly List<Engine> Engine = new List<Engine>();

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
                                      List<Engine> engine,
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
            Engine = engine;
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

            List<int> number = new List<int>();

            for (int i = 0; i < Gears.Count; i++)
            {
                for (int j = 0; j < Engine.Count; j++)
                {
                    number.Add(Gears[i].GearNumber - 1);
                }
            }

            for (int j = 0; j < DynamicFactor.Count; j++)
            {
                accelerationCharacteristic.Add(new Acceleration
                {
                    GearNumber = DynamicFactor[j].GearNumber,
                    Speed = DynamicFactor[j].Speed,
                    AccelerationValue = (((DynamicFactor[j].DynamicFactorValue / 100) - CoefficientOfRollingResistance(DynamicFactor[j].Speed)) / (CoefficientOfInertia(Gears[number[j]].GearRatio))) * 9.81,
                    ReciprocalAccelerationValue = 1 / ((((DynamicFactor[j].DynamicFactorValue / 100) - CoefficientOfRollingResistance(DynamicFactor[j].Speed)) / (CoefficientOfInertia(Gears[number[j]].GearRatio))) * 9.81)
                });
            }

            return accelerationCharacteristic;
        }
    }
}
