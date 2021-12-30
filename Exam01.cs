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
            // 其餘字元輸出原始字元

            // 請將處理邏輯寫在這裡

            string SingleResult = "";
            string Result = "" ;

            if (source == null)  //排除source為無東西的情況
            {
                Result = "";
            }
            else if (source == "") //排除source空字元的情況
            {
                Result = "";
            }
            else
            {
                string Add_A_to_source = string.Format("{0}A", source); //增加一個字元讓後面的條件判斷不會跳出"超過陣列範圍"
                
                for (int i = 0; i < source.Length; i++)
                {
                    if (Add_A_to_source[i] == 'a')
                    {
                        SingleResult = "1";
                    }
                    else if (Add_A_to_source[i] == 'b')
                    {
                        SingleResult = "2";
                    }
                    else if (Add_A_to_source[i] == 'c')
                    {
                        SingleResult = "3";
                    }
                    else if (Add_A_to_source[i] == 'd')
                    {
                        continue;
                    }
                    else if (Add_A_to_source[i] == 'e' && Add_A_to_source[i + 1] == 'f') //當下字元為e且後一個為f時，條件成立
                    {
                        SingleResult = "c";
                    }
                    else if (Add_A_to_source[i] == 'f' && Add_A_to_source[i - 1] == 'e') //當下字元為f且前一個為e時，條件成立
                    {
                        SingleResult = null;
                    }
                    else if (Add_A_to_source[i] == 'e')
                    {
                        break;
                    }
                    else
                    {
                        SingleResult = char.ToString(source[i]); // source[i] 是字元，要改成字串格式存進SigleResult
                    }
                    Result += SingleResult; 
                }
                Console.WriteLine("");
            }
            return Result;
        }
    }
}