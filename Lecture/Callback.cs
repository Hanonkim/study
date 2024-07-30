using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Callback
    {
        /*******************************************************************************
         * 콜백함수
         * 
         * 델리게이트를 이용하여 특정조건에서 반응하는 함수를 구현
         * 함수의 호출(Call)이 아닌 역으로 호출받을 때 반응을 참조하여 역호출(Callback)
         *******************************************************************************/

        public static void Main()
        {
            File file = new File();

            Button button = new Button();
            button.callback = file.Save;
            button.Click();

            button.callback = file.Load;
            button.Click();

            Player player = new Player();
            button.callback = player.Jump;
            button.Click();
        }

        public class Player
        {
            public void Jump()
            {
                Console.WriteLine("플레이어가 점프합니다!");
            }
        }

        public class Button
        {
            public Action callback;

            public void Click()
            {
                callback();
            }
        }

        public class File
        {
            private void Save()
            {
                Console.WriteLine("저장 합니다.");
            }
            private void Load()
            {
                Console.WriteLine("불러오기 합니다.");
            }
        }
    }
}
