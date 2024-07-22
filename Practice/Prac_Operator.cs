using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    internal class Prac_Operator
    {
        static void Main(string[] args)
        {
            #region 이름 입력받아 출력
            Console.Write("당신의 이름을 입력해주세요: ");  //WriteLine은 개행O, Write은 개행X
            string name = Console.ReadLine();
            Console.WriteLine(name);
            #endregion

            #region 두 수의 합 출력
            float a, b;
            Console.Write("첫번째 실수를 입력해주세요: ");
            string input1 = Console.ReadLine();
            float.TryParse(input1, out a);

            Console.Write("두번째 실수를 입력해주세요: ");
            string input2 = Console.ReadLine();
            float.TryParse(input2, out b);

            float result = a + b;
            Console.WriteLine($"두 수의 합은 {result}입니다.");
            #endregion

            #region 두 정수의 몫/나머지 출력
            int c, d;
            Console.Write("나눠질 수 입력: ");
            string input3 = Console.ReadLine();
            int.TryParse(input3, out c);

            Console.Write("나눌 수 입력: ");
            string input4 = Console.ReadLine();
            int.TryParse(input4, out d);

            int result1 = c / d;
            int result2 = c % d;
            Console.WriteLine($"{c}와{d}의 나눗셈 결과 : 몫은 {result1}, 나머지는 {result2}");
            #endregion

            #region 입력된 세 정수의 합/곱 출력
            int e, f, g;

            Console.Write("첫번째 수 입력: ");
            string input5 = Console.ReadLine();
            int.TryParse(input5, out e);

            Console.Write("두번째 수 입력: ");
            string input6 = Console.ReadLine();
            int.TryParse(input6, out f);

            Console.Write("세번째 수 입력: ");
            string input7 = Console.ReadLine();
            int.TryParse(input7, out g);

            int result3 = (e + f) * g;
            Console.WriteLine($"첫째수 더하기 둘째수에 셋째수를 곱한 값은 {result3} 입니다");
            #endregion
        }
    }
}
