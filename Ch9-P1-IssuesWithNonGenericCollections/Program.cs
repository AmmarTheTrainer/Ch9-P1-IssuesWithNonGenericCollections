using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch9_P1_IssuesWithNonGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleBoxUnboxOperation();

            Console.ReadLine();
        }

        private static void SimpleBoxUnboxOperation()
        {
            // Make a ValueType (int) variable.
            int myInt = 25;
            // Box the int into an object reference.
            object boxedInt = myInt;

            // Unbox the reference back into a corresponding int.
            int unboxedInt = (int)boxedInt;
        }
    }
}
