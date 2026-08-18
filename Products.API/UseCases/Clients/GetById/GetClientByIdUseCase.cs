using Products.API.Infrastructure;
using Products.Exceptions.ExceptionsBase;
using Products.API.Communication.Responses;
using Microsoft.EntityFrameworkCore;

namespace Products.API.UseCases.Clients.GetById;

public class GetClientByIdUseCase
{
	public ResponseClientJson Execute(Guid id)
	{
		var dbContext = new ProductDbContext();

		var entity = dbContext
		.Clients
		.Include(client => client.Products)
		.FirstOrDefault(client => client.Id == id);

		if (entity is null)
			throw new NotFoundException("cliente nao encontrado");

		return new ResponseClientJson
		{
			Id = entity.Id,
			Name = entity.Name,
			Email = entity.Email,
			Products = entity.Products.Select(product => new ResponseShortProductJson
			{
				Id = product.Id,
				Name = product.Name,
			}).ToList()
		};
	}
}