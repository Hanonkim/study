using System;

public class Program
{
    public class Player
    {
        private Armor curArmor;

        public void Equip(Armor armor)
        {
            Console.WriteLine($"플레이어가 {armor.name} 을/를 착용합니다.");
            curArmor = armor;
            curArmor.OnBreaked += UnEquip; //구독

            
        }

        public void UnEquip()
        {
            Console.WriteLine($"플레이어가 {curArmor.name} 을/를 해제합니다.");
            curArmor.OnBreaked -= UnEquip; //파괴되었으니 더이상 파괴되면 안되므로 구독해제
            curArmor = null;
        }

        //플레이어가 피격받는 함수
        public void Hit()
        {
            if (curArmor != null)
            {
                curArmor.DecreaseDurability();
            }

            
        }
    }

    public class Armor
    {
        public string name;
        public int durability;

        public event Action OnBreaked; //파괴 이벤트

        public Armor(string name, int durability)
        {
            this.name = name;
            this.durability = durability;
        }

        public void DecreaseDurability()
        {
            durability--;
            if (durability <= 0)
            {
                Break();
            }
        }

        //break여부를 담당. player의 equip에서 
        private void Break() //Armor의 내구도에 따라 깨지므로 외부에서 개입할 필요가 없다.
        {
            OnBreaked?.Invoke();
        }
        public void Print()
        {
            Console.WriteLine(durability);
        }
    }

    static void Main(string[] args)
    {
        Player player = new Player();
        Armor armor = new Armor("갑옷", 3);

        player.Equip(armor);

        player.Hit();
        player.Hit();
        player.Hit();
    }
}