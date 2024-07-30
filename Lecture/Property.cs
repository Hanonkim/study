using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    public class Property
    {
        public class Player
        {
            private int hp;

            public int getHp()
            {
                return hp;
            }
            public void setHp(int hp)
            {
                this.hp = hp;
            }
        }

        public class Player2
        {
            public string _name;
            //기본형
            public int hp
            {
                get { return hp; }
                set { hp = value; }
            }
            //자동구현형
            public int mp { get; set; }

            //쓰기전용
            public int mp2 { private get; set; }
            //읽기전용
            public int mp3 { get; private set; }
            //Expression-bodied 식본문(C#6.0이후)
            public int TotalResource => hp + mp;
            public string name
            {
                get => _name;
                set => _name = value;
            }
        }
    }
}
