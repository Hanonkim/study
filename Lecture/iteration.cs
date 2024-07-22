using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * 기본과제 : Sol_1 ~ Sol_4
 * 심화과제 : Sol_5 ~ Sol_6
 */
namespace study
{
    internal class Iteration
    { 
        void Sol_1()
        {
            //입력받은 횟수만큼 출력
            string input;
            int cnt;
            while (true)
            {
                Console.Write("입력 횟수 = ");
                input = Console.ReadLine();
                
                if (!int.TryParse(input, out cnt))
                {
                    Console.WriteLine("오입력!");
                    continue;
                }

                for(int i = 0; i < cnt; i++) { Console.WriteLine($"{i + 1}회 반복 중입니다."); }

            }
        }

        void Sol_2()
        {
            //두 수 사이의 모든 정수의 합
            string input1, input2;
            int startNum, endNum;
            
            while (true)
            {
                int tmpSum = 0;

                Console.Write("시작수 입력 = ");
                input1 = Console.ReadLine();

                if (!int.TryParse(input1, out startNum))
                {
                    Console.WriteLine("오입력!");
                    continue;
                }

                Console.Write("끝수 입력 = ");
                input2 = Console.ReadLine();

                if (!int.TryParse(input2, out endNum))
                {
                    Console.WriteLine("오입력!");
                    continue;
                }

                for (int i = startNum; i < endNum + 1; i++)
                    tmpSum += i;

                Console.WriteLine($"{startNum}과 {endNum} 사이의 정수들의 합은 {tmpSum}입니다");
            }
        }

        void Sol_3()
        {
            //입력받은 숫자의 구구단
            while (true)
            {
                string input;
                int dan;

                Console.Write("단 수 입력 = ");
                input = Console.ReadLine();

                if (int.TryParse(input, out dan))
                {
                    if(dan<0 || dan > 9) 
                    { 
                        Console.WriteLine("1~9 단만 지원합니다.");
                        continue;
                    }
                }

                else
                {
                    Console.WriteLine("오입력!");
                    continue;
                }
               
                for (int i = 1; i < 10; i++)
                {
                    Console.WriteLine($"{dan} x {i} = {dan * i}");
                }
            
                
            }
        }

        void Sol_4()
        {
            //별찍기
            //한변의 길이가 정사각행렬로 볼 수 있다.
            //1,4번은 별이 행/열의 증감순대로 찍히기 때문에 행번호와 열변호의 크기비교로 출력여부 결정 가능
            //2,3번은 별이 행/열의 증감순대로 찍히지 않지만, 행번호+열번호의 합으로 출력여부 결정 가능
            //1번
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (row == col) Console.Write("*");
                    else if (row > col) Console.Write("*");
                    else if (row < col) Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //4번
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (row == col) Console.Write("*");
                    else if (row < col) Console.Write("*");
                    else if (row > col) Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //2번
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (row + col >= 4) Console.Write("*"); //4는 (가로 + 세로)의 평균값이다.
                    else if (row + col < 4) Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //3번
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (row + col <= 4) Console.Write("*");
                    else if (row + col > 4) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        void Sol_5()
        {
            int toDetermine;
            bool incorrectInput = false;

            Console.WriteLine("1. 마을");
            Console.WriteLine("2. 사냥터");
            Console.WriteLine("3. 상점");
            Console.Write("이동할 장소 : ");

            incorrectInput = int.TryParse(Console.ReadLine(), out toDetermine);

            //숫자가 아닌 문자 또는 1,2,3이 아닌 숫자 입력시 오류
            if (incorrectInput == false || toDetermine < 0 || toDetermine > 3)
            {
                while (incorrectInput == false || toDetermine < 0 || toDetermine > 3)
                {
                    Console.WriteLine("제대로 된 입력을 다시 해주세요");
                    incorrectInput = int.TryParse(Console.ReadLine(), out toDetermine);
                }
            }
            else
            {
                switch (toDetermine)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("마을로 이동하였습니다");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("사냥터로 이동하였습니다");
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("상점으로 이동하였습니다");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("1,2,3 어느것도 아니에요");
                        break;
                }
            }
        }
        void Sol_6()
        {
            //다이아는 원처럼 중심에서 일정거리 이내의 영역을 포함하는 도형
            //따라서 횡거리와 종거리의 합이 보다 다이아의 반지름보다 작은 영역은 마름모영역으로 간주 가능 
            while (true)
            {
                string input;
                int length; //row.length == col.length로 전제
                int avgLengh; //다이아의 반지름 = 길이의 중간값
                Console.Write("다이아몬드의 지름 입력 = ");
                input = Console.ReadLine();
                if(int.TryParse(input, out length))
                {
                    if (length % 2 == 0)
                    {
                        Console.WriteLine("짝수말고 홀수 입력하세요.");
                        continue;
                    }
                    else if (length < 0)
                    {
                        Console.WriteLine("양수를 입력하세요.");
                        continue;
                    }
                    int avgLength = length / 2;

                    for (int row = 0; row < length; row++)
                    {
                        for (int col = 0; col < length; col++)
                        {
                            if (Math.Abs(avgLength - row) + Math.Abs(avgLength - col) <= avgLength) //종거리+횡거리<=반지름이면 다이아 영역
                            {
                                Console.Write("*");
                            }
                            else //종거리+횡거리>반지름이면 다이아 영역이 아님
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("오입력!");
                    continue;
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Iteration solution = new Iteration();

            //solution.Sol_1();
            //solution.Sol_2();
            //solution.Sol_3();
            //solution.Sol_4();
            //solution.Sol_5();
            //solution.Sol_6();
        }
    }
}


