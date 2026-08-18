using FluentValidation;
using Products.API.Communication.Requests;

namespace Products.API.UseCases.Products.SharedValidator;

public class RequestProductValidator : AbstractValidator<RequestProductJson>
{
	public RequestProductValidator()
	{
		RuleFor(product => product.Name).NotEmpty().WithMessage("nome do produto invalido");
		RuleFor(product => product.Brand).NotEmpty().WithMessage("marca do produto invalida");
		RuleFor(product => product.Price).GreaterThan(0).WithMessage("valor do produto invalido");
	}
}
