using System;

namespace study.Practice
{
    public class Trainer
    {
        public string name;
        private Mob[] mobList;
        private int nowMobCount;
        private const int MaxMobSlot = 6; // 최대 6마리의 몬스터

        public Trainer(string _name)
        {
            name = _name;
            mobList = new Mob[MaxMobSlot];
            nowMobCount = 0;
        }

        public bool GotchaMob(Mob mob)
        {
            if (nowMobCount < MaxMobSlot)
            {
                mobList[nowMobCount] = mob;
                nowMobCount++;
                return true;
            }
            else
            {
                Console.WriteLine($"{mob.name} 추가 실패! 몬스터를 더이상 소지할 수 없습니다.");
                return false;
            }
        }

        public void PrintMobList()
        {
            //출력몹없을때의 예외처리 필요
            for (int i = 0; i < nowMobCount; i++)
            {
                Console.Write($"{i + 1}) ");
                mobList[i].PrintMobInfo();
            }
        }
    }

    public class Mob
    {
        public string name;
        public int health;

        public Mob(string _name, int _health)
        {
            this.name = _name;
            this.health = _health;
        }

        public void PrintMobInfo()
        {
            Console.WriteLine($"이름 = {this.name}, HP = {this.health}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Trainer trainer = new Trainer("지우");
            Mob mob1 = new Mob("피카츄0", 100);
            Mob mob2 = new Mob("파이리0", 120);
            Mob mob3 = new Mob("파이리1", 120);
            Mob mob4 = new Mob("파이리2", 120);
            Mob mob5 = new Mob("파이리3", 120);
            Mob mob6 = new Mob("파이리4", 120);
            Mob mob7 = new Mob("파이리5", 120);

            trainer.GotchaMob(mob1);
            trainer.GotchaMob(mob2);
            trainer.GotchaMob(mob3);
            trainer.GotchaMob(mob4);
            trainer.GotchaMob(mob5);
            trainer.GotchaMob(mob6);
            trainer.GotchaMob(mob7);

            trainer.PrintMobList();
        }
    }
}
