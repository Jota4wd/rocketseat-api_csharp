using System.Net;

namespace Products.Exceptions.ExceptionsBase;

public abstract class ProductsException : SystemException
{
	public ProductsException(string errorMessage) : base(errorMessage)
	{
	}

	public abstract List<string> GetErrors();
	public abstract HttpStatusCode GetHttpStatusCode();
}