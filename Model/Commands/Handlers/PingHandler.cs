using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Teamone.FunctionApp.Commands.Handlers
{
    public class PingHandler : IRequestHandler<Ping, string>
    {
        private readonly IMessageService messsages;
        private readonly IMediator mediator;

        public PingHandler(IMessageService messsages, IMediator mediator)
        {
            this.messsages = messsages;
            this.mediator = mediator;
        }

        public async Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            var msg = $"Ping ({request.Message})";

            await messsages.Send(msg);

            await mediator.Publish(new PingCalled {});

            return msg;
        }
    }
}