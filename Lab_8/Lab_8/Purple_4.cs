using System.Text;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        public string Output => _output;

        private (string, char)[] _codes;
        public Purple_4(string input, (string, char)[] codes) : base(input)
        {
            _input = input;
            _codes = codes;
        }
        public override void Review()
        {
            if (_input == null) return;

            var answer = new StringBuilder(_input);

            foreach(var code in _codes)
            {
                if (code.Item1 == null) continue;
                answer = answer.Replace(code.Item2.ToString(), code.Item1);
            }

            _output = answer.ToString();
        }
    }
}
