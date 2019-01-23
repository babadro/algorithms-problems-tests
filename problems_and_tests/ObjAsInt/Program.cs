using System;

namespace _02_ObjAsInt
{
    class Program
    {
        static void Main(string[] args)
        {
            #region as
            var myobj = new object();
            //var objAsInt = myobj as int; Doesn't compile. Reference or nullable type is allowed
            var objAsNullableInt = myobj as int?; // objAsNullableInt is null
            Console.WriteLine(objAsNullableInt == null); // True
            #endregion


            #region is
            var check = myobj is int;
            Console.WriteLine(check); //False

            var mystr = "asdf";
            var objStr = (object)mystr;
            Console.WriteLine(objStr is object); // True
            Console.WriteLine(objStr is string); // True

            var myInt = 234;
            var objInt = (object)myInt;
            Console.WriteLine(objInt is object); // True
            Console.WriteLine(objInt is int);   // True
            Console.WriteLine(objInt is 234);   // True
            Console.WriteLine(objInt is 11);    // False
            #endregion
        }
    }
}
