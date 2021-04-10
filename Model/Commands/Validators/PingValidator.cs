using FluentValidation;

namespace Teamone.FunctionApp.Commands.Validators
{
    public class PingValidator : AbstractValidator<Ping> {

        public PingValidator()
        {
            RuleFor(x => x.Message).NotNull().MinimumLength(2).MaximumLength(200);
        }
    }
}