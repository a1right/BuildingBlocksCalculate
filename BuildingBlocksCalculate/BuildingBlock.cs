using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocksCalculate
{
    public enum BlockType
    {
        D500 = 1,
        D600,
        D700
    }
    public class BuildingBlock : Cubed
    {
        public BuildingBlock(BlockType blockType)
        {
            if (blockType == BlockType.D500)
            {
                this.Length = 0.6;
                this.Width = 0.2;
                this.Height = 0.3;
                this.Density = 500;
            }

            if (blockType == BlockType.D600)
            {
                this.Length = 0.6;
                this.Width = 0.25;
                this.Height = 0.4;
                this.Density = 600;
            }

            if (blockType == BlockType.D700)
            {
                this.Length = 0.6;
                this.Width = 0.2;
                this.Height = 0.3;
                this.Density = 700;
            }
        }

        public double Density { get; set; }
        public BuildingBlock BuildingBlockType { get; set; }

        public int BlocksInOneCubicMeter(BuildingBlock buildingBlock)
        {
            return (int)Math.Ceiling(1 / this.CubeVolumeCalculate());
        }
    }
}
