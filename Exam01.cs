using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public class Exam01
    {
        public void Run()
        {
            AssertString(null, "", Convert);
            AssertString("", "", Convert);
            AssertString("abc", "123", Convert);
            AssertString("abcd", "123", Convert);
            AssertString("abcde", "123", Convert);
            AssertString("abcdeaa", "123", Convert);
            AssertString("abcdefg", "123cg", Convert);
        }

        private void AssertString(string source, string expected, Func<string, string> func)
        {
            var actual = func(source);
            if (expected == actual)
            {
                Console.WriteLine($"\"{source}\" => \"{actual}\" 正確");
            }
            else
            {
                Console.WriteLine($"\"{source}\" => \"{actual}\" 錯誤，正確答案為 \"{expected}\"");
            }
        }

        private string Convert(string source)
        {
            // 規則
            // a => 1
            // b => 2
            // c => 3
            // d => 跳過
            // e => 結束
            // ef => c
            // 其餘字元不處理

            // 請將處理邏輯寫在這裡
            if (source == null)  //排除source非字元的情況
            {
                Console.WriteLine(source);
            }
            else if (source == "") //排除source非字元的情況
            {
                Console.WriteLine(source);
            }
            else
            {
                string Add_A_to_source = string.Format("{0}A", source); //增加一個字元讓後面的條件判斷不會跳出"超過陣列範圍"
                                                                        // Console.WriteLine(Add_A_to_source);

                for (int i = 0; i < source.Length; i++)
                {
                    if (Add_A_to_source[i] == 'a')
                    {
                        Console.Write("1");
                    }
                    else if (Add_A_to_source[i] == 'b')
                    {
                        Console.Write("2");
                    }
                    else if (Add_A_to_source[i] == 'c')
                    {
                        Console.Write("3");
                    }
                    else if (Add_A_to_source[i] == 'g')
                    {
                        Console.Write("g");
                    }
                    else if (Add_A_to_source[i] == 'd')
                    {
                        continue;
                    }
                    else if (Add_A_to_source[i] == 'e' && Add_A_to_source[i + 1] == 'f')
                    {
                        Console.Write("c");
                    }
                    else if (Add_A_to_source[i] == 'e')
                    {
                        break;
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
