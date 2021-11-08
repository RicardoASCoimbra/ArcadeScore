using ArcadeScore.Domain.Core.Commands;
using ArcadeScore.Domain.Enuns;
using ArcadeScore.Domain.Validation.Usuario;
using System;

namespace ArcadeScore.Domain.Commads.Usuario
{
    public class UsuarioCreateCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual Escolaridade Escolaridade { get; set; }
        public bool Excluido { get; set; }


        public override bool IsValid()
        {
            ValidationResult = new UsuarioCreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
