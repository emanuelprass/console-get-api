using System;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace bsi_push_data_into_api
{
    class Program
    {
        private static Timer _timer = null;

        static void Main(string[] args)
        {
            int interval = Convert.ToInt32(ConfigurationManager.AppSettings["interval"]);
            _timer = new Timer(TimerCallback, null, 0, interval);
            Console.ReadLine();
        }

        private static void TimerCallback(Object o)
        {
			try
			{
                Console.WriteLine(string.Concat(Enumerable.Repeat("=", 30)) + "QUEUE MANAGEMENT CRON JOB " + string.Concat(Enumerable.Repeat("=", 30)));
                Console.WriteLine("Execution time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));

                App_Handler handler = new App_Handler();
                handler.Execute();
            } 
            catch(Exception ex)
			{
                Console.WriteLine("Error while execute console >>>>> ", ex.Message);
			}
            
        }
    }
}
