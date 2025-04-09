using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronizingResourceAccess
{
    public class SharedObjects
    {
        public static string? Message; // a shared resource

        public static object Conch = new(); // A shared object to lock
        public static int Counter; // Another shared resource
    }
}
