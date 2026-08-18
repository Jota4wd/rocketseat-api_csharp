using System.Net;

namespace Products.Exceptions.ExceptionsBase;

public class NotFoundException : ProductsException
{
	public NotFoundException(string errorMessage) : base(errorMessage) { }
	public override List<string> GetErrors() => [Message];
	public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
}