using Microsoft.AspNetCore.Mvc;
using Products.API.Communication.Responses;
using Products.API.Communication.Requests;
using Products.API.UseCases.Products.Register;
using Products.API.UseCases.Products.Delete;

namespace Products.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	[HttpPost]
	[Route("{clientId}")]
	[ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
	[ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
	public IActionResult Register([FromRoute] Guid clientId, [FromBody] RequestProductJson request)
	{
		var useCase = new RegisterProductUseCase();
		var response = useCase.Execute(clientId, request);

		return Created(string.Empty, response);
	}

	[HttpDelete]
	[Route("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]

	public IActionResult Delete([FromRoute] Guid id)
	{
		var useCase = new DeleteProductUseCase();

		useCase.Execute(id);

		return NoContent();
	}
}