using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seri2
{
    [Serializable]
    public abstract class Engine
    {
        protected double power;
        protected double pull;

        public void SetPower(double power)
        {
            this.power = power;
        }
        public void SetPull(double pull)
        {
            this.pull = pull;
        }

        public double GetPower()
        {
            return power;
        }
        public double GetPull()
        {
            return pull;
        }

        public abstract string[] GetAllFields();
        public abstract string[] GetCaracteristics();
        public abstract bool SetCaracteristics(string[] caracteristics);
        public abstract object Clone();
        
    }
}
