
using SynchronizingResourceAccess;

partial class Program
{
    private static void MethodA()
    {
        /*
         * IMPORTANT NOTE:
         * Lock only works on reference types, not value types
         * This is because the memory address is locked
         * not the intrinsic data of the object.
         */
        /*
         * lock(SharedObjects.Conch) {} is equivalent to:
         * try{ Monitor.Enter(SharedObjects.Conch)}
         * finally{ Monitor.Exit(SharedObjects.Conch)}
         */

        try
        {
            // Establish a timeout to prevent deadlocks. Seems v messy to me...
            if(Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
            {
                for (int i = 0; i < 5; i++)
                {
                    // Simulate two seconds of work on the current thread
                    Thread.Sleep(Random.Shared.Next(2000));

                    // Concatenate the letter "A" to the shared message.
                    SharedObjects.Message += "A";
                    Interlocked.Increment(ref SharedObjects.Counter);
                    // Show some activity in the console output
                    Write(".");
                }
            }
            else
            {
                WriteLine("Method B timed out when entering a monitor on Conch.");
            }
        }
        finally
        {
            Monitor.Exit(SharedObjects.Conch);
        }
    }
    private static void MethodB()
    {
        try
        {
            // Establish a timeout to prevent deadlocks. Seems v messy to me...
            if (Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
            {
                for (int i = 0; i < 5; i++)
                {
                    // Simulate two seconds of work on the current thread
                    Thread.Sleep(Random.Shared.Next(2000));

                    // Concatenate the letter "B" to the shared message.
                    SharedObjects.Message += "B";
                    Interlocked.Increment(ref SharedObjects.Counter);
                    // Show some activity in the console output
                    Write(".");
                }
            }
            else
            {
                WriteLine("Method B timed out when entering a monitor on Conch.");
            }
        }
        finally
        {
            Monitor.Exit(SharedObjects.Conch);
        }
    }
}