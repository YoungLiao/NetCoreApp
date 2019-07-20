using System.Threading;

namespace WindowsService1
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new Service1();
            svc.OnStart(args);

            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
