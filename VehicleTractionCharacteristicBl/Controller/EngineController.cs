using System.Collections.Generic;
using VehicleTractionCharacteristicBl.Model;

namespace VehicleTractionCharacteristicBl.Controller
{
    public class EngineController
    {
        // Maximum engine frequency
        int MaxFrequency { get; }

        // Minimum engine frequency
        int MinFrequency { get; }

        // Step of calculations
        int Step { get; }

        // Frequency at maximum engine power
        double FrequencyMaxPower { get; }

        // Coefficient of engine flexibility by torque
        double CoefKm { get; }

        // Coefficient of engine flexibility by frequency
        double CoefKn { get; }

        // Coefficients a, b, c for ICE according to  A. I. Grishkevich
        double CoefA { get; }
        double CoefB { get; }
        double CoefC { get; }

        // Maximum engine power
        double MaxPower { get; }

        // Minimum engine fuel consumption
        double MinFConsumption { get; }

        List<int> Frequency = new List<int>();
        List<double> Power = new List<double>();
        List<double> Torque = new List<double>();
        List<double> Consumption = new List<double>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxFrequency"> Maximum engine frequency. </param>
        /// <param name="minFrequency"> Minimum engine frequency. </param>
        /// <param name="step"> Step of calculations. </param>
        /// <param name="maxTorque"> Maximum engine torque. </param>
        /// <param name="torqueMaxPower"> Torque at maximum engine power. </param>
        /// <param name="frequencyMaxPower"> Frequency at maximum engine power. </param>
        /// <param name="frequencyMaxTorque"> Frequency at maximum engine torque. </param>
        /// <param name="maxPower"> Maximum engine power. </param>
        /// <param name="minFConsumption"> Minimum engine fuel consumption. </param>
        public EngineController(int maxFrequency,
                                int minFrequency,
                                int step,
                                double maxTorque,
                                double torqueMaxPower,
                                double frequencyMaxPower,
                                double frequencyMaxTorque,
                                double maxPower,
                                double minFConsumption)
        {
            MaxFrequency = maxFrequency;
            MinFrequency = minFrequency;
            Step = step;

            FrequencyMaxPower = frequencyMaxPower;

            CoefKm = maxTorque / torqueMaxPower;
            CoefKn = frequencyMaxPower / frequencyMaxTorque;

            CoefA = ((CoefKm * CoefKn * (2 - CoefKn)) - 1) / ((CoefKn * (2 - CoefKn)) - 1);

            CoefB = -((2 * CoefKn * (CoefKm - 1)) / ((CoefKn * (2 - CoefKn)) - 1));

            CoefC = (CoefKn * CoefKn * (CoefKm - 1)) / ((CoefKn * (2 - CoefKn)) - 1);

            MaxPower = maxPower;

            MinFConsumption = minFConsumption;
        }

        /// <summary>
        /// Calculate engine frequency characteristic. 
        /// </summary>
        /// <param name="maxFrequency"> Maximum engine frequency. </param>
        /// <param name="minFrequency"> Minimum engine frequency. </param>
        /// <param name="step"> Step of calculations. </param>
        /// <returns></returns>
        List<int> CalculateFrequency(int maxFrequency, int minFrequency, int step)
        {
            List<int> frequencylist = new List<int>();

            for (int i = minFrequency; i <= maxFrequency; i += step)
            {
                frequencylist.Add(i);
            }

            return frequencylist;
        }

        /// <summary>
        /// Calculate engine power characteristic.
        /// </summary>
        /// <param name="maxPower"> Maximum engine power. </param>
        /// <param name="a"> Coefficient a for ICE according to  A. I. Grishkevich. </param>
        /// <param name="b"> Coefficient b for ICE according to  A. I. Grishkevich. </param>
        /// <param name="c"> Coefficient c for ICE according to  A. I. Grishkevich. </param>
        /// <param name="frequencyMaxPower"> Frequency at maximum engine power. </param>
        /// <param name="frequency"> Engine frequency characteristic. </param>
        /// <returns></returns>
        List<double> CalculatePower(double maxPower, double a, double b, double c, double frequencyMaxPower, List<int> frequency)
        {
            List<double> list = new List<double>();
            for (int i = 0; i < frequency.Count; i++)
            {
                list.Add(maxPower * ((a * (frequency[i] / frequencyMaxPower)) + (b * System.Math.Pow((frequency[i] / frequencyMaxPower), 2)) + (c * System.Math.Pow((frequency[i] / frequencyMaxPower), 3))));
            }

            return list;
        }

        /// <summary>
        /// Calculate engine torque characteristic.
        /// </summary>
        /// <param name="power"> Engine power characteristic. </param>
        /// <param name="frequency"> Engine frequency characteristic. </param>
        /// <returns></returns>
        List<double> CalculateTorque(List<double> power, List<int> frequency)
        {
            List<double> list = new List<double>();
            for (int i = 0; i < frequency.Count; i++)
            {
                list.Add(9550 * (power[i] / frequency[i]));
            }

            return list;
        }

        /// <summary>
        /// Calculate engine specific fuel consumption characteristic.
        /// </summary>
        /// <param name="minFConsumption"> Minimum engine fuel consumption. </param>
        /// <param name="frequencyMaxPower"> Frequency at maximum engine power. </param>
        /// <param name="frequnecy"> Engine frequency characteristic. </param>
        /// <returns></returns>
        List<double> CalculateConsumption(double minFConsumption, double frequencyMaxPower, List<int> frequnecy)
        {
            List<double> list = new List<double>();
            for (int i = 0; i < frequnecy.Count; i++)
            {
                list.Add(minFConsumption * (1.55 - (1.55 * (frequnecy[i] / frequencyMaxPower)) + System.Math.Pow((frequnecy[i] / frequencyMaxPower), 2)));
            }

            return list;
        }

        /// <summary>
        /// Calculate external engine characteristic.
        /// </summary>
        /// <returns></returns>
        public List<Engine> Calculate()
        {
            List<Engine> engine = new List<Engine>();

            Frequency = CalculateFrequency(MaxFrequency, MinFrequency, Step);

            Power = CalculatePower(MaxPower, CoefA, CoefB, CoefC, FrequencyMaxPower, Frequency);

            Torque = CalculateTorque(Power, Frequency);

            Consumption = CalculateConsumption(MinFConsumption, FrequencyMaxPower, Frequency);

            for (int i = 0; i < Frequency.Count; i++)
            {
                engine.Add(new Engine()
                {
                    Frequency = Frequency[i],
                    Power = Power[i],
                    Torque = Torque[i],
                    Consumption = Consumption[i]
                });
            }

            return engine;
        }
    }
}
