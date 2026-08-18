using Products.API.Communication.Requests;
using Products.API.Infrastructure;
using Products.API.UseCases.Clients.ShareValidator;
using Products.Exceptions.ExceptionsBase;

namespace Products.API.UseCases.Clients.Update;

public class UpdateClientUseCase
{
	public void Execute(Guid clientId, RequestClientJson request)
	{
		validate(request);

		var dbContext = new ProductDbContext();

		var entity = dbContext.Clients.FirstOrDefault(client => client.Id == clientId);
		if (entity is null)
			throw new NotFoundException("Cliente nao encontrado");

		entity.Name = request.Name;
		entity.Email = request.Email;

		dbContext.Clients.Update(entity);
		dbContext.SaveChanges();
	}

	private void validate(RequestClientJson request)
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