using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    public class TestClass
    {
        public int value;
    }
    public class StringBuilder
    {
        static void Main(string[] args)
        {
            TestClass left = new TestClass() { value = 10 };
            TestClass right = left;

            right.value = 20;
            Console.WriteLine(left.value); //얕은 복사. 참조

            string a = "dd";
            string b = a;

            b = "hello";
            Console.WriteLine(a); //string은 immutable이라 새로 힙주소에 새 인스턴스가 할당되어서 바뀌지않음.
        }

    }
}
