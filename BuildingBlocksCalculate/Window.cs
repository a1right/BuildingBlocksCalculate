using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocksCalculate
{
    public class Window : Squared
    {
        public Window GetWindowSize()
        {
            Window window = new Window();
            UserEntryValidation userEntryValidation = new UserEntryValidation();
            Console.WriteLine("Введите высоту окна в сантиметрах");
            window.Length = Math.Round((userEntryValidation.GetEntryParsedToDouble(Console.ReadLine()) / 100) , 2);

            Console.WriteLine("Введите ширину окна в сантиметрах");
            window.Width = Math.Round((userEntryValidation.GetEntryParsedToDouble(Console.ReadLine()) / 100) , 2);
            return window;
        }
        
    }
}
