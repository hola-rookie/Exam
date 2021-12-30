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

            string[] Result_array = new string[source.Length];

            if (source == null)  //排除source非字元的情況
            {
                Result_array = null;
            }
            else if (source == "") //排除source非字元的情況
            {
                Result_array = null;
            }
            else
            {
                string Add_A_to_source = string.Format("{0}A", source); //增加一個字元讓後面的條件判斷不會跳出"超過陣列範圍"                                                       // Console.WriteLine(Add_A_to_source);

                for (int i = 0; i < source.Length; i++)
                {
                    if (Add_A_to_source[i] == 'a')
                    {
                        //Console.Write("1");
                        string Result = "1";
                        Result_array[i] = Result;
                    }
                    else if (Add_A_to_source[i] == 'b')
                    {
                        //Console.Write("2");
                        string Result = "2";
                        Result_array[i] = Result;
                    }
                    else if (Add_A_to_source[i] == 'c')
                    {
                        //Console.Write("3");
                        string Result = "3";
                        Result_array[i] = Result;
                    }
                    else if (Add_A_to_source[i] == 'g')
                    {
                        //Console.Write("g");
                        string Result = "g";
                        Result_array[i] = Result;
                    }
                    else if (Add_A_to_source[i] == 'd')
                    {
                        continue;
                    }
                    else if (Add_A_to_source[i] == 'e' && Add_A_to_source[i + 1] == 'f')
                    {
                        Console.Write("c");
                        string Result = "c";
                        Result_array[i] = Result;
                    }
                    else if (Add_A_to_source[i] == 'e')
                    {
                        break;
                    }

                    
                }
                Console.WriteLine("");
            }
            return Result_array;
        }
    }
}