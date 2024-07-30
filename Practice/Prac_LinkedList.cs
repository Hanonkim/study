using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * 아직 잘안되는 것 - 선제적 null 예외처리
 * null 예외처리를 안하면 런타임 중에 갑자기 꺼지는 이슈 발생할 수 있음...
 * 사용자 경험에 매우 안좋음. 분명히 처리는 해야하는데 아직 null이 언제 발생하고 어떻게 처리해야하는지 잘 생각이 되어지지 않음.
 * 현재 취하고 있는 방식 -> 슈도코드 선작성 코드 후작성
 * 한번에 코드로 작성하려고하면 코드문법, 용례 등등 신경써야할게 많아서 아직 그런것들 쳐내는것도 정신없어서 로직까지 생각하는게 잘 안됨
 * 그래서 로직만 충분히 생각할 수 있도록 슈도코드 작성단계를 거친 다음에 이를 코드로 옮기는 방식으로 하는 중...
 * 이렇게 해도되는지, 아니면 더 좋은 방법이 있는지
 * 
 * null 처리할 때에 throw except....머시기 하는 구문 공부 필요
 */
namespace study.Practice
{
    public class MyLinkedListNode<T> //내부에 선언할수도있지만 연결리스트의 노드라는 객체의 의도를 명확히 하고자 따로 타입화함
    {
        //list가 item, next, prev를 수정할 수 있어야하므로 public
        public T Item { get; set; }
        public MyLinkedListNode<T> Prev { get; set; }
        public MyLinkedListNode<T> Next { get; set; } 

        public MyLinkedListNode(T item)
        {
            Item = item;
            Next = null;
            Prev = null;
        }
    }

    public class MyLinkedList<T>
    {
        private MyLinkedListNode<T> head;
        private MyLinkedListNode<T> tail;
        private MyLinkedListNode<T> node;

        //편의성 프로퍼티들
        private int count; //현재 리스트의 요소 수
        private MyLinkedList<T> first; //리스트의 처음. 순회할 때 사용
        private MyLinkedList<T> last; //리스트의 끝. 순회할 때 사용

        public int Count { get { return count; } } //매번 순회하는게 아니라 추가/삭제될때마다 count를 기록하는게 효율적
        public MyLinkedListNode<T> First
        {
            get { return head; } //매번 순회하는게 아니라 추가/삭제될때마다 count를 기록하는게 효율적
        }

        public MyLinkedListNode<T> Last
        {
            get { return tail; } //매번 순회하는게 아니라 추가/삭제될때마다 count를 기록하는게 효율적
        }

        public MyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public void AddFirst(T item)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(item);

            if (head == null) //비어있을 때엔 head, tail 둘다 null이므로 따로 지정해주어야함
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                head.Prev = newNode;
                newNode.Next = head;
                head = newNode;
            }
            count++;
        }
        public void AddLast(T item) 
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(item);

            if (tail == null) //비어있을 때엔 head, tail 둘다 null이므로 따로 지정해주어야함
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            count++;
        }
        public void AddBefore(MyLinkedListNode<T> before, T value) //before 이전 노드에 value 삽입
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(value);

            for(MyLinkedListNode<T> currentNode = head; currentNode != null; currentNode = currentNode.Next) //tail or null 둘 중 어느게 더 안전할까.
            {
                if(currentNode == before)
                {
                    newNode.Prev = currentNode.Prev;
                    newNode.Next = currentNode;

                    if(before == head)
                    {
                        currentNode.Prev.Next = newNode;
                        
                    }
                    else
                    {
                        head = newNode;
                    }

                    currentNode.Prev = newNode;

                    if (before == tail)
                    {
                        tail = newNode;
                    }
                    return;
                }
                currentNode = currentNode.Next;
            }

        }
        public void AddAfter(MyLinkedListNode<T> after, T value)
        {

        }
        public void RemoveFirst()//첫번째 원소 삭제
        {
            //비어있으면 삭제 불가
            if(head == null)
            {
                Console.WriteLine("비어있음");
            }
            head.Next = head;
        }
        public void RemoveLast()
        {

        }
        public void Remove(T value) //최초 발견되는 값 삭제
        {
            MyLinkedListNode<T> currentNode = head;
            while (currentNode != null)
            {
                if(currentNode.Item.Equals(value))
                {
                    if(currentNode.Prev == null)
                    {
                        head = currentNode.Next;
                    }
                    else
                    {
                        currentNode.Prev.Next = currentNode.Next;
                    }
                    if (currentNode.Next == null)
                    {
                        tail = currentNode.Prev;
                    }
                    else
                    {
                        currentNode.Next.Prev = currentNode.Prev;
                    }

                    currentNode.Prev = null;
                    currentNode.Next = null;
                    return;
                }
                currentNode = currentNode.Next;
            }
        }
        public void Clear()
        {
            node.Prev = null;
            node.Next = null; //순회하면서 다 null로 바꿔주는건? 그럴 필요는 없나?
        }
    }
    public class Prac_LinkedList
    {
    }
}
