using System;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceApp
{
    public class TimeExecutor
    {
        public static void CallTimeExecutor()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            CancellationToken token = cts.Token;

            int timeout = 5000; //1000 ms = 1 sekunda 

            Task task = Task.Run(() => DoSomething(token));

            if (task.Wait(timeout))
            {
                Console.WriteLine("The whole method was done.");
            }
            else
            {
                cts.Cancel();
               // Console.WriteLine("Przekroczono czas wygaśnięcia. Wykonanie przerwane.");
            }
        }

        public static void DoSomething(CancellationToken token)
        {
                
            while(!token.IsCancellationRequested)
            {
                   
            }
            
            Console.WriteLine("Wykrycie upłynięcia limitu czasu");
            return;
        }
    }
}
