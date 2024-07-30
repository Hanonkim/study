using System;
using System.Collections.Generic;

namespace study.Practice
{
    public class Inventory
    {
        public List<Item> itemList;
        private event Action OnDisplay;

        public Inventory()
        {
            itemList = new List<Item>();
        }

        public void Subscribe()
        {
            OnDisplay = DisplayInventory; // 종료시까지 유지해야 하므로 구독 해제는 없음
        }

        public void DisplayInventory()
        {
            Console.Clear();
            if (itemList.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어있음");
            }
            else
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i] != null)
                    {
                        Console.WriteLine($"{i+1}: {itemList[i].itemName}");
                    }
                }
            }
        }

        public void Add(Item item)
        {
            if (item == null)
            {
                Console.WriteLine("Null 오류!");
                return;
            }

            if (itemList.Count >= 9)
            {
                Console.WriteLine("보관 한도 초과");
                return;
            }

            itemList.Add(item);
            OnDisplay?.Invoke(); // 추가될 때마다 출력
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= itemList.Count)
            {
                Console.WriteLine("인덱스 에러");
                return;
            }
            itemList.RemoveAt(index);
            OnDisplay?.Invoke(); // 제거될 때마다 출력
        }
    }

    public class Item
    {
        public enum ItemType
        {
            Nothing, Potion, Weapon, Armor, Accessory, Food
        };

        private static Random rand = new Random(); // 모든 인스턴스들이 공통의 난수객체에 접근 -> 시스템 오버헤드 감소

        public string itemName { get; private set; } // 읽기 전용
        public ItemType itemType { get; private set; } // 읽기 전용

        public Item(string itemName, ItemType itemType)
        {
            this.itemName = itemName;
            this.itemType = itemType;
        }

        public static Item GetRandomItem(List<Item> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("리스트가 비어있음");
                return null;
            }

            int index = rand.Next(items.Count); // 최소값은 0, 최대값은 items.Count - 1
            return items[index];
        }
    }

    public class Prac_List
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            List<Item> items = new List<Item>();

            // 아이템 목록 초기화
            items.Add(new Item("빨간 포션", Item.ItemType.Potion));
            items.Add(new Item("엑스칼리버", Item.ItemType.Weapon));
            items.Add(new Item("철갑옷", Item.ItemType.Armor));
            items.Add(new Item("보석반지", Item.ItemType.Accessory));
            items.Add(new Item("빵", Item.ItemType.Food));
            items.Add(new Item("우유", Item.ItemType.Food));
            items.Add(new Item("토파즈 목걸이", Item.ItemType.Accessory));
            items.Add(new Item("철바지", Item.ItemType.Armor));
            items.Add(new Item("바스타드 소드", Item.ItemType.Weapon));
            items.Add(new Item("파란 포션", Item.ItemType.Potion));

            inventory.Subscribe();
            inventory.DisplayInventory(); // 프로그램 시작 시 인벤토리출력

            while (true)
            {
                Console.WriteLine("0. 랜덤템 뽑기 1~9. 해당 번호 아이템 제거");
                if (!int.TryParse(Console.ReadLine(), out int choose))
                {
                    Console.WriteLine("오입력!");
                    continue;
                }

                if (choose == 0)
                {
                    Item tmp = Item.GetRandomItem(items);
                    if (tmp != null)
                    {
                        inventory.Add(tmp);
                    }
                }
                else if (choose >= 1 && choose <= 9)
                {
                    inventory.RemoveAt(choose - 1);
                }
                else
                {
                    Console.WriteLine("오입력2!");
                }
            }
        }
    }
}
