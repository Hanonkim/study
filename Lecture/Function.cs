using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    internal class Function
    {
        int Sol_1(int[] num)
        {
            int result = num[0];
            //4개의 인자값 요구
            if (num.Length!=4)
            {
                Console.WriteLine("4개의 정수 입력 필요.");
                return -1; //오류 코드 리턴
            }
         
            //가장 큰 수 찾기
            for(int i=0; i<num.Length; i++)
            {
                for (int j=0; j < num.Length; j++) //배열 전체의 원소를 비교하면서
                {
                    if (num[i] > num[j]) //큰 값이 있을 때마다 갱신
                    {
                        result = num[i];
                    }
                }
            }
            return result;
        }

        //5개의 float 입력받아 가장 큰 두수의 합을 실수형으로 반환
        float Sol_2(float[] num)
        {
            float result1 = num[0];
            float result2 = num[1];
            float tmp = 0.0f;
            //5개의 인자값 요구
            if (num.Length!=5)
            {
                Console.WriteLine("5개의 실수 입력 필요.");
                return -1.0f; //오류 코드 리턴
            }

            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] > result1) //더 큰게 나왔다면
                {
                    result2 = result1; //result2로 내리고
                    result1 = num[i]; //더 큰걸 result1로 갱신
                }
                else if (num[i] > result2) //result1보단 크진 않지만 result2보단 큰게 나왔다면
                {
                    result2 = num[i]; //resul2 갱신
                }
            }

            return (float)result1 + (float)result2;
        }

        bool Sol_3(int num1, int num2)
        {
            if (Math.Abs(num1-num2) < 100) //두 수의 거리가 100미만이면
            {
                return true;
            }
            else { return false; }
        }

        //정수 파라미터. 1부터 입력값까지의 3/5배수의 총합
        int Sol_4(int num)
        {
            float result3, result5, result15;
            int cnt3, cnt5, cnt15;

            //몫만큼 갯수 존재
            cnt3 = num / 3;
            cnt5 = num / 5;
            cnt15 = num / 15;

            //연속된 자연수의 합공식
            result3 = 3 * 0.5f * cnt3 * (cnt3 + 1);
            result5 = 5 * 0.5f * cnt5 * (cnt5 + 1);
            result15 = 15 * 0.5f * cnt15 * (cnt15 + 1); //15는 중복이므로 한번 빼야함

            Console.WriteLine($"{ result3}, {result5}, {result15}");
            return (int)(result3 + result5 - result15);
        }

        //1이상의 정수 입력. 입력값의 각 자릿수를 더한 값을 정수로 리턴
        int Sol_5(int num)
        {
            int result = num;
            int digit = 0;
            while (result > 1)
            {
                digit += result % 10;  //낮은 차수부터 자릿수 판별
                result /= 10; //그 다음 차수로 이동
            }
            return digit;
        }
        //n번째 피보나치 수 리턴
        int Sol_6(int cnt)
        {
            int num1 = 1, num2 = 1; //피보나치 수열의 1,2항
            //다음항은 이전 두항의 합
            int num3 = 0;

            while(cnt - 2 > 0) //3항부터 계산. cnt<3 일 때의 예외 처리 필요
            {
                num3 = num1 + num2; // 현재의 1항과 2항을 더한 값을 3항에 넣는다.
                //num3은 다음항의 num2, num2는 다음항의 num1이 된다. num1은 삭제된다.
                num1 = num2;
                num2 = num3;
                cnt--;
            }

            return num3;

        }
        static void Main(string[] args)
        {
            Function Solution = new Function();

            //기본
            int[] numArray = { 1, 2, 3, 4 };
            int result = Solution.Sol_1(numArray);
            Console.WriteLine(result);
            float[] floatArray= { 1.2f, 100.999f, 3.4f, 3.14f, 6.111f };
            float result2 = Solution.Sol_2(floatArray);
            Console.WriteLine(result2);
            Console.WriteLine(Solution.Sol_3(10, 1111));

            //심화
            Console.WriteLine(Solution.Sol_4(15));
            Console.WriteLine(Solution.Sol_5(5611));
            Console.WriteLine(Solution.Sol_6(8)); //1 1 2 3 5 8 13 21
        }
    }
}
