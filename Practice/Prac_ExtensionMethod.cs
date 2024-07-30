using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace study.Practice
{
    /*
     * string 타입에 ID에 특문을 비허용하는 아이디 유효성 검증 기능 추가
     */
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("아이디를 입력하세요 : ");
            string id = Console.ReadLine();

            if (id.IsAllowedID())
            {
                Console.WriteLine("ID가 유효합니다.");
            }
            else
            {
                Console.WriteLine("ID가 비어있거나 허용되지 않는 특수문자가 있습니다.");
            }
        }
    }

    public static class ExtensionClass
    {
        private static char[] specialCharArray = { '!', '@', '#', '$', '%', '^', '&', '*' }; //특문 문자열
        public static bool IsAllowedID(this string idText)
        {
            char[] charArray = idText.ToCharArray(); //입력받은 문자열을 문자단위로 쪼갬

            if (idText.Length == 0 || idText == null) //비어있거나 null이면 false
            {
                return false;
            }

            for (int i = 0; i < specialCharArray.Length; i++)
            {
                for (int j = 0; j < charArray.Length; j++)
                {
                    if (charArray[j] == specialCharArray[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    }
