using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tournament.Domain.Models;

namespace Tournament.Domain.Services
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : EntityBase
        where TResponse : Response
    {
        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var obj = (EntityBase)request;

            obj.Validate();

            if (obj.Invalid)
            {
                var response = (TResponse)new Response(obj.Notifications, true);
                return response;
            }

            return await next?.Invoke();
        }
    }
}