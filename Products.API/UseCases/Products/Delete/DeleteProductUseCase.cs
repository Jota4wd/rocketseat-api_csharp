using Products.API.Infrastructure;
using Products.Exceptions.ExceptionsBase;

namespace Products.API.UseCases.Products.Delete;

public class DeleteProductUseCase
{
	public void Execute(Guid id)
	{
		var dbContext = new ProductDbContext();

		var entity = dbContext.Products.FirstOrDefault(product => product.Id == id);
		if (entity is null)
			throw new NotFoundException("produto nao encontrado");

		dbContext.Products.Remove(entity);
		dbContext.SaveChanges();
	}
}