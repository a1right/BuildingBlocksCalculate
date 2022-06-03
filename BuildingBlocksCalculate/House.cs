using System;


namespace BuildingBlocksCalculate
{
    public class House : Cubed, ICubed
    {
        public int WindowsCount { get; set; }

        public int DoorsCount { get; set; }

        public BuildingBlock BuildingBlockTypeUsed { get; set; }

        public int WallThicknessInBlocks { get; set; }

        public Door DoorSize { get; set; }

        public Window WindowSize { get; set; }

        public override double CubeVolumeCalculate()
        {
            double volumeWithDoorsAndWindows = Math.Round(((this.Length * this.Height * this.Width) - 
                                               ((this.Length - this.BuildingBlockTypeUsed.Length * this.WallThicknessInBlocks) *
                                               (this.Width - this.BuildingBlockTypeUsed.Width * this.WallThicknessInBlocks) * 
                                               (this.Height - this.BuildingBlockTypeUsed.Height * this.WallThicknessInBlocks))), 2);
            double volume = Math.Round((volumeWithDoorsAndWindows - 
                                       (this.DoorSize.Length * this.DoorSize.Width * this.BuildingBlockTypeUsed.Width * this.WallThicknessInBlocks) * DoorsCount - 
                                       (this.WindowSize.Length * this.WindowSize.Width * this.BuildingBlockTypeUsed.Width * this.WallThicknessInBlocks) * WindowsCount), 2);
            return volume;
        }

        public House GetHouseOuterDimensions()
        {
            House house = new House();
            UserEntryValidation userEntryValidation = new UserEntryValidation();
            Console.WriteLine("Введите длину дома в метрах");
            this.Length = userEntryValidation.GetEntryParsedToDouble(Console.ReadLine());

            Console.WriteLine("Введите ширину дома в метрах");
            this.Width = userEntryValidation.GetEntryParsedToDouble(Console.ReadLine());

            Console.WriteLine("Введите высоту дома в метрах");
            this.Height = userEntryValidation.GetEntryParsedToDouble(Console.ReadLine());

            return house;
        }

        public void GetWindowsCount(House house)
        {
            UserEntryValidation usersEntryValidation = new UserEntryValidation();
            Console.WriteLine("Введите количество окон в доме");
            house.WindowsCount = usersEntryValidation.GetEntryParsedToInt(Console.ReadLine());
            
        }

        public void GetDoorsCount(House house)
        {
            UserEntryValidation usersEntryValidation = new UserEntryValidation();
            Console.WriteLine("Введите количество дверей в доме");
            house.DoorsCount = usersEntryValidation.GetEntryParsedToInt(Console.ReadLine());

        }

        public Window CheckWindowsSquareIsLesserThenHouseSquare(House house)
        {
            UserEntryValidation userEntryValidation = new UserEntryValidation();
            bool correct = true;
            if (house.Length <= house.WindowSize.Width || house.Height <= house.WindowSize.Length || house.Width <= house.WindowSize.Width)
                correct = false;
            if ((house.Length * house.Width) * house.Height * 2 < house.WindowSize.SquareAreaCalculate() * house.WindowsCount)
                correct = false;

            while (!correct)
            {
                Console.WriteLine("Ошибка, общая площадь окон не может быть больше площади стен дома, введите заново размер и количество окон");
                house.WindowSize = house.WindowSize.GetWindowSize();
                house.GetWindowsCount(house);
                if (house.Length <= house.WindowSize.Width || house.Height <= house.WindowSize.Length || house.Width <= house.WindowSize.Width)
                    correct = false;
                if ((house.Length * house.Width) * house.Height * 2 < house.WindowSize.SquareAreaCalculate() * house.WindowsCount)
                    correct = false;
            }
            return house.WindowSize;
        }

        public Door CheckDoorSquareIsLesserThenHouseSquare(House house)
        {
            UserEntryValidation userEntryValidation = new UserEntryValidation();
            bool correct = true;
            if (house.Length <= DoorSize.Width || house.Width <= house.DoorSize.Width || house.Height <= house.DoorSize.Length)
                correct = false;
            if ((house.Length * house.Width) * house.Height * 2 <= house.DoorSize.SquareAreaCalculate() * house.DoorsCount)
                correct = false;

            while(!correct)
            {
                Console.WriteLine("Ошибка, общая площадь дверей или их линейный размер больше площади стен дома или их линейного размера. Введите заново размер и количество дверей");
                house.DoorSize = house.DoorSize.GetDoorSize();
                house.GetDoorsCount(house);
                if (house.Length <= DoorSize.Width || house.Width <= house.DoorSize.Width || house.Height <= house.DoorSize.Length)
                    correct = false;
                if ((house.Length * house.Width) * house.Height * 2 < house.DoorSize.SquareAreaCalculate() * house.DoorsCount)
                    correct = false;
            }
            return house.DoorSize;
        }

        public BuildingBlock GetBuildingBlockTypeUsed(House house)
        {
            UserEntryValidation userEntryValidation = new UserEntryValidation();
            Console.WriteLine("Введите тип используемых блоков");
            BlockType blockType = (BlockType)userEntryValidation.BuildingBlockTypeIsCorrect(Console.ReadLine());
            return new BuildingBlock(blockType);
        }

        public void GetWallThicknessInBlocks(House house)
        {
            UserEntryValidation userEntryValidation = new UserEntryValidation();
            house.WallThicknessInBlocks = userEntryValidation.GetEntryParsedToInt(Console.ReadLine());
        }

            public int BlocksToBuildHouseCount (House house)
        {

            return (int)Math.Ceiling( house.CubeVolumeCalculate() / house.BuildingBlockTypeUsed.CubeVolumeCalculate());
        }

        public double BlocksToBuildHouseVolume (House house)
        {
            return Math.Round((BlocksToBuildHouseCount(house) * house.BuildingBlockTypeUsed.CubeVolumeCalculate()), 2);
        }

        public double HouseWeightInKg (House house)
        {
            return Math.Round((house.BlocksToBuildHouseVolume(this) * house.BuildingBlockTypeUsed.Density), 2);
        }
    }
}
