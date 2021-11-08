using ArcadeScore.Domain.Core.Commands;
using ArcadeScore.Domain.Enuns;
using ArcadeScore.Domain.Validation.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeScore.Domain.Commads.Usuario
{
    public class UsuarioEditCommand : Command
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
            ValidationResult = new UsuarioEditCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
