using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    internal class Operator
    {
        static void Main(string[] args)
        {
            #region string type의 정수 변환
            string age = "11";
            Console.WriteLine($"당신의 나이는 {age}");


            string tmpInt = Console.ReadLine();  //null일수도 있는 값을 null불허용 type에 할당하므로 caution 발생
            int age2;
            //int str = Convert.ToInt32(tmpIntInt);  //숫자로 이뤄진 문자열이 아니면 exception 발생. 숫자만 입력되는 것이 보장될때만 사용권장
            //int str = int.Parse(tmpInt);  오입력 예외처리가 안되어있음
            bool str = int.TryParse(tmpInt, out age2); //exception은 비용이 큰 오버헤드라 tryparse 사용권장
             
            Console.WriteLine(str);
            Console.WriteLine(age2+1);
            #endregion

            #region string type의 실수 변환
            string tmpfloat = Console.ReadLine();
            float rate;

            bool str2 = float.TryParse(tmpfloat, out rate);
            Console.WriteLine(str2);
            Console.WriteLine(rate); //컴퓨터의 데이터 표현방식상 정확한 실수표현 불가
            #endregion
        }
    }
}
