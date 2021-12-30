using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public class Exam01
    {
        public void Run()
        {
            AssertString(null, "", ConvertWithIfStatement);
            AssertString("", "", ConvertWithIfStatement);
            AssertString("abc", "123", ConvertWithIfStatement);
            AssertString("abcd", "123", ConvertWithIfStatement);
            AssertString("abcde", "123", ConvertWithIfStatement);
            AssertString("abcdeaa", "123", ConvertWithIfStatement);
            AssertString("abcdefg", "123cg", ConvertWithIfStatement);

            AssertString(null, "", ConvertWithSwitchCase);
            AssertString("", "", ConvertWithSwitchCase);
            AssertString("abc", "123", ConvertWithSwitchCase);
            AssertString("abcd", "123", ConvertWithSwitchCase);
            AssertString("abcde", "123", ConvertWithSwitchCase);
            AssertString("abcdeaa", "123", ConvertWithSwitchCase);
            AssertString("abcdefg", "123cg", ConvertWithSwitchCase);
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

        private string ConvertWithIfStatement(string source)
        {
            // 規則
            // a => 1
            // b => 2
            // c => 3
            // d => 跳過
            // e => 結束
            // ef => c
            // 其餘字元維持原樣
            if (string.IsNullOrWhiteSpace(source)) return "";

            var result = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                var @char = source[i];
                if (@char == 'a')
                {
                    result.Append('1');
                }
                else if (@char == 'b')
                {
                    result.Append('2');
                }
                else if (@char == 'c')
                {
                    result.Append('3');
                }
                else if (@char == 'd')
                {
                    continue;
                }
                else if (@char == 'e')
                {
                    if (i + 1 < source.Length && source[i + 1] == 'f')
                    {
                        result.Append('c');
                        i++;
                    }
                    else
                    {
                        break;
                        // return 也可以 
                        //return result.ToString();
                    }
                }
                else
                {
                    result.Append(@char);
                }
            }
            return result.ToString();
        }

        private string ConvertWithSwitchCase(string source)
        {
            // 規則
            // a => 1
            // b => 2
            // c => 3
            // d => 跳過
            // e => 結束
            // ef => c
            // 其餘字元維持原樣
            if (string.IsNullOrWhiteSpace(source)) return "";

            var result = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                var @char = source[i];
                switch (@char)
                {
                    case 'a':
                        result.Append('1');
                        break;
                    case 'b':
                        result.Append('2');
                        break;
                    case 'c':
                        result.Append('3');
                        break;
                    case 'd':
                        break;
                    case 'e':
                        if (i + 1 < source.Length && source[i + 1] == 'f')
                        {
                            result.Append('c');
                            i++;
                            break;
                        }
                        else
                        {
                            return result.ToString();
                        }
                    default:
                        result.Append(@char);
                        break;
                }
            }
            return result.ToString();
        }
    }
}