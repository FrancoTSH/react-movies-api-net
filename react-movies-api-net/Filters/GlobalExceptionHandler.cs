using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using react_movies_api_net.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace react_movies_api_net.Filters
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ValidationException validationEx:
                    HandleValidationException(context, validationEx);
                    break;
                case EntityNotFoundException notFoundEx:
                    HandleNotFoundException(context, notFoundEx);
                    break;
                case StorageException:
                    HandleStorageException(context);
                    break;
                case UnauthorizedException:
                    HandleUnauthorizedException(context);
                    break;
                default:
                    HandleUnknownException(context);
                    break;
            }

            context.ExceptionHandled = true;
        }

        private void HandleUnauthorizedException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "Unauthenticated",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }

        private void HandleStorageException(ExceptionContext context)
        {
            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "File could not be saved because of an unknown problem."
            };

            context.Result = new BadRequestObjectResult(details);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "An error occurred while processing your request.",
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        private void HandleNotFoundException(ExceptionContext context, EntityNotFoundException exception)
        {
            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "The specified resource was not found.",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);

        }

        private void HandleValidationException(ExceptionContext context, ValidationException exception)
        {
            var details = new ValidationProblemDetails(context.ModelState)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);
        }
    }
}
