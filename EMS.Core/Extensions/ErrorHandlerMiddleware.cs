using EMS.Core.Responses.General;
using EMS.Domains.EntityFramework.Entity.Repositories.Base;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace EMS.Core.Extensions
;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IUnitOfWork _unitOfWork;

    public ErrorHandlerMiddleware(RequestDelegate next, IUnitOfWork unitOfWork)
    {
        _next = next;
        _unitOfWork = unitOfWork;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            ErrorResponse errorResponse = new ErrorResponse();
            var response = context.Response;
            response.ContentType = "application/json";
            bool isException = false;
            switch (error)
            {
                case AppException e:
                    // custom application error 
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Code = e.Code;
                    errorResponse.Message = string.IsNullOrEmpty(e.AppMessage) ? e?.Message : e?.AppMessage;
                    isException = false;
                    break;
                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResponse.Code = response.StatusCode;
                    errorResponse.Message = e?.Message;
                    isException = false;
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Code = response.StatusCode;
                    isException = true;

                    break;
            }

            if (isException == true)
                errorResponse.Message = "Bir hata oluştu.";

            await response.WriteAsync(errorResponse.ToString());

        }
    }
}
