using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Practice
{
    class Can
    {
        public Can()
        {
            Console.WriteLine("캔");
        }
        public Can(int num)
        {
            Console.WriteLine(num);
        }
    }

    class Cola : Can
    {
        public Cola() : base(2) //자동으로 부모생성자부터 호출
        {
            Console.WriteLine("콜라");
        }
        public void Func()
        {
            Console.WriteLine("콜라입니다");
        }
    }

    class Cider : Can
    {
        public Cider()
        {
            Console.WriteLine("사이다");
        }
    }

    class Prac_class2
    {
        static void Main(string[] args)
        {
            Can can = new Cider(); //속은 Cola지만, 겉모습은 아무튼 Can 타입. 점조직처럼 주어진 정보만 알고 그 다음 depth 정보는 모름.
            Cola cola = new Cola();
            Prac_class2 prac = new Prac_class2();

            prac.Func(can);
            prac.Func(cola);

            cola = can as Cola; //cider를 cola로 바꾸려고 하는게 아니다. 이 Line에선 can만 암. can=new cider()까지 안따지므로 컴파일상의 오류는 안뜸. 하지만 실행하면 null값이 뜸. 왜냐면, Cider인스턴스를 동일레벨의 자식인 Cola로 변환하려했음
            //prac.Func(cola);

            if(cola is Can result) //Can 타입이냐(x, 컴파일에서 이미 체크하는 사항), Can 인스턴스로 될 수 있냐(o, null-안될수도있기 때문)
            {
                Console.WriteLine("당첨");
                prac.Func(result);
            }

        }

        void Func(Can can)
        {
            if (can != null)
            {
                Console.WriteLine(can);
            }
            else
            {
                Console.WriteLine("널값");
            }
        }
    }
}
