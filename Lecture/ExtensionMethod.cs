using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    public class ExtensionMethod
    {
        static void Main(string[] args)
        {
            float value = 2.7f;
            int a;
            //ExtensionFunc.AAA(value); //원래 이건데
            //value.AAA(); //확장메서드로 간소화

            Console.WriteLine(value.Round());
            
        }
    }
    public static class ExtensionFunc
    {
        public static int Round(this float target)
        {
            if(target % 1 >= 0.5f)
            {
                return (int)(target+1);
            }
            else return (int)(target);
        }
    }
}
