using Products.API.Infrastructure;
using Products.Exceptions.ExceptionsBase;

namespace Products.API.UseCases.Clients.Delete;

public class DeleteClientUseCase
{
	public void Execute(Guid id)
	{
		var dbContext = new ProductDbContext();

		var entity = dbContext.Clients.FirstOrDefault(client => client.Id == id);
		if (entity is null)
			throw new NotFoundException("cliente nao encontrado");

		dbContext.Clients.Remove(entity);
		dbContext.SaveChanges();
	}
}
