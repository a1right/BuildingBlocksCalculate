using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocksCalculate
{
    public class Door : Squared
    {
        public Door GetDoorSize()
        {
            Door door = new Door();
            UserEntryValidation userEntryValidation = new UserEntryValidation();
            Console.WriteLine("Введите высоту двери в сантиметрах");
            door.Length = Math.Round((userEntryValidation.GetEntryParsedToDouble(Console.ReadLine()) / 100) , 2);

            Console.WriteLine("Введите ширину двери в сантиметрах");
            door.Width = Math.Round((userEntryValidation.GetEntryParsedToDouble(Console.ReadLine()) / 100) , 2);

            return door;
        }
    }
}
