using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongToInt
{
    public class MyClass
    {
        public MyClass(string name, long val)
        {
            Name = name;
            Value = val;
        }
        public string Name { get; set; }
        public long Value { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<MyClass>{
                new MyClass("a", 1),
                new MyClass("b", 2),
                new MyClass("c", 3)
            };

            var a = (IEnumerable<MyClass>) list;

            var result = (int)list.FirstOrDefault(item => item.Value == 5)?.Value;
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
