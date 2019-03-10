using System;
using System.Reflection;

namespace _09_DynamicExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Object target = "Jeffry Richter";
            Object arg = "ff";

            // Ищем метод в target, который соответствует желаемому типу аргумента
            Type[] argTypes = new Type[] { arg.GetType() };
            MethodInfo method = target.GetType().GetMethod("Contains", argTypes);

            // Вызываем метод в target, передавая нужные аргументы
            Object[] arguments = new object[] { arg };
            Boolean result = Convert.ToBoolean(method.Invoke(target, arguments));

            // А можно написать гораздо проще:
            dynamic dynamicTarget = "Jeffrey Richter";
            dynamic dynamicArg = "ff";
            Boolean result2 = dynamicTarget.Contains(arg);
        }
    }
}
