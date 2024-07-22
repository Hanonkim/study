using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*<학습목표>
 * 배열의 이해
 *   - 다수의 데이터를 관리하기 위한 방법
 * 배열 사용법
 * 참조형의 이해
 */
namespace study
{
    internal class Array
    {
        static void Main(string[] args)
        {
            //Declare single-demension array of 5 integers
            int[] array =   //차원수는 배열 선언시 결정
                new int[3]; //각 차원별 길이는 인스턴스 생성시 결정
            int[] array2_0 = { 1, 2, 3 };
            int[] array2_1 = new int[3] { 1, 2, 3 };
            //Declare two dimension array
            int[,] array3 = new[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int[] array4 = [1, 2, 3, 4]; //.net 8(C# 12)부터 대괄호로도 초기화가능

            //컬렉션 반복문
            foreach(int i in array) //in은 readonly이므로 컬렉션 내용열람만을 위해 사용
            {
                Console.Write(i);
                //i는 쓸수없고 읽기만 가능
            }

            for(int i = 0; i < array3.GetLength(0); i++) //각 차원별 원소 출력
            {
                for(int j=0; j < array3.GetLength(1); j++)
                {
                    Console.WriteLine(array3[i, j]); 
                }
            }


            //char로 분리하기
            string str = "abcde";

            foreach (char c in str)
            {
                Console.WriteLine(c);
            }

            string str2 = "abc";
            str2 = "def"; //다른 문자열로 대체 가능
            //str2[0] = 'd';  //특정 자리를 바꾸는건 불가능. string은 readonly. immutable에서 다룸

        }
    }
}
