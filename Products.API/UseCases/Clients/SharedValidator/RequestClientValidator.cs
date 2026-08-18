using FluentValidation;
using Products.API.Communication.Requests;

namespace Products.API.UseCases.Clients.ShareValidator;

public class RequestClientValidator : AbstractValidator<RequestClientJson>
{
	public RequestClientValidator()
	{
		RuleFor(client => client.Name).NotEmpty().WithMessage("nome esta vazio.");
		RuleFor(client => client.Email).EmailAddress().WithMessage("formato invalido.");
	}
}