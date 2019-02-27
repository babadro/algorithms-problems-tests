using System;
using System.Threading;

namespace SingleInstanceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean createdNew;

            using (new Semaphore(0, 1, "SomeUniqueStringIdentifyingMyApp", out createdNew))
            {
                if (createdNew)
                {
                    // Этот поток создал кернел-объект и больше ни один инстанц этого приложения запуститься не может. 
                    // тут код всего приложения
                }
                else
                {
                    // Поток зашел, увидел, что кернел-объект с уникальным именем-идентификатором приложения уже существует
                    // и попал сюда. Ему остается только выйти из Main и завершить этот Instance приложения.
                }

            }
            Console.WriteLine("Hello World!");
        }
    }
}
