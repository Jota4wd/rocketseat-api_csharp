using Microsoft.AspNetCore.Mvc;
using Products.API.UseCases.Clients.Register;
using Products.API.Communication.Requests;
using Products.API.Communication.Responses;

namespace Products.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ClientsController : ControllerBase
{
	[HttpPost]
	[ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
	public IActionResult Register([FromBody] RequestClientJson request)
	{
		var useCase = new RegisterClientUseCase();
		var response = useCase.Execute(request);

		return Created(string.Empty, response);
	}

	[HttpPut]
	public IActionResult Update()
	{
		return Ok();
	}

	[HttpGet]
	public IActionResult GetAll()
	{
		return Ok();
	}

	[HttpGet]
	[Route("{Id}")]
	public IActionResult GetById([FromRoute] Guid id)
	{
		return Ok();
	}

	[HttpDelete]
	public IActionResult Delete()
	{
		return Ok();
	}

}