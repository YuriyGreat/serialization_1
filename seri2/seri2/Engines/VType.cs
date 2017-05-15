﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seri2
{
    [Serializable]
    public class VType:ICE
    {
        private double cylinderCount;
        private double angle;

        public void SetCylinderCount(double cylinderCount)
        {
            this.cylinderCount = cylinderCount;
        }
        public double GetCylinderCount()
        {
            return cylinderCount;
        }

        public void SetAngle(double angle)
        {
            this.angle = angle;
        }
        public double GetAngle()
        {
            return angle;
        }

        public override string[] GetAllFields()
        {
            string[] output = new string[7];
            output[0] = "мощность(кВт)";
            output[1] = "тяга";
            output[2] = "тип топлива";
            output[3] = "крутящий момент";
            output[4] = "обороты(100х/мин)";
            output[5] = "количество цилиндров";
            output[6] = "угол развала цилиндров";
            return output;
        }
        public override string[] GetCaracteristics()
        {
            string[] caracteristics = new string[7];
            caracteristics[0] = GetPower().ToString();
            caracteristics[1] = GetPull().ToString();
            caracteristics[2] = GetFuelType();
            caracteristics[3] = GetTorque().ToString();
            caracteristics[4] = GetRevolutions().ToString();
            caracteristics[5] = GetCylinderCount().ToString();
            caracteristics[6] = GetAngle().ToString();
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
                SetCylinderCount(Convert.ToDouble(caracteristics[5]));
                SetAngle(Convert.ToDouble(caracteristics[6]));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override object Clone()
        {
            return new VType();
        }
    }
}
