using System.Globalization;
using System.Collections.Generic;

namespace BuildingBlocksCalculate
{
    public class UserEntryValidation
    {
        

        public double GetEntryParsedToDouble(string input)
        {
            
            bool correct = double.TryParse(input,NumberStyles.AllowDecimalPoint ,CultureInfo.CurrentCulture, out double result);
            if (result <= 0)
            {
                correct = false;
            }
            while(!correct)
                {
                Console.WriteLine("Некорректный ввод, попробуйте еще раз");
                correct = double.TryParse(Console.ReadLine() ,NumberStyles.AllowDecimalPoint , CultureInfo.CurrentCulture, out result);
                if(result <= 0)
                    correct = false;
                }
            return result;
        }

        public int GetEntryParsedToInt(string input)
        {
            UserEntryValidation userEntryValidation = new UserEntryValidation();
            bool correct = int.TryParse(input,NumberStyles.AllowDecimalPoint ,CultureInfo.CurrentCulture, out int result);
            if (result <= 0)
                correct = false;
            while(!correct)
            {
                Console.WriteLine("Некорректный ввод, попробуйте ещё раз");
                correct = int.TryParse(Console.ReadLine(), out result);
                if (result <= 0)
                    correct = false;
            }
            return result;
        }

        public int BuildingBlockTypeIsCorrect(string input)
        {
            bool correct = int.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out int result);
            if (result <= 0 || result > Enum.GetNames(typeof(BlockType)).Length)
                correct = false;
            while(!correct)
            {
                Console.WriteLine("Блока такого типа нет в нашем каталоге");
                correct = int.TryParse(Console.ReadLine(), out result);

            }
            return result;
        }



        
                
        
    }
}
