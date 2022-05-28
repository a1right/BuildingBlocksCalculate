using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BuildingBlocksCalculate
{
    public class UserEntryValidation : IConsoleValidator
    {
        public bool DoorIsLargerThenBuilding(House house, Door door)
        {
            if (house.Length <= door.Width || house.Height <= door.Length || house.Width <= door.Width)
            {
                Console.WriteLine("Ошибка! Сторона двери не может быть больше стороны дома. Введите корректный размер двери");
                return false;
            }
            return true;
        }

        public double EntryIsCorrect(string input)
        {
            if (input == null || input == " ")
            {
                Console.WriteLine("Число не может быть пустым. Введите число.");
                EntryIsCorrect(Console.ReadLine());
            }
            if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                Console.WriteLine("Число введено некорректно.");
                EntryIsCorrect(Console.ReadLine());
            }
            if (result <= 0)
            {
                Console.WriteLine("Число не может отрицательным или равным нулю");
                EntryIsCorrect(Console.ReadLine());
            }
            return result;
        }

        public int EntryIsCorrectQuantity(string input)
        {
            if (input == null || input == " ")
            {
                Console.WriteLine("Число не может быть пустым. Введите число.");
                EntryIsCorrectQuantity(Console.ReadLine());
            }
            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Число введено некорректно.");
                EntryIsCorrectQuantity(Console.ReadLine());
            }
            if (result <= 0)
            {
                Console.WriteLine("Число не может отрицательным или равным нулю");
                EntryIsCorrectQuantity(Console.ReadLine());
            }
            return result;
        }

        public int BuildingBlockTypeIsCorrect(string input)
        {
            if (input == null || input == " ")
            {
                Console.WriteLine("Число не может быть пустым. Введите число.");
                BuildingBlockTypeIsCorrect(Console.ReadLine());
            }
            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Число введено некорректно.");
                BuildingBlockTypeIsCorrect(Console.ReadLine());
            }
            if (result <= 0)
            {
                Console.WriteLine("Число не может отрицательным или равным нулю");
                BuildingBlockTypeIsCorrect(Console.ReadLine());
            }
            if (result > Enum.GetNames(typeof(BlockType)).Length)
            {
                Console.WriteLine("Число больше чем количество блоков в ассортименте");
                BuildingBlockTypeIsCorrect(Console.ReadLine());
            }
            return result;
        }



        public bool WindowIsLargerThenBuilding(House house, Window window)
        {
            if (house.Length <= window.Width || house.Height <= window.Length || house.Width <= window.Width)
            {
                Console.WriteLine("Ошибка! Сторона окна не может быть больше стороны дома. Введите корректный размер окна");
                return false;
            }
            return true;
        }


    }
}
