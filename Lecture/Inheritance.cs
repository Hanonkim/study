using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Character
    {
        public int power; //혹은 protected

        public Character() //생성자도 함수. 자식도 남. 따라서 public해야 자식도 접근 가능
        {
            this.power = 0;
        }
    }

    public class PlayerCharacter : Character
    {
        public int level;

        public PlayerCharacter()
        {
            this.level = 0;
            base.power = 1;
        }
    }
    public class Monster : Character
    {
        public int level;

        public Monster()
        {
            this.level = 0;
            base.power = 1;
        }
    }

    public class Hero
    {
        public void GivePower(Character character, int power)
        {
            character.power += power;
        }
    }
    public class Inheritance
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();

            //상속을 활용해서 하나의 함수로 다양한 상황에 대응
            Character mob1 = new PlayerCharacter(); //upcasting 발생
            Character mob2 = new Monster(); //upcasting 발생


            PlayerCharacter mob3 = new PlayerCharacter();
            Character mob4 = new PlayerCharacter(); //upcasting 발생
            

            hero.GivePower(mob1, 1);
            hero.GivePower(mob2, 1);
            hero.GivePower((Character)mob3, 1); //upcasting 발생

            //mob3 = (PlayerCharacter)mob4; //downcasting 발생. 이건 위험하므로 아래처럼 체크 권장
            if(mob4 is PlayerCharacter) //downcasting이 예상될 때엔 안전하게 검증 후 처리
            {
                mob3 = (PlayerCharacter)mob4;
                Console.WriteLine("다운 캐스팅");
            }

        }
    }
}
