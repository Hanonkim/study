using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    class Character
    {
        public int level;
        public int health;
        public int speed;
        public int atk;

        public void MoveForward() { Console.WriteLine("전진"); }
        public void MoveBackward() { Console.WriteLine("후진"); }
        public void RotateToRight() { Console.WriteLine("우회전 90도"); }
        public void RotateToLeft() { Console.WriteLine("좌회전 90도"); }
        public void GiveDamage() { Console.WriteLine("공격"); }
        public void TakeDamage() { Console.WriteLine("피격"); }
    }

    public class Character2
    {
        public int level;
        public int health;
        public int speed;
        public int atk;

        public void MoveForward() { Console.WriteLine("전진"); }
        public void MoveBackward() { Console.WriteLine("후진"); }
        public void RotateToRight() { Console.WriteLine("우회전 90도"); }
        public void RotateToLeft() { Console.WriteLine("좌회전 90도"); }
        public void GiveDamage() { Console.WriteLine("공격"); }
        public void TakeDamage() { Console.WriteLine("피격"); }

        public Character2()
        {
            level = 1;
            health = 1;
            speed = 1;
            atk = 1;
        }
    }
    class Prac_Class
    {
        static unsafe void Main()
        {
            Character player = new Character();
            Character2 player2 = new Character2();

            //class는 기본 생성자가 자동 제공된다. 
            Console.WriteLine(player.level);
            Console.WriteLine(player.health);
            Console.WriteLine(player.speed);
            Console.WriteLine(player.atk);

            Console.WriteLine(player2.level);
            Console.WriteLine(player2.health);
            Console.WriteLine(player2.speed);
            Console.WriteLine(player2.atk);
        }
    }
}
