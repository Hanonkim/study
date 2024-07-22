using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    internal class Selection
    {
        static void Main(string[] args)
        {
            #region if
            string health = Console.ReadLine();
            int result;
            if (int.TryParse(health, out result))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(result);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("입력오류");
            }
            #endregion

            #region switch

            #endregion
        }
    }
}
