using System;

namespace study
{
    public enum ItemType
    {
        Weapon, Armor, Material
    }
    public enum WeaponType
    {
        Gun, Sword
    }
    public enum ArmorType
    {
        Helmet, Chest, Pants, Boots
    }
    public class Entity
    {
        public int entityId;
    }
    public class Material : Entity
    {
        public int maxStack;
        public int minStack;
        public int currentStack;
    }
    public class Player : Entity
    {
        public string name;
        public string nowHand; // 현재 손에 장비한 아이템

        public Player()
        {
            this.name = "수호자";
            this.nowHand = "비어있음";
        }
    }
    public class Monster : Entity
    {
        public int health;
        public string name;

        public Monster(string name, int _health)
        {
            this.name = name;
            this.health = _health;
        }
    }

    public class Goblin : Monster
    {
        public Goblin() : base("고블린", 100) //Monster 클래스의 생성자부터 실행
        {
            Console.WriteLine("고블린 추가 세팅은 여기에");
        }
    }

    public class Ogre : Monster
    {
        public Ogre() : base("오우거", 150) 
        {
            Console.WriteLine("오우거 추가 세팅은 여기에");
        }
    }

    public class Item : Entity
    {
        public string itemName;
        public ItemType itemType;
        public int needPower;
    }

    public abstract class Equippable : Item //장착가능한 아이템
    {
        public bool isEquipped;
        public abstract void Handed(Player player);
    }

    public class Weapon : Equippable
    {
        public WeaponType weaponType;
        const int maxMagazine = 100;

        public override void Handed(Player player)
        {
            player.nowHand = this.itemName;
        }

        public virtual void Attack(Entity entity, int Dmg)
        {
            if (entity is Monster monster) //is는 Bool체크 이후 변수 할당할 수 있음
            {
                monster.health -= Dmg; //파라미터로는 entity를 넘겨받았는데 왜 monster의 health를 수정하지? 그렇게 해도 넘겨받은 entity의 health를 깎을 수 있나?
                Console.WriteLine($"{monster.name}의 체력: {monster.health}");
            }
            else
            {
                Console.WriteLine($"{entity.GetType().Name}를 파괴합니다");
            }
        }
    }

    public class Gun : Weapon
    {
        public int maxRange;
        public Gun()
        {
            weaponType = WeaponType.Gun;
        }
        public override void Attack(Entity entity, int Dmg)
        {
            base.Attack(entity, Dmg); // 코드 재사용
            if (entity is Monster monster)
            {
                Console.WriteLine($"{monster.name}는 관통되었습니다");
            }
        }
    }

    public class Sword : Weapon
    {
        public int swordLength;

        public Sword()
        {
            weaponType = WeaponType.Sword;
        }

        public override void Attack(Entity entity, int Dmg)
        {
            base.Attack(entity, Dmg);
            if (entity is Monster monster)
            {
                Console.WriteLine($"{monster.name}는 피를 흘립니다");
            }
        }
    }

    /*
     * 추상클래스: 추상화를 위한 클래스. 추상메서드에선 시그니처만 정의
     * 오버로딩: 시그니처만 다르게 하여 동명 메서드 중복 정의 가능
     * 오버라이딩: 자식이 부모의 메서드를 구현부를 재정의. 시그니처는 부모와 동일해야함
     */
    public class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Goblin goblin = new Goblin();
            Ogre ogre = new Ogre();
            Gun gun = new Gun();
            Sword sword = new Sword();

            // 플레이어가 총을 장비합니다
            gun.itemName = "AK-47";
            gun.Handed(player);
            Console.WriteLine($"플레이어의 손: {player.nowHand}");

            // 플레이어가 고블린을 공격합니다
            gun.Attack(goblin, 20);

            // 플레이어가 오우거를 공격합니다
            gun.Attack(ogre, 30);

            // 플레이어가 검을 장비합니다
            sword.itemName = "장검";
            sword.Handed(player);
            Console.WriteLine($"플레이어의 손: {player.nowHand}");

            // 플레이어가 고블린을 검으로 공격합니다
            sword.Attack(goblin, 25);

            // 플레이어가 오우거를 검으로 공격합니다
            sword.Attack(ogre, 35);
        }
    }
}
