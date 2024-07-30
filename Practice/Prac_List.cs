using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace study.Practice
{
    //List 구현체 생성시 10의 크기
    //배열 크기 넘겨서 추가할 경우 현재 배열 크기의 2배만큼 "재할당"
    //배열 중간 삭제시, 뒤의 원소는 앞으로 재배치

    public class MyList<T>
    {
        private T[] _elements;
        private int _count;
        private int _nowCapacity = 10;

        public T[] Element
        {
            get { return _elements; }
        }
        public int Count //현재 구현체의 원소 숫자 반환
        {
            get
            {
                return _count;
            }
        }
        public int NowCapacity
        {
            get
            {
                return _nowCapacity;
            }
        }
        public MyList()
        {
            _elements = new T[10]; //초기에 10만큼의 배열 크기 할당
            _count = 0; 
        }
        public void Add(T element) //현재 배열의 끝에 원소 추가
        {
            if(element == null)
            {
                Console.WriteLine("널 입력");
                return;
            }

            if (_count >= _nowCapacity) //현재 요소의 수가 현재 배열의 용량을 초과하면
            {
                _nowCapacity *= 2; //현재공간의 2배를 할당
                T[] newElementArray = new T[_nowCapacity];

                for (int i = 0; i < _elements.Length; i++) //내용 복사
                {
                    newElementArray[i] = _elements[i];
                }
                _elements = newElementArray; //배열 교체
            }
            _elements[_count] = element; //새 요소 추가. count는 0부터 시작하므로 count가 다음 번호 맞음
            _count++;
        }
        public void Remove(T element) //해당 원소 삭제
        {
            if (element == null)
            {
                Console.WriteLine("널 입력");
                return;
            }

            if (_count <= 0)
            {
                Console.WriteLine("제거할 원소가 없음");
            }

            for (int i = 0; i < _elements.Length; i++)
            {
                if (_elements[i].Equals(element)) //같은 것이 나왔으면 
                {
                    for (int j = i; j < _count-1; j++)
                    {
                        _elements[j] = _elements[j + 1]; //한칸씩 앞으로 밀기
                    }
                }
            }
            _elements[_count-1] = default(T); //배열끝은 기본값으로 초기화
            _count--;


        }
        public void RemoveAt(int index) //해당 인덱스의 원소 삭제
        {
            if(index<0 || index >= _count)
            {
                Console.WriteLine("인덱스 범위 에러");
            }
            for (int i = index; i < _elements.Length; i++)
            {
                _elements[index] = _elements[index + 1];
            }
            _elements[_count - 1] = default(T); //배열끝은 기본값으로 초기화
            _count--;
        }
        public void Clear() //모든 원소 삭제
        {
            for (int i = 0; i < _count; i++)
            {
                _elements[i] = default(T);
            }
            _count = 0;
        }
    }
    public class Prac_List
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>();

            myList.Add(100);
            myList.Add(2);
            myList.Add(1);
 

            Console.WriteLine(myList.Count);
            Console.WriteLine(myList.NowCapacity);

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList.Element[i]);
            }

        }
    }
}
