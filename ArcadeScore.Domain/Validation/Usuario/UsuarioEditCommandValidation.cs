using ArcadeScore.Domain.Commads.Usuario;
using FluentValidation;

namespace ArcadeScore.Domain.Validation.Usuario
{
    public class UsuarioEditCommandValidation : CommandValidation<UsuarioEditCommand>
    {
        public UsuarioEditCommandValidation()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome  é obrigatório!");
            RuleFor(x => x.Nome).MaximumLength(200).WithMessage("O campo Nome não pode conter mais que 200 caracteres!");
            RuleFor(x => x.Sobrenome).NotEmpty().WithMessage("O Sobrenome  é obrigatório!");
            RuleFor(x => x.Sobrenome).MaximumLength(200).WithMessage("O campo Sobrenome não pode conter mais que 200 caracteres!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("O Email  é obrigatório!");
            RuleFor(x => x.Email).MaximumLength(200).WithMessage("O campo Email não pode conter mais que 200 caracteres!");
            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage("É obrigatório informar a data de nascimento");
        }
    }
}
