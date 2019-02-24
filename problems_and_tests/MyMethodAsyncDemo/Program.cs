using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MyMethodAsyncDemo
{
    class Program
    {
        //private static async Task<string> MyMethodAsync(Int32 argumetn)
        //{
        //    Int32 local = argument;
        //    try
        //    {
        //        Type1 result1 await Method1Async();
        //        for (Int32 x = 0; x < 3; x++)
        //        {
        //            Type2 result2 = await Method2Async();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Catch");
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Finally");
        //    }
        //}

        [DebuggerStepThrough, AsyncStateMachine(typeof(StateMachine))]
        private static Task<String> MyMethodAsync(Int32 argument)
        {
            // Создаем экземпляр State machine и инициализируем его
            StateMachine stateMachine = new StateMachine()
            {
                // Создаем билдер, возвращающий Task<string> из этого метода
                // Билдер доступа, который ставит таску в состояние выполнена или исключение
                m_builder = AsyncTaskMethodBuilder<string>.Create(),
                m_state = -1, // Начальное состояние
                m_argument = argument // Копируем аргументы в State machine
            };

            // Запускаем выполнение State machine
            stateMachine.m_builder.Start(ref stateMachine);
            return stateMachine.m_builder.Task; //возвращаем таску
        }

        [CompilerGenerated, StructLayout(LayoutKind.Auto)]
        private struct StateMachine : IAsyncStateMachine
        {
            // Поля для билдера и его состояния
            public AsyncTaskMethodBuilder<String> m_builder;
            public Int32 m_state;

            // Аргументы и локальные переменные
            public Int32 m_argument, m_local, m_x;
            public Type1 m_resultType1;
            public Type2 m_resultType2;

            // На каждый аваитер - по полю.
            // Только одно из этих полей имеет значение в каждый момент времени.
            // Поля указывают на последний (самый новый) аваит, выполненный асинхронно

            private TaskAwaiter<Type1> m_awaiterType1;
            private TaskAwaiter<Type2> m_awaiterType2;

            // Собственно ключево метод State machine
            void IAsyncStateMachine.MoveNext()
            {
                String result = null; // Результат нашей таски

                // Компилятор вставляет try блок, чтобы убедиться, что таски выполнены
                try
                {
                    Boolean executeFinally = true; // Предположим, мы уже покинули трай-блок
                    if (m_state == -1)  // Если мы в этом тут впервые, запускаем исходный метод
                    {
                        m_local = m_argument;
                    }

                    // А это именно тот трай блок, который у нас есть в исходном коде
                    try
                    {
                        TaskAwaiter<Type1> awaiterType1;
                        TaskAwaiter<Type2> awaiterType2;

                        switch (m_state)
                        {
                            case -1: // Начинаем выполнения с блока трай
                                     // Вызываем первый асинхронный метод и получаем его аваитер
                                awaiterType1 = Method1Async().GetAwaiter();
                                if (!awaiterType1.IsCompleted)
                                {
                                    m_state = 0;    // Находимся в состоянии "Выполняем первый асинхронный метод"
                                    m_awaiterType1 = awaiterType1; // Сохраняем аваитер в локальную переменную, чтобы использовать потом

                                    // Инструктируем аваитер, чтобы он вызывал MoveNext, когда его операция выполнится
                                    m_builder.AwaitUnsafeOnCompleted(ref awaiterType1, ref this);
                                    // Линия выше вызовет ContinueWith(t => MoveNext()) на таске, которую аваитер ждет.
                                    // Когда таска завершится, вызовется MoveNext

                                    executeFinally = false; // Мы пока еще не покинули блок Трай.
                                    return; // Тред возвращается к тому, кто его вызывал.
                                }
                                // Первый асинхронный метод выполнился СИНХРОННО
                                break;

                            case 0: // Первый асинхронный методв выполнен асинхронно
                                awaiterType1 = m_awaiterType1; // Восстанавливаем последний аваитер
                                break;

                            case 1: // Второй асинхронный метод выполнился асинхронно
                                awaiterType2 = m_awaiterType2; // Восстанавливаем последний аваитер
                                goto ForLoopEpilog;
                        }

                        // После первого аваита сохраняем результат и стартуем цикл фо
                        m_resultType1 = awaiterType1.GetResult();

                    ForLoopPrologue:
                        m_x = 0; // инициализация цикла фор
                        goto ForLoopBody;

                    ForLoopEpilog:
                        m_resultType2 = awaiterType2.GetResult();
                        m_x++;
                        // Попадаем в тело цикла

                    ForLoopBody:
                        if (m_x < 3) // Тест цикла
                        {
                            // Вызываем второй асинхронны метод и его аваитер
                            awaiterType2 = Method2Async().GetAwaiter();
                            if (!awaiterType2.IsCompleted)
                            {
                                m_state = 1; // Состояние "Выполняем второй асинхронный метод"
                                m_awaiterType2 = awaiterType2; // Сохраняем аваитер, чтобы потом использовать.

                                // Инструктируем аваитер, чтобы тот вызвал MoveNext, когда операция завершится
                                m_builder.AwaitUnsafeOnCompleted(ref awaiterType2, ref this);
                                executeFinally = false; // Мы еще не покинули трай блок
                                return; // Возвращаем тред
                            }
                            // Второй асинхронный метод  выполнен синхронно
                            goto ForLoopEpilog; // Выполнен синхронно, приступаем к следующей итерации
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Catch");
                    }
                    finally
                    {
                        if (executeFinally)
                        {
                            Console.WriteLine("Finally");
                        }
                    }
                    result = "Done"; // Это мы хотим в итоге вернуть из асинхронного метода.
                }
                catch (Exception exception)
                {
                    // Необработанное исключение во время выполнения TaskMachine
                    m_builder.SetException(exception);
                    return;
                }

                // Нет ошибок: Task Machine выполнела таску с результатом
                m_builder.SetResult(result);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
