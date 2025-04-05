using System.Linq;
using System;

namespace Lab_8
{
    public class Purple_3 : Purple
    {
        public Purple_3(string input) : base(input) {
            _codes = null;
        }
        private (string, char)[] _codes;

        public (string, char)[] Codes => ((string, char)[])_codes?.Clone();
        public override void Review()
        {
            if (_input == null) return;

            var test = GetSubsequences();
            SortTupleArray(test);
            if (test.Length > 5)
            {
                Array.Resize(ref test, 5);
            }
            string[] toReplace = new string[test.Length];
            for (int i = 0; i < toReplace.Length; i++)
            {
                toReplace[i] = test[i].Item1;
            }

            string[] asciiSymbols = new string[126 - 33 + 1];
            for (int i = 33; i <= 126; i++)
                asciiSymbols[i - 33] = ((char)i).ToString();

            string[] asciiFive = asciiSymbols.Where(s => !Input.Contains(s)).Take(5).ToArray();

            (string, char)[] codes = new (string, char)[5];
            for (int i = 0; i < codes.Length; i++)
            {
                codes[i] = (toReplace[i], asciiFive[i][0]);
            }
            _codes = codes;
            _output = _input;

            for(int i = 0; i < 5; i++)
            {
                _output = _output.Replace(toReplace[i], asciiFive[i]);
            }

        }


        private (string, int)[] GetSubsequences()
        {
            string[] words = Input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = CutPunctuation(words[i]);
            }

            (string, int)[] subsequences = new (string, int)[0];
            foreach (string word in words)
            {
                for (int i = 0; i < word.Length - 1; i++)
                {
                    string twoLetters = word.Substring(i, 2);

                    bool found = false;
                    for (int j = 0; j < subsequences.Length; j++)
                    {
                        if (subsequences[j].Item1 == twoLetters)
                        {
                            subsequences[j].Item2++;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Array.Resize(ref subsequences, subsequences.Length + 1);
                        subsequences[subsequences.Length - 1] = (twoLetters, 1);
                    }
                }
            }

            return subsequences;
        }

        private static void SortTupleArray((string, int)[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var key = arr[i];
                int j = i - 1;


                while (j >= 0 && arr[j].Item2 < key.Item2)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
    }
}
