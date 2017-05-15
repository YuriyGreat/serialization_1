using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seri2
{
    [Serializable]
    public class Reactive:Engine
    {
        private double fuelConsumption;
        private double airConsumption;
        private double exhaustTemperature;
        //private double weight;
        
        public void SetFuelConsumption(double fuelConsumption)
        {
            this.fuelConsumption = fuelConsumption;
        }
        public void SetAirConsumption(double airConsumption)
        {
            this.airConsumption = airConsumption;
        }
        public void SetExhaustTemperature(double exhaustTemperature)
        {
            this.exhaustTemperature = exhaustTemperature;
        }
        /*public void SetWeight(double weight)
        {
            this.weight = weight;
        } */
        
        public double GetFuelConsumption()
        {
            return fuelConsumption;
        }
        public double GetAirConsumption()
        {
            return airConsumption;
        }
        public double GetExhaustTemperature()
        {
            return exhaustTemperature;
        }
        /*public double GetWeight()
        {
            return weight;
        }*/

        public override string[] GetAllFields()
        {
            string[] output = new string[5];
            output[0] = "мощность";
            output[1] = "тяга";
            output[2] = "расход топлива";
            output[3] = "расход воздуха";
            output[4] = "температура выхлопа";
           // output[5] = "вес";
            return output;
        }
        public override string[] GetCaracteristics()
        {
            string[] caracteristics = new string[5];
            caracteristics[0] = GetPower().ToString();
            caracteristics[1] = GetPull().ToString();
            caracteristics[2] = GetFuelConsumption().ToString();
            caracteristics[3] = GetAirConsumption().ToString();
            caracteristics[4] = GetExhaustTemperature().ToString();
            //caracteristics[5] = GetWeight().ToString();
            return caracteristics;
        }
        public override bool SetCaracteristics(string[] caracteristics)
        {
            try
            {
                SetPower(Convert.ToDouble(caracteristics[0]));
                SetPull(Convert.ToDouble(caracteristics[1]));
                SetFuelConsumption(Convert.ToDouble(caracteristics[2]));
                SetAirConsumption(Convert.ToDouble(caracteristics[3]));
                SetExhaustTemperature(Convert.ToDouble(caracteristics[4]));
               // SetWeight(Convert.ToDouble(caracteristics[5]));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override object Clone()
        {
            return new Reactive();
        }
    }
}
