using System;

namespace Lab_8
{
    public class Purple_2 : Purple
    {
        private new string[] _output;

        public new string[] Output => _output;
        public Purple_2(string input) : base(input) { }

        public override void Review()
        {
            if (_input == null) return;

            string[] lines = BreakdownString(_input);
            NormalizeToFifty(lines);
            _output = lines;
        }

        public static string[] BreakdownString(string s)
        {
            string[] words = s.Split(' ');
            string[] lines = new string[0];
            string line = "";
            for (int i = 0; i < words.Length - 1; i++)
            {
                line += words[i] + " ";
                if (words[i + 1].Length + line.Length > 50)
                {
                    Array.Resize(ref lines, lines.Length + 1);
                    lines[lines.Length - 1] = line.Trim();
                    line = "";
                }
            };

            return lines;
        }

        public static void NormalizeToFifty(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' ');

                int spacesToAdd = 50 - lines[i].Trim().Length;
                while (spacesToAdd > 0)
                {
                    for (int j = 0; j < words.Length - 1; j++)
                    {
                        if (spacesToAdd <= 0) break;
                        words[j] = words[j] + " ";
                        spacesToAdd--;
                    }
                }
                lines[i] = String.Join(" ", words);
            }
        }

        public override string ToString()
        {
            if (_output == null) return null;

            return String.Join("\n", _output);
        }
    }
}
