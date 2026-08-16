using FluentValidation;
using Products.API.Communication.Requests;

namespace Products.API.UseCases.Clients.Register;

public class RegisterClientValidator : AbstractValidator<RequestClientJson>
{
	public RegisterClientValidator()
	{
		RuleFor(client => client.Name).NotEmpty().WithMessage("nome esta vazio.");
		RuleFor(client => client.Email).EmailAddress().WithMessage("formato invalido.");
	}
}