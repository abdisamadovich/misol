using System;

class Program
{
    public class Solution
    {
        public bool MaxDepth(string input, string pattern)
        {
            int i = 0;
            int j = 0;
            int i_input = -100;
            int j_pattern = -100;
            while (i < input.Length)
            {
                if (j < pattern.Length && (pattern[j] == '?' || pattern[j] == input[i]))
                {
                    i++;
                    j++;
                }
                else if (j < pattern.Length && pattern[j] == '*')
                {
                    i_input = i;
                    j_pattern = j;
                    j++;
                }
                else if (i_input != -100)
                {
                    i_input++;
                    i = i_input;
                    j = j_pattern + 1;
                }
                else
                {
                    return false;
                }
            }
            if (j == pattern.Length)
                return true;
            else 
                return false;
        }
    }

    static void Main(string[] args)
    {
        var list = new[]
        {
            new
            {
                Input = "heello.txt",
                Pattern = "h??llo**?******"
            },
            new
            {
                Input = "aaaaaaabcabhellobcbaaabcbaaa",
                Pattern = "a*b?b*a"
            },
            new
            {
                Input = "112345678@#$%^&*()_**_",
                Pattern = "*@*(*)_"
            },
            new
            {
                Input = "Hello world comes here",
                Pattern = "e*o??d*e*e*e*"
            },
            new
            {
                Input = "",
                Pattern = "h??llo**?******"
            },
            new
            {
                Input = "heello.txt",
                Pattern = ""
            },
            new
            {
                Input = "bc".PadLeft(10000, 'a'),
                Pattern = "a*bc"
            },
        }.ToList();

        Solution solution = new Solution();
        foreach (var item in list)
        {
            var result = solution.MaxDepth(item.Input, item.Pattern);
            Console.WriteLine($"{item.Pattern}: {item.Input} - {result}");
        }
    }
}


