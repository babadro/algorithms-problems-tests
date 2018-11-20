using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_UserInput
{
    public class TextInput
    {
        private string _value;
        public virtual void Add(char c) => _value += c;

        public string GetValue() => _value;
    }

    public class NumericInput : TextInput
    {
        public override void Add(char c)
        {
            if (char.IsNumber(c))
                base.Add(c);
        }
    }

    public class UserInput
    {
        public static void Main(string[] args)
        {
            TextInput input = new NumericInput();
            input.Add('1');
            input.Add('a');
            input.Add('a');
            input.Add('a');
            input.Add('a');
            input.Add('0');
            input.Add('4');
            Console.WriteLine(input.GetValue());
            Console.ReadLine();
        }
    }
}
