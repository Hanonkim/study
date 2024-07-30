using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    //박싱언박싱 없이 사용 가능
    public abstract class Item //아이템 추상화 클래스
    {
        public string Name { get; private set; } //프로퍼티 메서드. 외부에서 읽기가능. 내부에서만 쓰기 가능

        public Item(string name) //생성할 때 입력한 값으로 초기화
        {
            this.Name = name;
            Console.WriteLine("zzz");
        }
    }

    public class Potion : Item //Item을 상속받는 Potion 클래스
    {
        public Potion(string name) : base(name) { Console.WriteLine("dddeee"); } //Potion 객체 생성시 생성자가 호출되나 실행은 보류뢰고 입력받은 name이 부모생성자에 전달되어 부모생성자부터 호출 및 실행. 그 다음 자식 생성자 실행.
    }
    public class Inventory<T> where T : Item//해당 클래스에서 T 타입 사용 가능
    {
        private T[] _list;
        private int _index;

        public Inventory(int size)
        {
            _list = new T[size];
        }

        public void Add(T item)
        {
            if (_index < _list.Length)
            {
                _list[_index++] = item;
            }
        }

        public void Remove()
        {
            if (_index > 0)
            {
                _index--;
                _list[_index] = null; //T타입이 뭐가 될지 모름. 따라서 null이 들어갈지 말지 분별할 수 없음. 제약조건으로 한정 필요
            }
        }
        public void PrintItemNames()
        {
            Console.WriteLine("아이템목록: ");
            foreach(T item in _list)
            {
                if (item != null)
                {
                    Console.WriteLine(item.Name); //T타입 내부에 Name필드가 존재하는지 알 수 없음. 제약조건으로 한정 필요
                }
            }
        }
    }
    public class Generic
    {
        static void Main(string[] args)
        {
            Inventory<Potion> potionInventory = new Inventory<Potion>(10);

            potionInventory.Add(new Potion("체력포션"));
            potionInventory.Add(new Potion("체력포션2"));

            potionInventory.Remove();

            potionInventory.PrintItemNames();

        }
    }
}
