using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seri2
{
    [Serializable]
    public class Rotor:ICE
    {
        public override object Clone()
        {
            return new Rotor();
        }
    }

    
}
