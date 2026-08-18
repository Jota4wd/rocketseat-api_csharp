using Products.API.Infrastructure;
using Products.API.Communication.Responses;

namespace Products.API.UseCases.Clients.GetAll;

public class GetAllClientsUseCase
{
	public ResponseAllClientsJson Execute()
	{
		var dbContext = new ProductDbContext();

		var clients = dbContext.Clients.ToList();

		return new ResponseAllClientsJson
		{
			Clients = clients.Select(client => new ResponseShortClientJson
			{
				Id = client.Id,
				Name = client.Name,
			}).ToList()
		};
	}
}