using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    public interface IDamageable
    {
        void TakeDmg(int dmg);
    }
    public class Monster : IDamageable
    {
        public int health = 100;
        public void TakeDmg(int dmg)
        {
            health -= dmg;
            Console.WriteLine(health);
        }
        public void Print()
        {
            Console.WriteLine("dd");
        }
    }
    public class Player
    {
        public int Damage = 5;
        public void Attack(IDamageable damageable)
        {
            damageable.TakeDmg(Damage);
            Console.WriteLine("공격");
        }
    }

    internal class Interface
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Monster monster = new Monster();
            IDamageable monster2 = new Monster();
            monster = monster2 as Monster;
            if (monster != null) //안전하게 다운캐스팅
            {
                player.Attack(monster);
            }
        }
    }
}
