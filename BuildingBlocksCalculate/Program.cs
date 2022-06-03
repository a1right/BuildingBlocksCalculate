namespace BuildingBlocksCalculate
{
    public interface ISquared
    {
        double SquareAreaCalculate();

    }

    public interface ICubed
    {
        double CubeVolumeCalculate();
    }

   

    class Program
    {
        static void Main(string[] args)
        {
            UserEntryValidation userEntryValidation = new UserEntryValidation();
            Console.WriteLine("Здраствуйте, приветствуем вас в калькуляторе пеноблоков!");

            House house = new House();
            house.GetHouseOuterDimensions();

            Door door = new Door();
            house.DoorSize = door.GetDoorSize();
            house.GetDoorsCount(house);
            house.DoorSize = house.CheckDoorSquareIsLesserThenHouseSquare(house);

            Window window = new Window();
            house.WindowSize = window.GetWindowSize();
            house.GetWindowsCount(house);
            house.WindowSize = house.CheckWindowsSquareIsLesserThenHouseSquare(house);

            Console.Clear();

            List <BuildingBlock> buildingBlocks = new List <BuildingBlock>();
            foreach (BlockType blockType in Enum.GetValues(typeof(BlockType)))
            {
                buildingBlocks.Add(new BuildingBlock(blockType));
            }
            for(int i = 0; i < buildingBlocks.Count; i++)
            {
                Console.WriteLine($"Тип-{i + 1}: Длинна - {(int)(buildingBlocks[i].Length * 1000)} миллиметров (мм)," +
                                  $"Толщина - {(int)(buildingBlocks[i].Width * 1000)} мм, " +
                                  $"Высота - {(int)(buildingBlocks[i].Height * 1000)} мм. " +
                                  $"Марка D{(int)buildingBlocks[i].Density}.");
            }

            
            house.BuildingBlockTypeUsed = house.GetBuildingBlockTypeUsed(house);
            

            Console.WriteLine("Введите толщину стен в блоках");
            house.GetWallThicknessInBlocks(house);
            
            Console.Clear();

            Console.WriteLine($"- Общее количество блоков необходимых для строения {house.BlocksToBuildHouseCount(house)} штук." +
                              $"\n- Общий объем блоков {house.BlocksToBuildHouseVolume(house)} метров кубических." +
                              $"\n- Количество блоков в 1 кубическом метре - {house.BuildingBlockTypeUsed.BlocksCountInOneCubicMeter(house.BuildingBlockTypeUsed)}" +
                              $"\n- Общий вес строения в килограммах - {house.HouseWeightInKg(house)}");
            Console.ReadLine();
        }
    }
}