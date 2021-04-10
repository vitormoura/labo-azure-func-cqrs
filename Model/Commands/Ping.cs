using MediatR;

namespace Teamone.FunctionApp.Commands
{
    public class Ping : IRequest<string>
    {
        public string Message { get; set; }
    }
}