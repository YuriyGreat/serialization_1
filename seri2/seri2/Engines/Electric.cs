using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seri2
{
    [Serializable]
    class Electric:Engine
    {
        private double revolutions;
        private string type;

        public void SetReavolutions(double revolutions)
        {
            this.revolutions = revolutions;
        }
        public double GetRevolutions()
        {
            return revolutions;
        }
        public void SetTypeOfEngine(string type)
        {
            this.type = type;
        }
        public string GetTypeOfEngine()
        {
            return type;
        }
        public override string[] GetAllFields()
        {
            string[] output = new string[4];
            output[0] = "мощность";
            output[1] = "тяга";
            output[2] = "обороты(100х/мин)";
            output[3] = "тип";
            return output;
        }
        public override string[] GetCaracteristics()
        {
            string[] caracteristics = new string[4];
            caracteristics[0] = GetPower().ToString();
            caracteristics[1] = GetPull().ToString();
            caracteristics[2] = GetRevolutions().ToString();
            caracteristics[3] = GetTypeOfEngine();
            return caracteristics;
        }
        public override bool SetCaracteristics(string[] caracteristics)
        {
            try
            {
                SetPower(Convert.ToDouble(caracteristics[0]));
                SetPull(Convert.ToDouble(caracteristics[1]));
                SetReavolutions(Convert.ToDouble(caracteristics[2]));
                SetTypeOfEngine(caracteristics[3]);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override object Clone()
        {
            return new Electric();
        }
    }
}
