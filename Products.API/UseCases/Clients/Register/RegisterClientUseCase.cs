using Products.API.Communication.Requests;
using Products.API.Communication.Responses;
using Products.API.Infrastructure;
using Products.Exceptions.ExceptionsBase;
using Products.API.Entities;

namespace Products.API.UseCases.Clients.ShareValidator;

public class RegisterClientUseCase
{
	public ResponseShortClientJson Execute(RequestClientJson request)
	{
		Validate(request);

		var dbContext = new ProductDbContext();

		var entity = new Client
		{
			Name = request.Name,
			Email = request.Email
		};

		dbContext.Clients.Add(entity);
		dbContext.SaveChanges();

		return new ResponseShortClientJson
		{
			Id = entity.Id,
			Name = entity.Name
		};
	}

	private void Validate(RequestClientJson request)
	{
		var validator = new RequestClientValidator();
		var result = validator.Validate(request);

		if (!result.IsValid)
		{
			var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

			throw new ErrorOnValidationException(errors);
		}
	}
}