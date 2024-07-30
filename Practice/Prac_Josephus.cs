using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Practice
{
    //n명의 사람이 원형으로 앉음
    //다 제거할 때까지 k번째 제거
    //시작위치 + k-1 : 시작위치에서 k-1만큼 이동하면 현재 배열에서 k번째 사람이 제거해야할 사람
    //이후에 시작위치와 배열정보를 갱신한다.
    //사람이 모두제거될때까지 반복
    public class Prac_Josephus
    {
        public List<int> Josephus(int n, int k)
        {
            List<int> list = new List<int>();
            List<int> answer = new List<int>();
            //n값만큼 입력
            for (int i = 0; i < n; i++)
            {
                list.Add(i + 1);
            }

            int baseIndex = 0; //최초 시작점은 0번째
            while(list.Count > 0) //배열이 빌 때까지 제거 반복
            {
                baseIndex = (baseIndex + k - 1) % list.Count;
                answer.Add(list[baseIndex]);
                list.RemoveAt(baseIndex);
            }
            return answer;
        }
        static void Main(string[] args)
        {
            Prac_Josephus prac_Josephus = new Prac_Josephus();
            List<int> answer = prac_Josephus.Josephus(7, 3);

            foreach (int i in answer)
            {
                Console.WriteLine(i);
            }
        }
    }
}
