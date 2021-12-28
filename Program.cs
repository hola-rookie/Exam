using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            // a => 1
            // b => 2
            // c => 3
            // d => 跳過
            // e => 結束
            // ef => c
            // 其餘字元不處理

            Console.WriteLine(Convert(null) == "");
            Console.WriteLine(Convert("") == "");
            Console.WriteLine(Convert("abc") == "123");
            Console.WriteLine(Convert("abcd") == "123");
            Console.WriteLine(Convert("abcde") == "123");
            Console.WriteLine(Convert("abcdeaa") == "123");
            Console.WriteLine(Convert("abcdefg") == "123cg");
        }

        static string Convert(string source)

        {
            // 請將處理邏輯寫在這裡
            string Raw_Data = source;
            
            if (Raw_Data == null)
             {
                Console.WriteLine(Raw_Data);
               // Console.WriteLine("Hello");
             }
             else if (Raw_Data == "")
             {
                //Console.WriteLine("Hello");
             }  
             else
             { 
                 for (int i=0; i < source.Length; i++)
                 {
                    if (Raw_Data[i] == 'a')
                    {
                        Console.Write("1");
                    }
                    else if (Raw_Data[i] == 'b')
                    {
                        Console.Write("2");
                    }
                    else if (Raw_Data[i] == 'c' && Raw_Data[i + 1] == 'f')
                    {
                        Console.Write("c");
                    }
                    else if (Raw_Data[i] == 'c')
                    {
                        Console.Write("3");
                    }
                    else if (Raw_Data[i] == 'g')
                    {
                        Console.Write("g");
                    }
                    else if (Raw_Data[i] == 'd')
                    {
                        continue;
                    }
                    else if (Raw_Data[i] == 'e')
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                 }
                Console.WriteLine("");
            }
            return source;
        }
    }
}
//把source裡的字串一個一個做讀取判斷
/*
 for(讀取所有source字元數量跟內容)
    if      (讀到a)
        輸出1
    else if (讀到b)
        輸出2
    else if (讀到c && 下一個為f)
        輸出c
    else if (讀到c)
        輸出3
    eles if (讀到g)
        輸出g
    else
        輸出""
 
 */
