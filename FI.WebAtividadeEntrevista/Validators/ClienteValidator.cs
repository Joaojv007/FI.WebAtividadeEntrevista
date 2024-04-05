using FluentValidation;
using WebAtividadeEntrevista.Helpers;
using WebAtividadeEntrevista.Models;
using FI.AtividadeEntrevista.Services;

namespace WebAtividadeEntrevista.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteModel>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("Formatação do CPF está disposta de maneira errada! ")
                .Must(ValidarCPF).WithMessage("Digite um CPF válido! ")
                .Must(VerificarNaoExistenciaCampo).WithMessage("Esse CPF já tem cadastro, por favor utilize outro! ");
        }

        private bool ValidarCPF(string cpf)
        {
            return CPFHelper.ValidarCPF(cpf);
        }
        private bool VerificarNaoExistenciaCampo(string CPF)
        {
            return !ClienteService.VerificarExistenciaCampo(nameof(CPF), CPF);
        }
    }
}
