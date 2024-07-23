using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    public class Encapsulation
    {
        private class Capsule1 //1겹
        {
            public class Capsule2  //2겹
            {
                //캡슐화 사용목적 - 데이터 무결성을 위해 정보 은닉, 모듈화, 재사용성, 유지보수성 등.
                int Health; //신체의 건강은 외부로 드러나지 않는 내적 정보이므로 private
                public int focusDuration; //집중시간. 건강에 영향을 받는 2차 속성. 외부로 드러나서 실측될 수 있는 속성이므로 public
                int moneyInBank = 100000000; //은행잔고는 함부로 수정되면 안되므로 private
                
                public int DisplayMoney() //대신 내부의 은행잔고 데이터를 출력만 해주는 함수로 안전하게 은행잔고를 보여줄 수 있다.
                {
                    return this.moneyInBank;  //get
                }

                public void AddMoney(int money)  //set
                {
                    this.moneyInBank += money;
                }
            }

            public void AccessCapsule2()
            {
                Capsule2 capsule = new Capsule2();
                Console.WriteLine(capsule.DisplayMoney());
            }
        }

        Encapsulation()
        {
            //Capsule2.
            Capsule1 capsule1 = new Capsule1();
            capsule1.AccessCapsule2();
        }

        static void Main(string[] args)
        {
            Capsule1 capsule1 = new(); //Main은 Capsule1 내부에 있으므로 접근 가능
            Capsule1.Capsule2 capsule2 = new(); //직접 내부 클래스도 접근 가능 
            
        }
    }
}
