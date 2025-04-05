using System;
using System.Linq;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        public Purple_1(string input) : base(input) { }

        private string Reverse(string s)
        {
            if (s == null) return null;
            if (s.Length <= 1) return s;

            
            int start = 0;
            int end = s.Length-1;

            if (HasPunctuation(s)) //excluding punctuation from both sides
            {
                for (int i = 0; i < s.Length; i++)
                    if (!_punctuationMarks.Contains(s[i]))
                    {
                        start = i;
                        break;
                    }

                for (int i = s.Length - 1; i >= start; i--)
                {
                    if (!_punctuationMarks.Contains(s[i]))
                    {
                        end = i;
                        break;
                    }
                }
            }

            char[] newString = s.ToCharArray();
            for (int i = start, j = end; i <= end; i++, j--)
            {
                newString[i] = s[j];
            }

            return new string(newString);
        }

        public override void Review() 
        {
            if (_input == null) return;

            string[] split = Input.Split(' ');
            
            for (int i = 0; i < split.Length; i++)
            {
                if (HasNumber(split[i])) continue;
                split[i] = Reverse(split[i]);
            }

            _output = String.Join(" ", split).ToString();
        }
    }
}
