using Products.API.Communication.Requests;
using Products.API.Communication.Responses;
using Products.Exceptions.ExceptionsBase;

namespace Products.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
	public ResponseClientJson Execute(RequestClientJson request)
	{
		var validator = new RegisterClientValidator();
		var result = validator.Validate(request);

		if (!result.IsValid)
		{
			var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

			throw new ErrorOnValidationException(errors);
		}

		return new ResponseClientJson();
	}
}