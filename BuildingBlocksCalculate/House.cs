using System;


namespace BuildingBlocksCalculate
{
    public class House : Cubed, ICubed
    {
        public int WindowsCount { get; set; }

        public int DoorsCount { get; set; }

        public BuildingBlock BlockTypeUsed { get; set; }

        public Door DoorSize { get; set; }

        public Window WindowSize { get; set; }

        public override double CubeVolumeCalculate()
        {
            double volumeWithDoorsAndWindows = Math.Round(((this.Length * this.Height * this.Width) - 
                                               ((this.Length - this.BlockTypeUsed.Length) *
                                               (this.Width - this.BlockTypeUsed.Width) * 
                                               (this.Height - this.BlockTypeUsed.Height))), 2);
            double volume = Math.Round((volumeWithDoorsAndWindows - 
                                       (this.DoorSize.Length * this.DoorSize.Width * this.BlockTypeUsed.Width) * DoorsCount - 
                                       (this.WindowSize.Length * this.WindowSize.Width * this.BlockTypeUsed.Width) * WindowsCount), 2);
            return volume;
        }

        public int BlocksToBuildHouseCount (House house)
        {
            return (int)Math.Ceiling( house.CubeVolumeCalculate() / house.BlockTypeUsed.CubeVolumeCalculate());
        }

        public double BlocksToBuildHouseVolume (House house)
        {
            return Math.Round((BlocksToBuildHouseCount(house) * house.BlockTypeUsed.CubeVolumeCalculate()), 2);
        }

        public double HouseWeightInKg (House house)
        {
            return Math.Round((house.BlocksToBuildHouseVolume(this) * house.BlockTypeUsed.Density), 2);
        }
    }
}
