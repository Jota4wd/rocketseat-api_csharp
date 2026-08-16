using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Products.API.Communication.Responses;
using Products.Exceptions.ExceptionsBase;

namespace Products.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		if (context.Exception is ProductsException productsException)
		{
			context.HttpContext.Response.StatusCode = (int)productsException.GetHttpStatusCode();
			context.Result = new ObjectResult(new ResponseErrorMessagesJson(productsException.GetErrors()));


		}
		else
		{
			ThrowUnknowError(context);
		}
	}

	private void ThrowUnknowError(ExceptionContext context)
	{
		context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
		context.Result = new ObjectResult(new ResponseErrorMessagesJson("Erro desconhecido"));
	}
}