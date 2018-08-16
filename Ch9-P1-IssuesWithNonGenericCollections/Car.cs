using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch7_P1_SimpleException
{
    class Car : IComparable<Car>
    {
        // Constant for maximum speed.
        public const int MaxSpeed = 100;
        // Car properties.
        public int CurrentSpeed { get; set; } = 0;
        public string CarName { get; set; } = "";
        // Is the car still operational?
        private bool carIsDead;
        // A car has-a radio.
        //private Radio theMusicBox = new Radio();

        public int CarID { get; set; }


        // Constructors.

        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            CarName = name;
        }

        public void CrankTunes(bool state)
        {
            // Delegate request to inner object.
            //theMusicBox.TurnOn(state);
        }

        // See if Car has overheated.
        public void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", CarName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    //Console.WriteLine("{0} has overheated!", PetName);
                    CurrentSpeed = 0;
                    carIsDead = true;

                    //// Use the "throw" keyword to raise an exception.
                    //throw new Exception($"{CarName} has overheated!");



                    // We need to call the HelpLink property, thus we need to
                    // create a local variable before throwing the Exception object.
                    Exception ex = new Exception($"{CarName} has overheated!");
                    ex.HelpLink = "http://www.Apni-Auqat-Main-Raho.com";

                    // Stuff in custom data regarding the error.
                    ex.Data.Add("TimeStamp", $"The car exploded at {DateTime.Now}");
                    ex.Data.Add("Cause", "You have a Loud foot.");

                    throw ex;
                }
                else
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }

        // IComparable<T> implementation.
        int IComparable<Car>.CompareTo(Car obj)
        {
            if (this.CarID > obj.CarID)
                return 1;
            if (this.CarID < obj.CarID)
                return -1;
            else
                return 0;
        }

    }
}
