using Microsoft.AspNetCore.Mvc;
using Products.API.Communication.Requests;
using Products.API.Communication.Responses;
using Products.API.UseCases.Clients.Delete;
using Products.API.UseCases.Clients.GetAll;
using Products.API.UseCases.Clients.GetById;
using Products.API.UseCases.Clients.ShareValidator;
using Products.API.UseCases.Clients.Update;
using Products.API.UseCases.Products.Delete;

namespace Products.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ClientsController : ControllerBase
{
	[HttpPost]
	[ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
	public IActionResult Register([FromBody] RequestClientJson request)
	{
		var useCase = new RegisterClientUseCase();
		var response = useCase.Execute(request);

		return Created(string.Empty, response);
	}

	[HttpPut]
	[Route("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
	[ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
	public IActionResult Update([FromRoute] Guid id, [FromBody] RequestClientJson request)
	{
		var useCase = new UpdateClientUseCase();

		useCase.Execute(id, request);

		return NoContent();
	}

	[HttpGet]
	[ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public IActionResult GetAll()
	{
		var useCase = new GetAllClientsUseCase();
		var response = useCase.Execute();

		if (response.Clients.Count == 0)
			return NoContent();
		return Ok(response);
	}

	[HttpGet]
	[Route("{id}")]
	[ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]

	public IActionResult GetById([FromRoute] Guid id)
	{
		var useCase = new GetClientByIdUseCase();
		var response = useCase.Execute(id);

		return Ok(response);
	}

	[HttpDelete]
	[Route("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]

	public IActionResult Delete([FromRoute] Guid id)
	{
		var useCase = new DeleteClientUseCase();

		useCase.Execute(id);

		return NoContent();
	}
}