﻿using System;
using System.Collections;
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
            //SimpleBoxUnboxOperation();

            //WorkWithArrayList();

            //ArrayListOfRandomObjects();

            //UsePersonCollection();

            UseGenericList();

            Console.ReadLine();
        }

        private static void UseGenericList()
        {
            Console.WriteLine("***** Fun with Generics *****\n");
            // This List<> can hold only Person objects.
            List<Person> morePeople = new List<Person>();

            morePeople.Add(new Person("Frank", "Black", 50));
            Console.WriteLine(morePeople[0]);
            
            // This List<> can hold only integers.
            List<int> moreInts = new List<int>();
            moreInts.Add(10);
            moreInts.Add(2);

            int sum = moreInts[0] + moreInts[1];

            // Compile-time error! Can't add Person object to a list of ints!
            // moreInts.Add(new Person());

        }

        private static void UsePersonCollection()
        {
            Console.WriteLine("***** Custom Person Collection *****\n");

            PersonCollection myPeople = new PersonCollection();

            myPeople.AddPerson(new Person("Homer", "Simpson", 40));
            myPeople.AddPerson(new Person("Marge", "Simpson", 38));
            myPeople.AddPerson(new Person("Lisa", "Simpson", 9));
            myPeople.AddPerson(new Person("Bart", "Simpson", 7));
            myPeople.AddPerson(new Person("Maggie", "Simpson", 2));

            // This would be a compile-time error! myPeople.AddPerson(new Car());
            foreach (Person p in myPeople)
            {
                Console.WriteLine(p);
            }
        }

        private static void ArrayListOfRandomObjects()
        {
            // The ArrayList can hold anything at all.
            ArrayList allMyObjects = new ArrayList();
            allMyObjects.Add(true);
            allMyObjects.Add(new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)));
            allMyObjects.Add(66);
            allMyObjects.Add(3.14);

        }

        private static void WorkWithArrayList()
        {
            // Value types are automatically boxed when passed to a method requesting an object.
            ArrayList myInts = new ArrayList();

            //Console.WriteLine(myInts.GetType().Name);

            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(35);

            //Console.WriteLine(myInts[1].GetType().Name);

            // Unboxing occurs when an object is converted back to stack-based data.
            int i = (int)myInts[0];

            // Now it is reboxed, as WriteLine() requires object types!
            Console.WriteLine("Value of your int: {0}", i);
        }

        private static void SimpleBoxUnboxOperation()
        {
            // Make a ValueType (int) variable.
            int myInt = 25;
            // Box the int into an object reference.
            object boxedInt = myInt;

            // Unbox in the wrong data type to trigger runtime exception.
            try
            {
                long unboxedInt = (long)boxedInt;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //ArrayList 

            //// Unbox the reference back into a corresponding int.
            //int unboxedInt = (int)boxedInt;
        }
    }
}
