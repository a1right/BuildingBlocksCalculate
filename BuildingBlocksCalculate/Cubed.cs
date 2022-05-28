using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocksCalculate
{
    public abstract class Cubed : Squared, ICubed
    {
        public double Height { get; set; }

        public virtual double CubeVolumeCalculate()
        {
            double volume = Math.Round((this.Length * this.Width * this.Height), 2);
            return volume;
        }
    }
}
