using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Teamone.FunctionApp.Events.Handlers
{
    public class PingCalledHandler : INotificationHandler<PingCalled>
    {
        private readonly IMessageService messages;

        public PingCalledHandler(IMessageService messages)
        {
            this.messages = messages;
        }

        public Task Handle(PingCalled notification, CancellationToken cancellationToken)
        {
            return messages.Send("Ping called");
        }
    }
}