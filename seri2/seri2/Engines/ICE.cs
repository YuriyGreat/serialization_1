using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seri2
{
    [Serializable]
    public abstract class ICE:Engine//internal combustion engine
    {
        private string fuel;
        private double torque;
        private double revolutions;
        
        public void SetFuelType(string fuel)
        {
            this.fuel = fuel;
        }
        public string GetFuelType()
        {
            return fuel;
        }
        public void SetTorque(double torque)
        {
            this.torque = torque;
        }
        public double GetTorque()
        {
            return torque;
        }
        public void SetReavolutions(double revolutions)
        {
            this.revolutions = revolutions;
        }
        public double GetRevolutions()
        {
            return revolutions;
        }
        public override string[] GetAllFields()
        {
            string[] output = new string[5];
            output[0] = "мощность(кВт)";
            output[1] = "тяга";
            output[2] = "тип топлива";
            output[3] = "крутящий момент";
            output[4] = "обороты(100х/мин)";
            return output;
        }
        public override string[] GetCaracteristics()
        {
            string[] caracteristics = new string[5];
            caracteristics[0] = GetPower().ToString();
            caracteristics[1] = GetPull().ToString();
            caracteristics[2] = GetFuelType();
            caracteristics[3] = GetTorque().ToString();
            caracteristics[4] = GetRevolutions().ToString();
            return caracteristics;
        }
        public override bool SetCaracteristics(string[] caracteristics)
        {
            try
            {
                SetPower(Convert.ToDouble(caracteristics[0]));
                SetPull(Convert.ToDouble(caracteristics[1]));
                SetFuelType(caracteristics[2]);
                SetTorque(Convert.ToDouble(caracteristics[3]));
                SetReavolutions(Convert.ToDouble(caracteristics[4]));
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
