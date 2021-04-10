using System.Threading.Tasks;

namespace Teamone.FunctionApp
{
    public interface IMessageService
    {
        Task Send(string msg);
    }
}