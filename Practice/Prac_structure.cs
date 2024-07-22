using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    public struct XYCoord
    {
        private short x, y;

        public XYCoord(short x, short y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public struct Weapon
    {
        private int Dmg;
        private float Critical;
        public string Name; //이름만 공개

        public Weapon(int Dmg, float Critical, string Name)
        {
            this.Dmg = Dmg;
            this.Critical = Critical;
            this.Name = Name;
        }
    }
    public struct Car
    {
        enum Manufacturer
        {
            Honda,
            Audi,
            BMW,
            Kia
        }
        private float maxSpeed; //이렇게 모든 멤버변수가 private이면 readonly와 뭐가 다른가?
        private int carCode;
        Manufacturer manufacturer;
    }
    public struct Item
    {
        public string itemName = null;
        public int itemPrice = -1;
        public enum ItemType
        {
            WEAPON = default,
            ARMOR,
            CONSUMABLE
        }

        public ItemType itemType;
        public Item(string name, int price, ItemType type)
        {
            this.itemName = name;
            this.itemPrice = price;
            this.itemType = type;
        }
    }

    //심화
    public struct Weapon2
    {
        public string name;

        public Weapon2(string name) { this.name = name; }
    }

    public struct Soilder
    {
        //public Weapon2[] equips = new Weapon2[3];  //값 초기화는 생성자에서 해야함
        public Weapon2[] equips;
        public int handedEquip; //1번 무기가 기본값
        public Soilder(string[] weapons)
        {
            equips = new Weapon2[3]; //여기서 초기화
            handedEquip = 0;

            for (int i = 0; i < equips.Length; i++)
            {
                equips[i] = new Weapon2(weapons[i]);
            }
        }
    }


    internal class Prac_structure
    {
        void ChangeWeapon(int changeTo, ref Soilder soilder)
        {
            //전체 리스트 출력
            Console.WriteLine("==============================");
            for (int i = 0; i < soilder.equips.Length; i++)
            {
                Console.WriteLine($"무기 = {soilder.equips[i].name}");
            }

            Console.Write("교체할 무기의 번호: ");
            Console.WriteLine($"현재 {soilder.handedEquip + 1} 번째 무기를 장착 중입니다");

            if (changeTo - 1 == soilder.handedEquip)
            {

                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("현재 들고 있는 무기와 동일합니다");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                soilder.handedEquip = changeTo - 1;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{changeTo}번째 슬롯으로 변경.");
                Console.WriteLine($"실행 결과 = 현재 {soilder.handedEquip + 1} 번째 무기 {soilder.equips[soilder.handedEquip].name}을/를 착용 중 입니다.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        static void Main(string[] args)
        {
            #region 심화실습
            string[] equipWeapons = { "롱소드", "해머", "스피어" };
            Soilder mob_1 = new Soilder(equipWeapons);
            Prac_structure prac = new Prac_structure();

            bool correctInput = false;
            int input = 0;
            while (true)
            {
                Console.Write("교체할 슬롯번호를 입력하세요: ");
                correctInput = int.TryParse(Console.ReadLine(), out input);
                while (!correctInput || input < 1 || input > 3)
                {
                    Console.WriteLine("1~3 사이의 정수만 입력하세요!!");
                    correctInput = int.TryParse(Console.ReadLine(), out input);
                }

                prac.ChangeWeapon(input, ref mob_1); //mob_1이 input번째 손에 장착하고 있는 무기
            }

            #endregion



            #region 기본실습
            Weapon Katana = new Weapon(10, 1.5f, "화염의 카타나");
            Weapon Katana2 = new Weapon() { Name = "화염의 카타나2" }; //기본생성자로 하면 직접 내용을 적어야함
            Weapon Sword = new Weapon(15, 2.5f, "롱소드");

            Item[] inventory = new Item[3];

            inventory[2].itemPrice = 500;
            inventory[2].itemName = "악몽의 꽃 견갑";
            inventory[2].itemType = Item.ItemType.ARMOR;

            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine($"이름 = {inventory[i].itemName}");
                Console.WriteLine($"가격 = {inventory[i].itemPrice}");
                Console.WriteLine($"유형 = {inventory[i].itemType}");
                Console.WriteLine();
            }
            #endregion

        }
    }
    }
