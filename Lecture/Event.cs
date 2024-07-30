using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static study.Lecture.Event;

namespace study.Lecture
{
    internal class Event
    {
        public class Player
        {
            public event Action OnDied;
            public void Die()
            {
                //캐릭터가 사망하면 사망음악재생, 게임정지, 시간정지 등 여러 기능들이 요구될 수 있음
                //하지만 캐릭터 클래스에 그 모든 기능을 구현하면 의존성이 과해짐
                OnDied?.Invoke();
            }
            public void AAA() { Console.WriteLine("AAA"); }
            public void BBB() { Console.WriteLine("BBB"); }
        }
        public class UI
        {
            public void GameOverUI()
            {
                Console.WriteLine("게임오버창");
            }
        }
        public class Sound
        {
            public void DeadSound()
            {
                Console.WriteLine("사망효과음");
            }
        }
        public class Camera()
        {
            public void Shake()
            {
                Console.WriteLine("카메라 진동");
            }
        }

        static void Main(string[] args)
        {
            Action action;
            Player player = new();
            UI ui = new UI();
            Sound sound = new Sound();
            Camera camera = new Camera();

            #region delegate chain
            action = player.AAA;
            action += player.BBB; // 체인 추가
            action -= player.AAA; // 체인에서 제거
            action -= player.AAA; // 체인에서 제거 시도 (이미 제거된 경우, 무시됨)
            action = player.AAA; // 가장 마지막의 메서드만 반환

            action(); //AAA만 출력
            #endregion

            #region 널체크 호출
            if (action != null) //안전하게 널체크 action?.Invoke();로 줄일 수 있음(C# 6.0 부터)
            {
                /* 델리게이트 안쓰면 이렇게 일일이 호출해야함
                UI ui = new UI();
                ui.GameOverUI();
                Sound sound = new Sound();
                sound.DeadSound();
                */
            }
            #endregion

            #region 기존 체인 유지하면서 추가하기
            player.OnDied += ui.GameOverUI;
            player.OnDied += sound.DeadSound;
            player.OnDied += camera.Shake;
            #endregion

            #region 기존 체인에 덮어씌우기
            //player.OnDied = sound.DeadSound;
            #endregion
            player.Die();
        }
    }
}
