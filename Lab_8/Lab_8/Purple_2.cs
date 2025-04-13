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

        private static string[] BreakdownString(string s)
        {
            string[] words = s.Split(' ');
            string[] lines = new string[0];
            string currentLine = "";

            foreach (string word in words)
            {
                if (string.IsNullOrEmpty(word)) continue;

                int newLength = currentLine.Length;
                if (newLength > 0) newLength += 1;

                newLength += word.Length;

                if (newLength > 50)
                {
                    Array.Resize(ref lines, lines.Length + 1);
                    lines[lines.Length - 1] = currentLine;
                    currentLine = word;
                }
                else
                {
                    if (currentLine.Length > 0) currentLine += " ";
                    currentLine += word;
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
            {
                Array.Resize(ref lines, lines.Length + 1);
                lines[lines.Length - 1] = currentLine;
            }

            return lines;
        }

        private static void NormalizeToFifty(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' ');
                if (words.Length <= 1) continue;

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
