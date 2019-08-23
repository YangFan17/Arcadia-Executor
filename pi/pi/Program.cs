using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace pi
{
    public class Program
    {
        static bool isOn1 = false;
        static bool isOn2 = false;
        static bool isOn3 = false;
        static bool isOn4 = false;
        static void Main(string[] args)
        {
            // Get a reference to the pin you need to use.
            // All 3 methods below are exactly equivalent
            Pi.Init<BootstrapWiringPi>();
            var blinkingPin1 = Pi.Gpio[BcmPin.Gpio21];
            var blinkingPin2 = Pi.Gpio[BcmPin.Gpio20];
            var blinkingPin3 = Pi.Gpio[BcmPin.Gpio27];
            var blinkingPin4 = Pi.Gpio[BcmPin.Gpio17];
            // Configure the pin as an output
            blinkingPin1.PinMode = GpioPinDriveMode.Output;
            blinkingPin2.PinMode = GpioPinDriveMode.Output;
            blinkingPin3.PinMode = GpioPinDriveMode.Output;
            blinkingPin4.PinMode = GpioPinDriveMode.Output;
            // perform writes to the pin by toggling the isOn variable

            for (var i = 1; i < 822; i++)
            {
                Console.WriteLine("Hello Led{0}", i);
                if (i >= 4)
                {
                    var num = i % 4;
                    Twinkle(num);
                    //Console.WriteLine("Hello Led{0}", num);
                }
                else
                {
                    Twinkle(i);
                    //Console.WriteLine("Hello Led{0}", i);
                }

                blinkingPin1.Write(isOn1);
                blinkingPin2.Write(isOn2);
                blinkingPin3.Write(isOn3);
                blinkingPin4.Write(isOn4);
                System.Threading.Thread.Sleep(100);
            }

        }

        static void Twinkle(int no)
        {
            if (no ==1)
            {
                isOn1 = true;
                isOn2 = false;
                isOn3 = false;
                isOn4 = false;
            }
            else if (no == 2)
            {
                isOn1 = false;
                isOn2 = true;
                isOn3 = false;
                isOn4 = false;
            }
            else if (no == 3)
            {
                isOn1 = false;
                isOn2 = false;
                isOn3 = true;
                isOn4 = false;
            }
            else if (no == 0)
            {
                isOn1 = false;
                isOn2 = false;
                isOn3 = false;
                isOn4 = true;
            }
        }
    }
}
