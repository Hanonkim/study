using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Projects.Calc
{
    public static class OperatorManager
    {
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        public static double Substract(double num1, double num2)
        {
            return num1 - num2;
        }
        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }
        public static double Divide(double num1, double num2)
        {
            if(num2 == 0)
            {
                return double.MaxValue;
            }
            return num1 / num2;
        }
        public static double Squared(double num1, double num2)
        {
            return Math.Pow(num1, num2);
        }
    }
    internal class ClacMain
    {
        public void PrintCalc()
        {
            while (true)
            {
                int num1, num2, chooseOperator;
                double result = 0;
                Console.WriteLine("1.덧셈\t2.뺄셈\t3.곱셈\t4.나눗\t5.제곱");
                chooseOperator = int.Parse(Console.ReadLine());
                Console.WriteLine("1번째 수 입력: ");
                num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("2번째 수 입력: ");
                num2 = int.Parse(Console.ReadLine());

                switch (chooseOperator)
                {
                    case 1:
                        result = OperatorManager.Add(num1, num2);
                        break;
                    case 2:
                        result = OperatorManager.Substract(num1, num2);
                        break;
                    case 3:
                        result = OperatorManager.Multiply(num1, num2);
                        break;
                    case 4:
                        result = OperatorManager.Divide(num1, num2);
                        break;
                    case 5:
                        result = OperatorManager.Squared(num1, num2);
                        break;
                    default:
                        break;
                }

                if(result == double.MaxValue)
                {
                    Console.WriteLine("에러 발생! 0으로 나누었습니다.");
                    continue;
                }

                Console.WriteLine($"결과 = {result}");
            }
        }
        static void Main(string[] args)
        {
            ClacMain clacMain = new ClacMain();
            clacMain.PrintCalc();
        }
    }
}
