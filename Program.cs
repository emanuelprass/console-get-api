using System;
using System.Net;
using System.Text;
using System.Threading;

namespace bsi_push_data_into_api
{
    class Program
    {
        private static Timer _timer = null;
        static void Main(string[] args)
        {
            _timer = new Timer(TimerCallback, null, 0, (10 * 1000));
            Console.ReadLine();
        }

        private static void TimerCallback(Object o)
        {
            Retrieve_Post_Update execute = new Retrieve_Post_Update();
            execute.Execute();
        }
    }
}
