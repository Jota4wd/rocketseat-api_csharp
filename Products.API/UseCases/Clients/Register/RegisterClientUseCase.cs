using Products.API.Communication.Requests;
using Products.API.Communication.Responses;
using Products.API.Entities;
using Products.API.Infrastructure;
using Products.Exceptions.ExceptionsBase;

namespace Products.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
	public ResponseClientJson Execute(RequestClientJson request)
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

		return new ResponseClientJson
		{
			Id = entity.Id,
			Name = entity.Name
		};
	}

	private void Validate(RequestClientJson request)
	{
		var validator = new RegisterClientValidator();
		var result = validator.Validate(request);

		if (!result.IsValid)
		{
			var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

			throw new ErrorOnValidationException(errors);
		}
	}
}

