using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    internal class Prac_switch
    {
        static void Main(string[] args)
        {
            int mode;
            string input;

            Console.Write("경계태세 단계 입력: ");
            input = Console.ReadLine();

            if (!int.TryParse(input, out mode)) { Console.WriteLine("오입력!"); }

            else
            {
                #region if
                if (mode == 1) { Console.WriteLine("Cocked Pistol!"); }
                else if (mode == 2) { Console.WriteLine("Fast Pace!"); }
                else if (mode == 3) { Console.WriteLine("Round House!"); }
                else { Console.WriteLine("비상 태세!"); }
                #endregion

                #region switch
                switch (mode)
                {
                    case 1:
                        Console.WriteLine("Cocked Pistol!");
                        break;
                    case 2:
                        Console.WriteLine("Fast Pace!");
                        break;
                    case 3:
                        Console.WriteLine("Round Housel!");
                        break;
                    default:
                        Console.WriteLine("비상 태세!");
                        break;
                }
                #endregion
                }

        }
    }
}
