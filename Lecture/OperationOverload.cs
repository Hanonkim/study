using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    public struct Point
    {
        public int x; public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static Point operator +(Point a, Point b) //연산하는 타입 내부에 선언해야만함. 타입이 2개 이상일 경우 그들 중 하나 고를 수 있음
        {
            return new Point(a.x + b.x, a.y + b.y);
        }
        public void Test(int first, int second)
        {
            Sum(name: "ad",1,2,3,4);
        }
        public int Sum(string name, params int[] value) { return 0; } //매개변수 갯수 안정해졌을때 사용. 후행파라미터부터 차례대로 사용 가능. 
        //인덱서
        public class OperationOverload
        {
            static void Main(string[] args)
            {
                Point point = new Point();
                Point point2 = new Point();
                point.Test(second: 2, first: 1); //파라미터명을 적으면 순서 상관없이 기입가능
            }
        }
    }
}
