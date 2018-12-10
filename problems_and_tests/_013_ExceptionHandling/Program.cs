using System;

namespace _013_ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TryCast();
            }
            catch ( Exception ex)
            {
                // Catch the exception that is unhandled in TryCast
                Console.WriteLine("Catching the {0} exception triggers the finally block.", ex.GetType());

                // Restore the original unhandled exception. You might not know what exception to expect, or how to handle it, so pass it on.
                throw;
            }
        }

        static void TryCast()
        {
            int i = 123;
            string s = "Some string";
            object obj = s;

            try
            {
                i = (int)obj;

                Console.WriteLine("WriteLine at the ind of the try block. ");
            }
            finally
            {
                // Reposrt that the finnaly block is run, and show that the value of i has not been changed.
                Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", i);
            }
        }
    }
}
