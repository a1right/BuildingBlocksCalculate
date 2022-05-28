using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocksCalculate
{
    public abstract class Squared : ISquared
    {
        public double Length { get; set; }

        public double Width { get; set; }

        public double SquareAreaCalculate()
        {
            double squareArea = Math.Round((this.Length * this.Width), 2);
            return squareArea;
        }
    }
}
