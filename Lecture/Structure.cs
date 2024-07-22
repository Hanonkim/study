using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace study.Lecture
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)] //이걸로 패딩 공간 커스텀 가능
    struct Environ_PVE 
    {
        //데이터 저장 목적
        //가령, 게임의 환경을 결정하는 물리환경변수들을 정리해놓는 구조체
        //.net에선 구조체로 정수, 실수, 부울, 유니코드 등을 표현하였음
        //변하지 않는 값immutable을 구조체로 사용 권장
        private float gravity = 9.8f; //private 명시하는게 좋음
        public Environ_PVE(short acc, float power)
        {
            Acc = acc;
            Power = power;
        }

        public short Acc { get; } //byte padding 발생하여 이 구조체의 크기는 12. 
        public double Power { get; }
    }
    internal class Structure
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Marshal.SizeOf(typeof(Environ_PVE)));
        }
    }
}
