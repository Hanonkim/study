using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    public class Customer
    {
        public void Enter(Restaurant restaurant)
        {
            restaurant.Enter();
        }
    }
    public class Restaurant
    {
        private int curCustomer;
        private int maxCustomer;
        public bool IsAcceptable() 
        {
            return curCustomer < maxCustomer;
        }
        public void Enter()
        {
            if (IsAcceptable())
            {
                curCustomer++;
                Console.WriteLine("손님 입장");
            }
            else
            {
                Console.WriteLine("가득 참!");
            }
        }
    }
    class Delegate
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Restaurant restaurant = new Restaurant();

            customer.Enter(restaurant);
            customer.Enter(restaurant);
            customer.Enter(restaurant);
            customer.Enter(restaurant); //IsAcceptable 여부를 계속 물어봐야함

            DataLoader dataLoader = new DataLoader();
            GameUI gameUI = new GameUI();
            Player player = new Player();

            GameManager.OnGameStarted?.Invoke();
            GameManager.GameStart();
        }
    }
    public class GameUI
    {
        public GameUI()
        {
            GameManager.OnGameStarted += Create;
            GameManager.OnScoreChanged += PrintText;
        }
        ~GameUI()
        {
            GameManager.OnGameStarted -= Create;
            GameManager.OnScoreChanged -= PrintText;
        }
        public void Create()
        {

        }
        public void PrintText(int value)
        {
            Console.WriteLine(value);
        }
    }
    public class Player
    {
        public Player()
        {
            GameManager.OnGameStarted += Init;
            GameManager.OnScoreChanged += AddScore;
        }
        public void Init()
        {
            Console.WriteLine("플레이어 초기화");
        }
        public void AddScore(int value)
        {
            Console.WriteLine(value);
        }
    }
    public static class GameManager
    {
        public delegate void RunDelegate(); //일종의 타입임
        public delegate void ScoreDelegate(int value); //함수를 가리키는 포인터변수

        public static RunDelegate OnGameStarted;
        public static ScoreDelegate OnScoreChanged;

        public static void GameStart()
        {
            OnGameStarted?.Invoke();
        }

        public static void AddScore(int value)
        {
            OnScoreChanged?.Invoke(value);
        }
    }

    public class DataLoader
    {
        public DataLoader()
        {
            GameManager.OnGameStarted += Load; //delegate chain 계속 누적하여 여러 함수 관리
        }
        public void Load()
        {
            Console.WriteLine("로드 데이터");
        }
        ~DataLoader()
        {
            //등록된 함수를 제거하지 않으면 메모리 누수 발생
            GameManager.OnGameStarted -= Load;
        }
    }

}
