using System.Threading.Tasks;

namespace Teamone.FunctionApp
{
    public class ConsoleMessageService : IMessageService
    {
        public Task Send(string msg)
        {
            System.Console.WriteLine(msg);

            return Task.CompletedTask;
        }
    }
}