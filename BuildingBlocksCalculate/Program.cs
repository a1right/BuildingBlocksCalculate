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

    public interface IConsoleValidator
    {
        double EntryIsCorrect(string input);
       
        

        bool WindowIsLargerThenBuilding(House house, Window window);

        bool DoorIsLargerThenBuilding(House house, Door door);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здраствуйте, приветствуем вас в калькуляторе пеноблоков!");
            Console.WriteLine("Введите длину дома в метрах");
            UserEntryValidation userEntryValidation = new UserEntryValidation();
            House house = new House();
            house.Length = userEntryValidation.EntryIsCorrect(Console.ReadLine());
            Console.WriteLine("Введите ширину дома в метрах");
            house.Width = userEntryValidation.EntryIsCorrect(Console.ReadLine());
            Console.WriteLine("Введите высоту дома в метрах");
            house.Height = userEntryValidation.EntryIsCorrect(Console.ReadLine());
            Console.WriteLine("Введите размер двери в сантиметрах");
            Door door = new Door();
            while(true)
            {
                Console.WriteLine("Введите высоту двери");
                door.Length = (userEntryValidation.EntryIsCorrect(Console.ReadLine())) / 100;
                Console.WriteLine("Введите ширину двери");
                door.Width = (userEntryValidation.EntryIsCorrect(Console.ReadLine())) / 100;
                if (userEntryValidation.DoorIsLargerThenBuilding(house, door))
                {
                    house.DoorSize = door;
                    break;
                }
            }

            Console.WriteLine("Сколько дверей в доме?");
            house.DoorsCount = userEntryValidation.EntryIsCorrectQuantity(Console.ReadLine());
            Console.WriteLine("Введите размер окна в сантиметрах");
            Window window = new Window();
            while (true)
            {
                Console.WriteLine("Введите высоту окна");
                window.Length = userEntryValidation.EntryIsCorrect(Console.ReadLine()) / 100;
                Console.WriteLine("Введите ширину окна");
                window.Width = userEntryValidation.EntryIsCorrect(Console.ReadLine()) / 100;
                if (userEntryValidation.WindowIsLargerThenBuilding(house, window))
                {
                    house.WindowSize = window;
                    break;
                }
            }
            Console.WriteLine("Сколько окон в доме?");
            house.WindowsCount = userEntryValidation.EntryIsCorrectQuantity(Console.ReadLine());
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

            Console.WriteLine("Введите тип используемых блоков");
            house.BlockTypeUsed = new BuildingBlock((BlockType)userEntryValidation.BuildingBlockTypeIsCorrect(Console.ReadLine()));
            Console.Clear();

            Console.WriteLine($"- Общее количество блоков необходимых для строения {house.BlocksToBuildHouseCount(house)} штук." +
                              $"\n- Общий объем блоков {house.BlocksToBuildHouseVolume(house)} метров кубических." +
                              $"\n- Количество блоков в 1 кубическом метре - {house.BlockTypeUsed.BlocksInOneCubicMeter(house.BlockTypeUsed)}" +
                              $"\n- Общий вес строения в килограммах - {house.HouseWeightInKg(house)}");
        }
    }
}