using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{

    internal class Prac_array
    {
        void Sol_1()
        {
            //4개 정수 배열. 순서대로 입력받은 값을 배열에 담아 foreach로 출력
     
            int[] array = new int[4]; //int 타입. 1차원. 배열의 길이 = 4
            int tmpNum;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{i}번 원소 = ");
                tmpNum = int.Parse(Console.ReadLine());
                array[i] = tmpNum;
            }
     
            foreach (int i in array)
            {
                Console.WriteLine(i); //array[i], array가 아니라 i를 해야함
            }
        }

        void Sol_2()
        {
            //4x4의 2차원 배열 생성 후 반복문으로 3의 배수 채워넣기. (2,3)~(3,2) 스왑 후 출력
            int[,] array = new int[3, 3];
            int power = 3;

            //3의 배수로 채워넣기
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++) //array[i].Length 이런식으로는 안된다.
                {
                    array[i, j] = power; //일단 넣고
                    power += 3; //그 다음 항을 증가시킨다.

                    if (i == 2 && j == 1) //만약 (3,2)라면 (2,3)과 스왑
                    {
                        int tmp = array[i, j];
                        array[j, i] = array[i, j];
                        array[i, j] = tmp;
                    }
                }
            }

 
            int cnt = 0;
            foreach(int i in array)
            {
                Console.Write(i + " ");
                cnt++;
                if (cnt % array.GetLength(1) == 0) //foreach는 행구분없이 순회하므로 행바뀔때 개행을 추가해야한다. 아니면 이중for문 사용 필요
                {
                    Console.WriteLine();
                }
            }
        }

        void Sol_3()
        {
            //인벤토리 크기 입력
            int invSize = 0;
            bool correctInput = false;
            while (!correctInput)
            {
                Console.Write("원하는 인벤토리 크기 입력:");
                correctInput = int.TryParse(Console.ReadLine(), out invSize);
                //1~10이 아니어도 무한반복
                if (invSize < 1 || invSize > 10)
                {
                    correctInput = false;
                }
            }
            int[] inv = new int[invSize];

            bool quit= false;
            while (!quit)
            {
                int input;
                Console.Clear();
                Console.Write("열람할 번호: ");
                input = int.Parse(Console.ReadLine()); //입력 무결성 체크 추가 필요

                if (inv[input] != 0)
                {
                    Console.WriteLine(inv[input]);
                }
                else 
                {
                    Console.Write("비어있음. 값 입력: ");
                    inv[input] = int.Parse(Console.ReadLine());
                }   
                if(input == 0)
                {
                    quit = true;
                }
            }
        }
        static void Main(string[] args)
        {
            Prac_array Solution = new Prac_array();

            //Solution.Sol_1();
            //Solution.Sol_2();
            Solution.Sol_3();

        }
    }
}
