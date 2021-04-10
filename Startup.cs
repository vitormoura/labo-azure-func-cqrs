using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Teamone.FunctionApp.Commands.Behaviors;

[assembly: FunctionsStartup(typeof(Teamone.FunctionApp.Startup))]

namespace Teamone.FunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IMessageService,ConsoleMessageService>();
            
            builder.Services.AddMediatR(typeof(Startup));            

            //builder.Services.AddSingleton<IValidator<Ping>, PingValidator>();    
            ///* 
            builder.Services.Scan(scan => 
                scan.FromAssemblyOf<Startup>().AddClasses(classes => 
                    classes.AssignableTo<IValidator>()
                ).AsImplementedInterfaces()
            );
            //*/

            builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        }
    }
}