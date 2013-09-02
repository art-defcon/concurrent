using System;
using System.Diagnostics;

namespace CSharpLibrary
{
    /// <summary>
    /// Helper class to check frequency system is running at.
    /// </summary>
    public static class Threadhelper
    {
        public static void DisplayTimerProperties()
        {
            // Display the timer frequency and resolution. 
            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Operations timed using the system's high-resolution performance counter.");
            }
            else
            {
                Console.WriteLine("Operations timed using the DateTime class.");
            }

            long frequency = Stopwatch.Frequency;
            Console.WriteLine("  Timer frequency in ticks per second = {0}",
                              frequency);
            long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
            Console.WriteLine("  Timer is accurate within {0} nanoseconds",
                              nanosecPerTick);
        }
    }
}