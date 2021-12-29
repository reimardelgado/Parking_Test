using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ParkingLots.Domain.Exceptions;
using ParkingLots.Domain.Models;

namespace ParkingLots.Infrastructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogInformation("{Exception} - {Code} - {Message}", nameof(exception), exception.GetHashCode(),
                exception.Message);

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                DomainException domainException => (int)(domainException.HttpStatusCode ?? HttpStatusCode.BadRequest),
                ValidationException _ => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var response = JsonConvert.SerializeObject(new EntityErrorResponse
            {
                Code = exception.GetHashCode(),
                Message = exception.Message,
                Errors = GetMessageError(exception)
            });

            await context.Response.WriteAsync(response);
        }

        private static List<string> GetMessageError(Exception exception)
        {
            var errors = new List<string>();

            switch (exception.InnerException)
            {
                case null:
                    return errors;
                case ValidationException validationException:
                    errors.AddRange(validationException.Errors.Select(error => error.ToString()));
                    break;
                default:
                    errors.Add(exception.InnerException?.Message);
                    break;
            }

            return errors;
        }
    }
}