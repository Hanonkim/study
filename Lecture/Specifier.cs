using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    //지정자
    public class Specifier
    {
        static void Main(string[] args)
        {
            Specifier specifier = new Specifier();
            bool bigger = specifier.Compare(3, 2, specifier.Bigger);

            int[] array = { 1, 3, 5, 7, 9 };
            int less = specifier.CountIf(array, 4, specifier.Less);
        }
        //델리게이트로 미완성 함수 구현
        //나중에 전달된 함수가 완성시킴
        public void Function(Action action)
        {
            action();
        }
        public bool Bigger(int left, int right)
        {
            return left > right;
        }
        public bool Less(int left, int right)
        {
            return left < right;
        }
        public bool Compare(int left, int right, Func<int, int, bool> comparer)
        {
            return comparer(left, right);
        }
        public int CountIf(int[] array, int value, Func<int, int, bool> comparer)
        {
            int count = 0;
            foreach (int element in array)
            {
                if(comparer(element, value)) count++;
            }
            return count;
        }

    }
}
