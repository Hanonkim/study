using System;

namespace study
{
    internal class Prac_baseball
    {
        static void Main(string[] args)
        {
            int inning = 1;  //1이닝부터 시작
            bool result = false;
            int firstNum, secondNum, thirdNum;
            int myFirstNum = 0, mySecondNum = 0, myThirdNum = 0;
            int tmpNum;

            #region 정답 설정
            //자릿수 중복없는 난수 생성
            Random rnd = new Random();

            //첫째수
            tmpNum = rnd.Next(0, 10);  //0~9 사이의 난수
            firstNum = tmpNum;

            //둘째수
            tmpNum = rnd.Next(0, 10);
            while (firstNum == tmpNum) //다시 뽑은 수가 첫수와 다를 때까지
            {
                tmpNum = rnd.Next(0, 10); //계속 뽑음
            }
            secondNum = tmpNum; //다시 뽑은 수가 다르면, 둘째수에게 넣음

            //셋째수
            tmpNum = rnd.Next(0, 10); //마지막 뽑기
            while (firstNum == tmpNum || secondNum == tmpNum) //다시 뽑은 수가 첫수, 둘째수 모두 다를 때까지
            {
                tmpNum = rnd.Next(0, 10); //계속 뽑음
            }
            thirdNum = tmpNum;
            #endregion


            //게임진행
            while (inning != 11)  //게임종료조건 = 11이닝동안 최대득점 실패시
            {
                int myAnswer;
                int ball = 0, strike = 0;
                bool outt = false;

                Console.WriteLine($"{inning}번 째 이닝");

                Console.Write("정답 입력 = ");
                bool correctInput = int.TryParse(Console.ReadLine(), out myAnswer);

                //입력 무결성 검사1: 오입력 체크
                while (correctInput == false || myAnswer > 999 || myAnswer < 100)
                {
                    Console.WriteLine("일반 오입력");
                    correctInput = int.TryParse(Console.ReadLine(), out myAnswer);
                }

                //입력 무결성 검사2: 중복체크
                myFirstNum = myAnswer / 100;
                mySecondNum = (myAnswer / 10) % 10;
                myThirdNum = myAnswer % 10;

                bool correctInput2 = true;
                if (myFirstNum == mySecondNum || mySecondNum == myThirdNum || myFirstNum == myThirdNum)
                {
                    correctInput2 = false;
                    Console.WriteLine("자릿수 중복");
                }

                //중복값이 있는 경우 재입력
                while (!correctInput2)
                {
                    Console.Write("정답 입력 = ");
                    correctInput = int.TryParse(Console.ReadLine(), out myAnswer);

                    while (correctInput == false || myAnswer > 999 || myAnswer < 100)
                    {
                        Console.WriteLine("일반 오입력");
                        correctInput = int.TryParse(Console.ReadLine(), out myAnswer);
                    }

                    myFirstNum = myAnswer / 100;
                    mySecondNum = (myAnswer / 10) % 10;
                    myThirdNum = myAnswer % 10;

                    correctInput2 = true;
                    if (myFirstNum == mySecondNum || mySecondNum == myThirdNum || myFirstNum == myThirdNum)
                    {
                        correctInput2 = false;
                        Console.WriteLine("자릿수 중복");
                    }
                }

                int[] tmpAnwser = new int[] { firstNum, secondNum, thirdNum };
                int[] tmpMyAnwser = new int[] { myFirstNum, mySecondNum, myThirdNum };
                Console.WriteLine($"{firstNum},{secondNum},{thirdNum}"); //정답
                Console.WriteLine($"{myFirstNum},{mySecondNum},{myThirdNum}"); //입력값

                //같은 숫자가 존재하면
                for (int i = 0; i < tmpAnwser.Length; i++)
                {
                    for (int j = 0; j < tmpMyAnwser.Length; j++)
                    {
                        if (tmpMyAnwser[j] == tmpAnwser[i])
                        {
                            if (i == j)  //자릿수까지 똑같으면
                            {
                                strike++;
                                continue; //strike는 ball을 포함하므로 이후의 ball++은 스킵해야함
                            }
                            ball++;  //자릿수는 다르면
                        }
                    }
                }
                //승리여부 판단(최대 득점)
                if (strike == 3)
                {
                    result = true;
                    break; //게임종료조건 = 최대 득점시
                }

                //아웃여부 판단(최소 득점)
                if (ball == 0 && strike == 0)
                {
                    outt = true;
                }
                Console.WriteLine($"스트라이크 = {strike}, 볼 = {ball}, 아웃 = {outt}"); //확인 편의상 아웃도 같이 출력

                inning++;
            }

            //게임결과
            if (result != true)
            {
                Console.WriteLine("게임패배");
            }
            else
            {
                Console.WriteLine("게임승리");
            }
        }
    }
}
