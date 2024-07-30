using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    public class Mammal
    {
        public virtual void Move() //자식의 동명 함수로 대체됨
        {
            Console.WriteLine("동물은 이동한다.");
        }
    }

    public class Lion: Mammal
    {
        override public void Move() //부모의 동명 함수를 대체함
        {
            Console.WriteLine("사자는 움직인다");
        }
    }

    public class Human: Mammal
    {
        new public void Move() //부모의 동명 함수로 대체되지 않고, 대체하지도 않고 새로 정의
        {
            Console.WriteLine("인간은 움직인다");
        }
    }
    public class Polymorphism
    {
        static void Main(string[] args)
        {
            Mammal mammal = new Mammal();
            mammal.Move();

            Human human = new Human();
            human.Move();

            Lion lion = new Lion();
            lion.Move();

            Mammal lion2 = new Lion();
            lion2.Move();

            Mammal lion3 = lion; //부모로 형변환되면서 lion의 move가 출력되지 않음
            lion3.Move();

            //lion = (Lion)mammal; //이건 막 할당해버림. 안되는데도
            //lion = mammal as Lion; //다운캐스팅 맞음?
            //lion.Move();
            Mammal human2 = new Human();
            human2.Move(); //new public void Move()왜 호출안됨
        }
    }
}
