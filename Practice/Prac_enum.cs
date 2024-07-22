using System;

class Program
{
    enum Area
    {
        마을, 사냥터, 상점
    }

    void Sol_1()
    {
        Console.WriteLine("이동 할 장소를 설정해주세요");
        Console.WriteLine("1. 마을");
        Console.WriteLine("2. 사냥터");
        Console.WriteLine("3. 상점");
        int toDetermine;

        int.TryParse(Console.ReadLine(), out toDetermine);
        Console.Clear(); //화면을 지워줍니다
        switch (toDetermine)
        {
            case (int)Area.마을:
                Console.WriteLine("마을로 이동합니다");
                break;
            case (int)Area.사냥터:
                Console.WriteLine("사냥터로 이동합니다");
                break;
            case (int)Area.상점:
                Console.WriteLine("상점으로 이동합니다");
                break;
            default:
                Console.WriteLine("1,2,3 어느것도 아니에요");
                break;
        }
    }
    //플레이어의 현재 행동 = state. idle, run, walk, death(9)
    enum PlayerState
    {
        idle = 1,
        run,
        walk,
        death = 9
    }
    void Sol_2()
    {
        while (true)
        {
            int num;
            Console.Write("상태 입력: ");
            if (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("오입력!");
                continue;
            }

            switch (num)
            {
                case (int)PlayerState.idle:
                    Console.WriteLine("대기");
                    break;
                case (int)PlayerState.run:
                    Console.WriteLine("달리기");
                    break;
                case (int)PlayerState.walk:
                    Console.WriteLine("걷기");
                    break;
                case (int)PlayerState.death:
                    Console.WriteLine("죽음");
                    break;
                default:
                    Console.WriteLine("1,2,3,9만 입력가능");
                    break;
            }
        }
    }
    static void Main(string[] args)
    {
        Program program = new Program();

        program.Sol_1();
        program.Sol_2();

    }
}