using FluentValidation;
using WebAtividadeEntrevista.Helpers;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteModel>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("Formatação do CPF está disposta de maneira errada! ")
                .Must(ValidarCPF).WithMessage("Digite um CPF válido! ");
        }

        private bool ValidarCPF(string cpf)
        {
            return CPFHelper.ValidarCPF(cpf);
        }
    }
}
