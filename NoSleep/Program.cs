using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoSleep
{
    public class Program
    {
        static void Main(string[] args)
        {
            var app = new App();
            app.Run();
            Console.ReadLine();
        }
    }

    public class App
    {
        public void Run() {
            Kernel32.SetThreadExecutionState(Kernel32.EXECUTION_STATE.ES_DISPLAY_REQUIRED 
                                             | Kernel32.EXECUTION_STATE.ES_CONTINUOUS 
                                             | Kernel32.EXECUTION_STATE.ES_SYSTEM_REQUIRED 
                                             //| Kernel32.EXECUTION_STATE.ES_AWAYMODE_REQUIRED
                                            );
            
            Thread.Sleep(Timeout.Infinite);
        }
    }

    public class Kernel32
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [Flags]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001,
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
            NULL = 0x00000000
        }
    }
}
