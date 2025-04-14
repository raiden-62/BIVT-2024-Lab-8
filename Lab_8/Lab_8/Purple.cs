using System.Linq;

namespace Lab_8
{
    public abstract class Purple
    {
        protected string _input;
        protected string _output;

        static protected readonly char[] _sentenceEnders = {'.', '!', '?'};
        static protected readonly char[] _punctuationMarks = { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
        static protected readonly char[] _numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public string Input => _input;

        public Purple(string input)
        {
            _input = input;
        }

        protected static string CutPunctuation(string s)
        {
            int start = 0, end = s.Length - 1;
            if (HasPunctuation(s))
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
            return s.Substring(start, end-start+1);
        }

        protected static bool HasPunctuation(string s) {
            foreach (char p in _punctuationMarks)
            {
                foreach(char c in s)
                {
                    if (c == p) return true;
                }
            }
            return false;
        }

        protected static bool HasNumber(string s) {
            foreach(char c in s)
            {
                if (_numbers.Contains(c)) return true;
            }
            return false;
        }

        public abstract void Review();

        public override string ToString()
        {
            return _output;
        }

    }
}
