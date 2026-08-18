using Products.API.Infrastructure;
using Products.API.UseCases.Products.SharedValidator;
using Products.Exceptions.ExceptionsBase;
using Products.API.Communication.Responses;
using Products.API.Communication.Requests;
using Products.API.Entities;

namespace Products.API.UseCases.Products.Register;

public class RegisterProductUseCase
{
	public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
	{
		var dbContext = new ProductDbContext();

		Validate(dbContext, clientId, request);

		var entity = new Product
		{
			Name = request.Name,
			Brand = request.Brand,
			Price = request.Price,
			ClientId = clientId
		};

		dbContext.Products.Add(entity);
		dbContext.SaveChanges();

		return new ResponseShortProductJson
		{
			Id = entity.Id,
			Name = entity.Name,
		};
	}

	private void Validate(ProductDbContext dbContext, Guid clientId, RequestProductJson request)
	{
		var clientExist = dbContext.Clients.Any(client => client.Id == clientId);
		if (!clientExist)
			throw new NotFoundException("cliente nao existe");

		var validator = new RequestProductValidator();

		var result = validator.Validate(request);
		if (!result.IsValid)
		{
			var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
			throw new ErrorOnValidationException(errors);
		}
	}
}