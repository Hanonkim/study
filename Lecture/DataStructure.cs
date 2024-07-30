using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    public class DataStructure
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            list.Add(1);


            list.Insert(0, 5);
            list.Insert(1, 5);
            list.Insert(2, 15);
            list.Insert(3, 13);
            list.Insert(4, 13);
            list.Insert(5, 13); //insert할 때 현재 size내에서 index지정하거나, size가 초과경우 size+1 늘어나게될 공간 이내에서 index를 설정?\
            list.Insert(7, 5);
        }
    }
}
