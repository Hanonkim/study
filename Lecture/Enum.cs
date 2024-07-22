using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    internal class Enum
    {
        enum Menu
        {
            menu_1, menu_2, menu_3, menu_4 =999, menu_5, menu_6 //이전 인덱스에서 1만큼 더한 것으로 자동 값 부여
        }
        static void Main(string[] args)
        {
            //숫자에 별명alias를 붙이기
            Menu myMenu;
            myMenu = Menu.menu_1;
        }
    }
}
